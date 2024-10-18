using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.ComponentModel.DataAnnotations;

namespace Online_Learning_Platform.ViewModel
{
    public class LoginUserViewModel
    {
        [Required (ErrorMessage="*")]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        //public  string  Email { get; set; }

        [Display(Name= "Remember Me !!")]
        public bool RememberMe { get; set; }
    }
}
