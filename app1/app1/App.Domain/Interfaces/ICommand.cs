using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
    public interface ICommand<E> where E : class, IEntity
    {
        IResult<List<E>> Select();
        IResult<E> Get();
        IResult Create(Data.Model.Context context);
        IResult Delete();
        IResult Update();
    }
}
