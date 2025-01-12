using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Business.Helper.Exception.Base;

namespace TaskApp.Business.Helper.Exception
{
    public class NotFoundException<T> : System.Exception, IException where T : class
    {
        public string ErrorMessage { get; }

        public int StatusCode { get; }
        public NotFoundException() : base()
        {
            ErrorMessage = $"{typeof(T).Name} tapilmadi";
            StatusCode = 404;
        }

        public NotFoundException(string message) : base(message)
        {
            ErrorMessage = message;
            StatusCode = 404;
        }


    }
}
