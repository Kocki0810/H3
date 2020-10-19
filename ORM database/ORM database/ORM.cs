using System;
using System.Collections.Generic;
using System.Text;

namespace ORM_database
{
    abstract class ORMField
    {
        public int name { get; set; }
        public abstract string GetSQLValue(ORM orm);
            
    }
    class ORMInt : ORMField
    {
        Func<ORM, int> Getter { get; set; }
        public ORMInt(Func<ORM, int> getter)
        {
            Getter = getter;
        }
        public override string GetSQLValue(ORM orm)
        {
            return Getter(orm).ToString();
        }
    }
    class ORMString
    {

        public string field { get; set; }
    }
    abstract class ORM
    {
        protected abstract string TableName();
        static Dictionary<string, Dictionary<string, ORMField>> tables = new Dictionary<string, Dictionary<string, ORMField>>();

        static ORM()
        {
            Console.WriteLine("Hej orm");
        }
        protected static void Int(string table, string field, Func<ORM, int> getter)
        {
            if (tables.ContainsKey(table) == false)
            {
                tables[table] = new Dictionary<string, ORMField>();
            }
            tables[table][field] = new ORMInt(getter);
        }
        protected static void String(string table, string field, Func<ORM, string> getter)
        {

        }
        public void Insert()
        {
            string tableName = TableName();
            string columns;
            string values = "";
            List<string> fieldValues = new List<string>();
            List<string> fieldNames = new List<string>();
            foreach(KeyValuePair<string, ORMField> kv in tables[tableName])
            {
                string fieldName = kv.Key;
                fieldNames.Add(fieldName);
                fieldValues.Add(ORMInt.GetSQLValue())
            }

            values = string.Join(',', fieldValues);
            columns = string.Join(',', fieldNames);
            string sql = $"INSERT INTO ´{tableName}´ ({columns}) VALUES ({values})";
            Console.WriteLine(sql);
        }
        public void Update()
        {

        }
        public void Delete()
        {

        }
        public void Select(string where)
        {

        }
    }
}
