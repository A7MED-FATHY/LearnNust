using Microsoft.AspNetCore.Identity;

namespace Online_Learning_Platform.Models
{
    public class AppliactionUser:IdentityUser
    {
        public string? Address {set; get;}
    }
}
