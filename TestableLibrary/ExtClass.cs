using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestableLibrary
{
    public static class ExtClass
    {
        public static int ExtMethod(this MyClass myClass, int param)
        {
            return param;
        }
    }
}
