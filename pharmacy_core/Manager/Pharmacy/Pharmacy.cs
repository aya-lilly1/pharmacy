using AutoMapper;
using pharmacy_DbModel.Data;
using pharmacy_modelview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_core.Manager.Pharmacy
{
    public class Pharmacy : IPharmacy
    {
        private ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public Pharmacy(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //public (List<DurgsMV>,object) GetAllDurgs( string name ,int page,int resultCount)
        //{
        //    var offset=(page-1) * resultCount;
        //    var entityCount = _dbContext.Durgs.Where(x => (string.IsNullOrEmpty(name)
        //                                                    || x.Name.ToLower()
        //                                                        .Contains(name.ToLower())
        //                                                        )).Count();


        //    var res =_dbContext.Durgs.Skip(offset).Take(resultCount).ToList();
        //    var result = _mapper.Map<List<DurgsMV>>(res);
        //    int endCount = offset + resultCount;
        //    bool morePages = endCount < entityCount;
        //    return( result,morePages) ;
        //}

        public (List<DurgsMV>, bool) GetAllDurgs(string name, int page, int resultCount)
        {
            var offset = (page - 1) * resultCount;
            var data = _dbContext.Durgs.AsQueryable();
            if (!string.IsNullOrEmpty(name))
                data = data.Where(x => x.Name.ToLower().Contains(name.ToLower())).AsQueryable();

            var res = data
                .Skip(offset)
                .Take(resultCount)
                .ToList();

            var result = _mapper.Map<List<DurgsMV>>(res);
            int endCount = offset + resultCount;
            bool morePages = endCount < data.Count();

            return (result, morePages);
        }
    }
}
