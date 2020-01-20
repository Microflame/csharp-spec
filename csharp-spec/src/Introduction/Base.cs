using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using csharp_spec.Src.Tools;

namespace csharp_spec.Src.Introduction
{
    class Base : Runnable<Base>
    {
        public override void Run()
        {
            PrimitivesLineage.RunMe();
            UserDefinedTypes.RunMe();
        }

        class UserDefinedTypes : Runnable<UserDefinedTypes>
        {
            class ExampleBase { }
            class ExampleClass : ExampleBase
            {
                public void PublicMethod()
                {
                    Console.WriteLine("PublicMethod.");
                }

                private void PrivateMethod()
                {
                    Console.WriteLine("PrivateMethod.");
                }

                public static void PublicStaticMethod()
                {
                    Console.WriteLine("PublicStaticMethod");
                }

                public string publicField = "publicField";
            }

            struct ExampleStruct { }

            interface ExampleInterface
            {
                void PublicMethod();
            }

            enum ExampleEnum
            {
                Red,
                Green,
                Blue
            }

            delegate int ExampleDelegate();


            public override void Run()
            {
                Types types = new Types();
                Console.WriteLine("Classes are ref types and allocated on heap.");
                Console.WriteLine(types.GetLineage<ExampleClass>());
                Console.WriteLine("Structs are value types and allocated on stack");
                Console.WriteLine(types.GetLineage<ExampleStruct>());
                Console.WriteLine("Interfaces are typeless");
                Console.WriteLine(types.GetLineage<ExampleInterface>());
                Console.WriteLine(types.GetLineage<ExampleEnum>());
                Console.WriteLine(types.GetLineage<ExampleDelegate>());
                Console.WriteLine("1D array");
                Console.WriteLine(types.GetLineage<int[]>());
                Console.WriteLine("2D array");
                Console.WriteLine(types.GetLineage<int[,]>());
                Console.WriteLine("1D array of 1D arrays");
                Console.WriteLine(types.GetLineage<int[][]>());
                Console.WriteLine("Nullable types");
                Console.WriteLine(types.GetLineage<int?>());
                Console.WriteLine("In C# there are nullable ref types");
                Console.WriteLine("Boxing/Unboxing");
                Console.WriteLine("For some reason they have same type");
                int a = 111;
                object aObj = a;
                Console.WriteLine(types.GetLineage(a.GetType()));
                Console.WriteLine(types.GetLineage(aObj.GetType()));

            }
        }

        class PrimitivesLineage : Runnable<PrimitivesLineage>
        {
            public override void Run()
            {
                Types types = new Types();
                Console.WriteLine("Unlike in Java, in C# even primitives are inhereted from System.Object:");
                Console.WriteLine(types.GetLineage<int>());
                Console.WriteLine(types.GetLineage<char>());
                Console.WriteLine(types.GetLineage<ulong>());
                Console.WriteLine(types.GetLineage<double>());
                Console.WriteLine(types.GetLineage<string>());
            }
        }
    }
}
