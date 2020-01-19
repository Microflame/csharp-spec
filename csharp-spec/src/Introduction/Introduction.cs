using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_spec.src.Introduction
{
    class Introduction
    {
        public void Run()
        {
            PrimitivesLineage.Run();
        }

        class PrimitivesLineage
        {
            public static void Run()
            {
                (new PrimitivesLineage()).Print();
            }

            public void Print()
            {
                Console.WriteLine("Unlike in Java, in C# even primitives are inhereted from System.Object:");
                Console.WriteLine(GetLineage<int>());
                Console.WriteLine(GetLineage<char>());
                Console.WriteLine(GetLineage<ulong>());
                Console.WriteLine(GetLineage<double>());
                Console.WriteLine(GetLineage<string>());
            }
            private string GetLineage<T>()
            {
                return GetLineage(typeof(T));
            }

            private string GetLineage(Type t)
            {
                string lineage = "";
                Tools.Types types = new Tools.Types();
                List<Type> lineage_list = Tools.Types.GetLineage(t);
                string sep = "";
                foreach (Type predecessor in lineage_list)
                {
                    lineage += sep + predecessor.FullName;
                    sep = " => ";
                }

                return lineage;
            }
        }
    }
}
