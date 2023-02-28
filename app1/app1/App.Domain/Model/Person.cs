using App.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Model
{
    public class Person : ICommand<Person>, IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Cf { get; set; }
        public string Email { get; set; }
        public int Iduser { get; set; }
        public List<Person> Select() {
            using(var context = new App.Data.Model.Context())
            {
                var ExtentionMethod = context.People.Select(p => new Person());
            }
        }
        public Person Get(){
            throw new NotImplementedException();
        }
        public IResult Create() {
            throw new NotImplementedException();
        }
        public IResult Update() {
            throw new NotImplementedException();
        }
        public IResult Delete() {
            throw new NotImplementedException();
        }
    }
}
