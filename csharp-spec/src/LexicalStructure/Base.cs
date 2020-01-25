using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using csharp_spec.Src.Tools;

namespace csharp_spec.Src.LexicalStructure
{
    class Base: Runnable<Base>
    {
        class StackallocPerf: Runnable<StackallocPerf>
        {
            unsafe double RunStackalloc()
            {
                int* x = stackalloc int[AllocSize];
                int s = 0;
                for (int i = 0; i < AllocSize; ++i)
                {
                    s += x[i];
                }
                return s;
            }
            unsafe double RunNew()
            {
                int[] x = new int[AllocSize];
                int s = 0;
                for (int i = 0; i < AllocSize; ++i)
                {
                    s += x[i];
                }
                return s;
            }

            public override void Run()
            {
                double s = 0;
                Stopwatch watch = Stopwatch.StartNew();
                for (int i = 0; i < NumIter; ++i)
                {
                    s += RunStackalloc();
                }
                Console.WriteLine("stackalloc Elapsed {0} s.", watch.Elapsed.TotalSeconds);
                watch = Stopwatch.StartNew();
                for (int i = 0; i < NumIter; ++i)
                {
                    s += RunNew();
                }
                Console.WriteLine("new Elapsed {0} s.", watch.Elapsed.TotalSeconds);
                Console.WriteLine("stackalloc only makes sense for tiny allocations");
            }

            int NumIter = 1000000;
            int AllocSize = 16;
        }
        public override void Run()
        {
            StackallocPerf.RunMe();
        }
    }
}
