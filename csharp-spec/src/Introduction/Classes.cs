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
        // Type modifiers
        public int anyoneCanAccess;
        protected int onlyDerivedCanAccess;
        internal int availableForThisAssembly;
        protected internal int bothPreviousCanAccess;
        private int onlyThisClassCanAccess;

        private const string ConstString = "Const can only be initialized used const and hence static by default";
        private readonly string ReadonlyString = "readonly fields are more like const in other langs";

        // Type parameters
        public class Pair<T, U>
        {
            public T First;
            public U Second;
        }

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
        }
    }
}
