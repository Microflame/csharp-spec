using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_spec.src
{
    class Runner
    {
        static void Main()
        {
            Introduction.Introduction intro = new Introduction.Introduction();

            intro.Run();

            KeepConsoleOpen();
        }

        static void KeepConsoleOpen()
        {
            Console.Read();
        }
    }
}
