using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using csharp_spec.Src.Tools;

namespace csharp_spec.Src.Introduction
{
    class Classes : Runnable<Classes>
    {

        class FunctionMembers : Runnable<FunctionMembers>
        {
            static string StaticString;
            static FunctionMembers()
            {
                StaticString = "Static Constructor is a function member.";
            }
            public FunctionMembers()
            {
                Console.WriteLine("Instance Constructor is a function member.");
            }

            public string Method()
            {
                return "Method is a function member.";
            }

            public string Property
            {
                get
                {
                    return "Property is a fuction member.";
                }
                set
                {
                    Console.WriteLine(value);
                    throw new NotImplementedException();
                }
            }

            // Why is it called `this`? In my opinion it should be called in the same manner as ctor.
            // Or we should have used this(...) for ctor
            // Yet another C# incosistency
            // And why not use operator[]? --Because we had no return by reference until C# 7 probably.
            public string this[int idx]
            {
                get
                {
                    return "Indexer is a fuction member.";
                }
                set
                {
                    throw new NotImplementedException();
                }
            }

            public static bool operator !(FunctionMembers fm)
            {
                Console.WriteLine("Operators are fuction members. They all should be public static");
                return true;
            }

            public override void Run()
            {
                Console.WriteLine(StaticString);
                Console.WriteLine(Method());
                Console.WriteLine(Property);
                Console.WriteLine(this[0]);
                bool _ = !this;
            }

            ~FunctionMembers()
            {
                // Just... Don't
            }
        }
        // Type parameters
        public class Pair<T, U>
        {
            public T First;
            public U Second;
        }

        // Type modifiers
        public int anyoneCanAccess;
        protected int onlyDerivedCanAccess;
        internal int availableForThisAssembly;
        protected internal int bothPreviousCanAccess;
        private int onlyThisClassCanAccess;

        private const string ConstString = "Const can only be initialized used const and hence static by default";
        private readonly string ReadonlyString = "readonly fields are more like const in other langs";


        public Classes()
        {
            ReadonlyString = "readonly fields are more like const in other langs. ";
            ReadonlyString += "But can be assigned multiple times in ctor";
        }

        public T UninferrableMethod<T>()
        {
            Console.WriteLine("Some methods require explicit type parameter specification");
            return default(T);
        }

        public void InferrableMethod<T>(T t)
        {
            Console.WriteLine("But some can be inferred from arguments");
        }

        public void RefPass(ref string x)
        {
            x = "C# supports pass by reference for values and objects";
        }

        public void OutPass(out string x)
        {
            // Console.WriteLine(x); <--- Can not use out parameters
            x = "C# supports output parameters";
        }

        public string ParamArray(params string[] words)
        {
            string res = String.Join(" ", words);
            return res;
        }

        public override void Run()
        {
            Pair<int, string> pair = new Pair<int, string>();
            Console.WriteLine(pair.GetType().FullName);
            // Btw Pair<int, string> will share IL code with Pair<int, Classes>, because string and Classes are ref types
            // While Pair<int, int> will have different code than Pair<int, short> since int and short are val types and have different sizes on stack

            Console.WriteLine(Classes.ConstString);
            Console.WriteLine(this.ReadonlyString);

            UninferrableMethod<int>();
            InferrableMethod(123);

            string x = "empty";
            RefPass(ref x);
            Console.WriteLine(x);
            OutPass(out x);
            Console.WriteLine(x);

            Console.WriteLine(ParamArray("C#", "supports", "variable", "number", "of", "arguments"));

            FunctionMembers.RunMe();
        }
    }
}
