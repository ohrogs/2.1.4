using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Model
{
    [Table("people")]
    public class Person
    {
        [Key]
        [Column("ID")]
        [Required]
        public int ID { get; set; }
        [Column("NAME")]
        public string Name { get; set; }
        [Column("SURNAME")]
        public string Surname { get; set; }
        [Column("BIRTHDATE")]
        public DateTime? Birthdate { get; set; }

        [Column("CF")]
        [MaxLength(16)]
        public string Cf { get; set; }

        [Column("EMAIL")]
        [Required]
        public string Email { get; set; }

        [Column("IDUSER")]
        public int Iduser { get; set; }

        [ForeignKey(nameof(Iduser))]
        public virtual User User { get; set; }
    }
}
