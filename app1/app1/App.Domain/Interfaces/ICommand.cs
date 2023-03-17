using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
    public interface ICommand<E> where E : class, IEntity
    {
        IResult<List<E>> Select(Data.Model.Context context);
        IResult<E> Get(Data.Model.Context context);
        IResult Create(Data.Model.Context context);
        IResult Delete(Data.Model.Context context);
        IResult Update(Data.Model.Context context);
    }
}
