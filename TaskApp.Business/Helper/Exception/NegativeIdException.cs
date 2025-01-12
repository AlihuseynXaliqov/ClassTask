using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Business.Helper.Exception
{
    public class NegativeIdException:System.Exception
    {
        public NegativeIdException():base("Id menfi ve sifir ola bilmez") { }
    }
}
