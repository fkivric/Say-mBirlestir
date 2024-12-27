using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

public static class DataTableExtensions
{
    public static List<T> ToList<T>(this DataTable table) where T : new()
    {
        List<T> list = new List<T>();

        foreach (var row in table.AsEnumerable())
        {
            T obj = new T();

            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                try
                {
                    PropertyInfo property = typeof(T).GetProperty(prop.Name);

                    if (property != null && row.Table.Columns.Contains(prop.Name) && !row.IsNull(prop.Name))
                    {
                        object value = Convert.ChangeType(row[prop.Name], property.PropertyType);
                        property.SetValue(obj, value, null);
                    }
                }
                catch
                {
                    continue;
                }
            }

            list.Add(obj);
        }

        return list;
    }
}
