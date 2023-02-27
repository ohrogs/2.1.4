using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Model
{
    internal class Pearson
    {
        int ID { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        DateOnly Birthdate { get; set; }

        [MaxLength(16)]
        string Cf { get; set; }

        string Email { get; set; }

        int Iduser { get; set; }

        [ForeignKey(nameof(Iduser))]
        public virtual User User { get; set; }
    }
}
