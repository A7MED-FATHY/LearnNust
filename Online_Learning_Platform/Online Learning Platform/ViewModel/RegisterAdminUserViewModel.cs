using System.ComponentModel.DataAnnotations;

namespace Online_Learning_Platform.ViewModel
{
    public class RegisterAdminUserViewModel
    {


            [Required]
            public string UserName { get; set; }

            [DataType(DataType.Password)]
            [Required]
            public string Password { get; set; }
            [Required]
            [Display(Name = "Confirm Password ")]
            [Compare("Password")]
            public string ConfirmPassword { get; set; }
            [Required]
            [MaxLength(256, ErrorMessage = "Email cannot exceed 256 characters.")]
            public string Email { get; set; }
            public string? Address { get; set; }


        
    }
}
