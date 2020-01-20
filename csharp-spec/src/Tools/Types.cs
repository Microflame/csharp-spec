using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_spec.Src.Tools
{
    class Types
    {
        public static List<Type> GetLineageList(Type t)
        {
            List<Type> lineage = new List<Type>();

            while (t != null)
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

        public string GetLineage<T>()
        {
            return GetLineage(typeof(T));
        }

        public string GetLineage(Type t)
        {
            string lineage = "";
            List<Type> lineage_list = GetLineageList(t);
            string sep = "";
            foreach (Type predecessor in lineage_list)
            {
                lineage += sep + predecessor.FullName;
                sep = " => ";
            }

            return lineage;
        }

        public Type GetStaticType<T>(T x) { return typeof(T); }
    }
}
