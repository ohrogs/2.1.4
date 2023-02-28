using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Model
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("ID")]
        [Required]
        public int ID { get; set; }

        [Column("NICKNAME")]
        [Required]
        public string Nickname { get; set; }

        [Column("HASH")]
        [Required]
        public string Hash { get; set; }

        [Column("SALT")]
        [Required]
        public string Salt { get; set; }
    }
}
