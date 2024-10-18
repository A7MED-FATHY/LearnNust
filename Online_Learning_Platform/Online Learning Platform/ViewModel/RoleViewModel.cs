using System.ComponentModel.DataAnnotations;

namespace Online_Learning_Platform.ViewModel
{
    /// <summary>
    /// Represents a role in the online learning platform.
    /// </summary>
    public class RoleViewModel
    {
        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
