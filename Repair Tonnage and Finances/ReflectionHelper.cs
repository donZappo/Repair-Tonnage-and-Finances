using System;
using System.Reflection;

namespace Repair_Tonnage
{
    public static class ReflectionHelper
    {
        public static object InvokePrivateMethode(object instance, string methodname, object[] parameters)
        {
            Type type = instance.GetType();
            MethodInfo method = type.GetMethod(methodname, BindingFlags.Instance | BindingFlags.NonPublic);
            return method.Invoke(instance, parameters);
        }

        public static object InvokePrivateMethode(object instance, string methodname, object[] parameters, Type[] types)
        {
            Type type = instance.GetType();
            MethodInfo method = type.GetMethod(methodname, BindingFlags.Instance | BindingFlags.NonPublic, null, types, null);
            return method.Invoke(instance, parameters);
        }

        public static void SetPrivateProperty(object instance, string propertyname, object value)
        {
            Type type = instance.GetType();
            PropertyInfo property = type.GetProperty(propertyname, BindingFlags.Instance | BindingFlags.NonPublic);
            property.SetValue(instance, value, null);
        }

        public static void SetPrivateField(object instance, string fieldname, object value)
        {
            Type type = instance.GetType();
            FieldInfo field = type.GetField(fieldname, BindingFlags.Instance | BindingFlags.NonPublic);
            field.SetValue(instance, value);
        }

        public static object GetPrivateField(object instance, string fieldname)
        {
            Type type = instance.GetType();
            FieldInfo field = type.GetField(fieldname, BindingFlags.Instance | BindingFlags.NonPublic);
            return field.GetValue(instance);
        }
    }
}
