using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserSearch.Models
{
    public class UserMedia
    {
        [Key]
        [Column(Order = 0)]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        [Key]
        [Column(Order = 1)]
        public int MediaId { get; set; }

        public virtual Media Media { get; set; }
    }
}
