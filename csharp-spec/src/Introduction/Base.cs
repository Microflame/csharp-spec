using System;
using System.Reflection;
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
            Classes.RunMe();
            InterfaceImplementer.RunMe();
            Delegates.RunMe();
            Attributes.RunMe();
        }

        class Attributes: Runnable<Attributes>
        {
            public class SampleAttribute: Attribute
            {
                public SampleAttribute(string msg)
                {
                    Msg = msg;
                }

                public string Msg { get; }

                public string More { get; set; }
            }

            public void PrintAtt(MemberInfo member)
            {
                SampleAttribute a = Attribute.GetCustomAttribute(member, typeof(SampleAttribute)) as SampleAttribute;
                if (a == null)
                {
                    Console.WriteLine("Att not found.");
                }
                else
                {
                    Console.WriteLine(a.Msg);
                    Console.WriteLine(a.More);
                }
            }

            [Sample("Trailing \"Attribute\" can be omitted when attaching attrtibute.",
                More = "And additional properties can be set as if they are named parameters of the ctor.")]
            public void SampleMethod()
            {

            }

            public override void Run()
            {
                PrintAtt(GetType().GetMethod("SampleMethod"));
            }
        }

        enum Enum: byte
        {
            Zero, // 0
            One, // 1
            Twenty = 20,
            TwentyOne // 21
        }

        class Delegates: Runnable<Delegates>
        {
            string str = "Delegates contain methods, functions or lambdas.";

            delegate void Function(string s);
            Function function;

            public Delegates()
            {
                function = (string s) => { Console.WriteLine(s); };
            }

            public override void Run()
            {
                function(str);
            }
        }

        // This is a value type
        public struct Struct
        {
            // Since structs are stack-allocated, they should be vastly more efficient in arrays than classes
            // So the real argument is memory alignment
        }

        public class Arrays: Runnable<Arrays>
        {
            public override void Run()
            {
                int[] a = new int[3];
                // Initialized
                int[] b = { 1, 2, 3 };
                // MultiD
                int[,] c = new int[2, 3];
                // Jagged
                int[][] d = new int[2][];
                d[0] = new int[3];
                d[1] = new int[4];
                // Can validate length
                int[] e = new int[3] { 1, 2, 3 };

            }
        }

        public interface Interface
        {
            string Method();

            string Property
            {
                get;
            }

            string this[int idx]
            {
                get;
            }

            // Can also contain events
        }

        public interface AnotherInterface
        {
            string Property
            {
                get;
            }
        }

        public class InterfaceImplementer: Runnable<InterfaceImplementer>, Interface, AnotherInterface
        {
            public override void Run()
            {
                Console.WriteLine(Method());
                Console.WriteLine(((Interface) this).Property);
                Console.WriteLine(((AnotherInterface) this).Property);
                Console.WriteLine(this[123]);
            }

            public string Method()
            {
                return "Interface can contain methods";
            }

            string Interface.Property
            {
                get => "Property from Interface";
            }

            string AnotherInterface.Property
            {
                get => "Property from AnotherInterface";
            }

            public string this[int idx]
            {
                get => "Interfaces can contain indexers.";
            }
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
