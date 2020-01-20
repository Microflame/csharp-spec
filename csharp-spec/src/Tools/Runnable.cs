using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_spec.Src.Tools
{
    // Unlike in Java, in C# it is ok to put multiple top public level types (classes/interfaces) in a single file

    interface IRunnable
    {
        void Run();
    }

    abstract class Runnable<T> : IRunnable where T : IRunnable, new()
    {
        public abstract void Run();

        public static void RunMe()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n>>>>> " + typeof(T).FullName + " <<<<<");
            Console.ForegroundColor = ConsoleColor.Gray;
            (new T()).Run();
        }
    }
}
