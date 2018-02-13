using System.ComponentModel.DataAnnotations;

namespace UserSearch.Models
{
    public class Media
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        [Display(Name = "File Name")]
        public string FileName { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "Must be 256 characters or less")]
        public string Type { get; set; }

        [Required]
        public byte[] Content { get; set; }
    }
}
