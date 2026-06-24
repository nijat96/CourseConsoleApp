using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Exceptions
{
    public class DublicateDataException:Exception
    {
        public DublicateDataException():base("Data is dublicated")
        {
            
        }
    }
}
