using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Exceptions
{
    public class NullModelException : Exception
    {
        public NullModelException(string mesage):base(mesage)
        {
        }
        public NullModelException():base("Model is null")
        {
            
        }
    }
}
