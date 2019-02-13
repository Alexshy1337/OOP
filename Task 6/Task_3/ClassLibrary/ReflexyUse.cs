using System;
using System.Collections.Generic;
using System.Reflection;


namespace ClassLibrary
{
    public class ReflexyUse
    {
        public static List<Type> GetInterfaces(Assembly assembly)
        {
            List<Type> classes = new List<Type>();
            Type[] types = assembly.GetTypes();

            foreach (Type t in types)
                foreach (Type inter in t.GetInterfaces())//правильно работает
                    if (inter.FullName == "ClassLibrary1.IVehicle" && !t.IsAbstract)
                        classes.Add(t);

            return classes;
        }

        public static object ConstrClass(Type cls, object[] constparametrs)
        {
            return Activator.CreateInstance(cls, constparametrs);
        }

        public static string[] GetAllProperties(Type cls, object constr)
        {
            PropertyInfo[] pi = cls.GetProperties();
            List<string> answer = new List<string>();

            foreach (PropertyInfo p in pi)
            {
                answer.Add(p.Name + " " + p.GetValue(constr));

            }
            return answer.ToArray();
        }

    }
}
