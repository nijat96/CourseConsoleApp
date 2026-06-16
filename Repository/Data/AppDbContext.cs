using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Data
{
    public class AppDbContext<T>
    {
        public List<T> list;
        public AppDbContext()
        {
            list = new();
        }
    }
}
