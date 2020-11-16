using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetstoreApi.Models
{
    [Table("s_users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }
        [Column("user_id")]
        public long UserId { get; set; }
        [Column("biin")]
        public string Biin { get; set; }
        [Column("first_name")]
        public string Firstname { get; set; }
        [Column("last_name")]
        public string Lastname { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("passwrd")]
        public string Password { get; set; }
        [Column("phone")]
        public string Phone { get; set; }
    }
}