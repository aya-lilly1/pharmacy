using Microsoft.AspNetCore.Identity;

namespace pharmacy_DbModel.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string Fullname { get; set; } = string.Empty;
        public string TypeUser { get; set; } = string.Empty;
        public string? Longitude { get; set; } = string.Empty;
        public string? latitude { get; set; } =string.Empty;

    }
}
