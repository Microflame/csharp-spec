using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace csharp_spec.Src
{
    class Runner
    {
        static void Main()
        {
            Introduction.Base.RunMe();

            KeepConsoleOpen();
        }

        static void KeepConsoleOpen()
        {
            Console.Read();
        }
    }
}
