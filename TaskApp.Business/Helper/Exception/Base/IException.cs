using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Business.Helper.Exception.Base
{
    public interface IException
    {
        public string ErrorMessage { get; }
        public int StatusCode { get; }
    }
}
