using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserSearch.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Last name cannot be longer than 255 characters.")]
        public string Address { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public virtual ICollection<UserMedia> UserMedia { get; set; }
    }
}
