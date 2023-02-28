using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
    public interface ICommand<E> where E : IEntity
    {
        List<E> Select();
        E Get();
        IResult Create();
        IResult Delete();
        IResult Update();
    }
}
