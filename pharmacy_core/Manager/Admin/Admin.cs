
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OfficeOpenXml;
using pharmacy_dbmodel.Models;
using pharmacy_DbModel.Data;
using pharmacy_DbModel.Models;
using pharmacy_modelview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_core.Manager.Admin
{
    public class Admin :IAdmin
    {

        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Admin(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext dbContext,IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task AddPharmacyExcel(IFormFile excelFile)
        {
            using (var stream = new MemoryStream())
            {
                excelFile.CopyTo(stream);
                stream.Position = 0; 

                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        //var data = new ApplicationUser
                        //{
                        //    UserName = worksheet.Cells[row, 1].Value?.ToString(),
                        //    Email = worksheet.Cells[row, 1].Value?.ToString(), 
                        //    PasswordHash = worksheet.Cells[row, 1].Value?.ToString(),
                        //    Fullname = worksheet.Cells[row, 2].Value?.ToString(),
                        //    TypeUser = "Pharmacy"
                        //};
                        var data = new ApplicationUser
                        {
                            UserName = worksheet.Cells[row, 1].Value?.ToString(),
                            Email = worksheet.Cells[row, 1].Value?.ToString(),
                            Fullname = worksheet.Cells[row, 2].Value?.ToString(),
                            TypeUser = "Pharmacy"
                        };
                       var password = worksheet.Cells[row, 1].Value?.ToString();


                        // Create the user with UserManager
                        var result = await _userManager.CreateAsync(data);
                        if (result.Succeeded)
                        {

                            var hashedPassword = _userManager.PasswordHasher.HashPassword(data, password);
                            data.PasswordHash = hashedPassword;
                            await _userManager.UpdateAsync(data);
                        }
                    }

                    await _dbContext.SaveChangesAsync();
                }
            }
        }

        public void AddDurgsExcel(IFormFile excelFile)
        {
            using (var stream = new MemoryStream())
            {
                excelFile.CopyTo(stream);
                stream.Position = 0;

                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        var data = new Durg
                        {
                            Id = Convert.ToInt32(worksheet.Cells[row, 1].Value),
                            Name = worksheet.Cells[row, 2].Value?.ToString(),
                            Unit = worksheet.Cells[row, 3].Value?.ToString(), 
                            Quantity = Convert.ToInt32(worksheet.Cells[row, 4].Value),
                            Price = Convert.ToDecimal(worksheet.Cells[row, 5].Value)

                        };

                        _dbContext.Durgs.Add(data);
                    }

                    _dbContext.SaveChanges();
                }
            }
        }




    }
}
