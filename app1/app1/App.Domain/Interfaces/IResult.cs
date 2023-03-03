using App.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
    public interface IResult
    {
        ResultType State { get; }
        string Message { get; }

        public Exception Exception { get; }

    }
}
