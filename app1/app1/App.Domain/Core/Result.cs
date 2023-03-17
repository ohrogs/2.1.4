using App.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//TODO fix constructors...
namespace App.Domain.Core
{
    public class Result : IResult
    {
        public ResultType State { get; }
        public string Message { get; }
        public Exception Exception { get; }

        public Result(ResultType state)
        {
            State = state;
        }

        public Result(ResultType state, string message) : this(state)
        {
            Message = message;
        }

        public Result(ResultType state, Exception exception) : this(state)
        {
            Exception = exception;
        }

        public Result(ResultType state, Exception exception, string message)
        {
            if(state == ResultType.Undefined)
            {
                throw new ArgumentOutOfRangeException("Result state is undefined...");
            }
            State = state;
            if(state == ResultType.Success) {
                Message = message;
            }
            else if(String.IsNullOrEmpty(message) && exception == null) {
                throw new InvalidOperationException("Message or Exception cannot be null");
            }
            else
            {
                Message = message;
                Exception = exception;
            }
            
        }
    }

    public class Result<E> : Result, IResult<E> where E : class
    {
        public E Entity { get;  }

        public Result(ResultType state, Exception exception) : base(state, exception)
        {
            ;
        }

        public Result(ResultType state) : base(state)
        {
            ;
        }

        public Result(ResultType state, string message) : base(state, message) { }

        public Result(ResultType state, E entity) : base(state, null, null)
        {
            if (state != ResultType.Success)
            {
                return;
            }

            Entity = entity;
            if (Entity == null)
            {
                throw new ArgumentNullException(nameof(Entity));
            }
        }



    }
}
