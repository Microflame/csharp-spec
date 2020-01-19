using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_spec.src.Tools
{
    class Types
    {
        public static List<Type> GetLineage(Type t)
        {
            List<Type> lineage = new List<Type>();

            while (true)
            {
                lineage.Add(t);
                if (t == typeof(Object))
                {
                    break;
                }
                t = t.BaseType;
            }

            return lineage;
        }
    }
}
