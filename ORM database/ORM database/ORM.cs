using System;
using System.Collections.Generic;
using System.Text;

namespace ORM_database
{
    abstract class ORMField
    {
        public string Name { get; set; }
        public abstract string GetSQLValue(ORM orm);
        public ORMField(string name)
        {
            Name = name;
        }
    }
    class ORMInt : ORMField
    {
        Func<ORM, int> Getter { get; set; }
        public ORMInt(string name, Func<ORM, int> getter) : base(name)
        {
            Getter = getter;
        }
        public override string GetSQLValue(ORM orm)
        {
            return Getter(orm).ToString();
        }
    }
    class ORMString : ORMField
    {
        Func<ORM, string> Getter { get; set; }
        public ORMString(string name, Func<ORM, string> getter) : base (name)
        {
            Getter = getter;
        }
        public override string GetSQLValue(ORM orm)
        {
            return "'"+Getter(orm)+"'";
        }
    }
    abstract class ORM
    {
        protected abstract string TableName();
        static Dictionary<string, Dictionary<string, ORMField>> tables = new Dictionary<string, Dictionary<string, ORMField>>();
        static Dictionary<string, ORMField> primary_keys = new Dictionary<string, ORMField>();
        static ORM()
        {
            //Database connection
        }
        protected static void Add(string table, ORMField field)
        {
            if (tables.ContainsKey(table) == false)
            {
                tables[table] = new Dictionary<string, ORMField>();
            }
            tables[table][field.Name] = field;
        }
        protected static void Int(string table, string field, Func<ORM, int> getter)
        {
            Add(table, new ORMInt(field, getter));
        }
        protected static void String(string table, string field, Func<ORM, string> getter)
        {
            Add(table, new ORMString(field, getter));

        }
        protected static void PrimaryKey(string table, string fieldName)
        {
            primary_keys[table] = tables[table][fieldName];
        }
        public void Insert()
        {
            string tableName = TableName();
            string columns;
            string values;
            string fieldName;
            List<string> fieldNames = new List<string>();
            List<string> fieldValues = new List<string>();
            foreach (KeyValuePair<string, ORMField> kv in tables[tableName])
            {
                if(primary_keys[tableName] == kv.Value)
                {
                    continue;
                }
                fieldName = kv.Key;
                fieldNames.Add(fieldName);
                fieldValues.Add(kv.Value.GetSQLValue(this));
            }

            columns = string.Join(',', fieldNames);
            values = string.Join(',', fieldValues);
            string sql = $"INSERT INTO ´{tableName}´ ({columns}) VALUES ({values})";
            Console.WriteLine(sql);
        }
        public void Update()
        {
            string tableName = TableName();
            string sets;
            string primaryKey = PKName();
            string primaryKeyValue = PKValue();
            string fieldName;
            string fieldValue;
            List<string> setList = new List<string>();

            foreach (KeyValuePair<string, ORMField> kv in tables[tableName])
            {
                if (primary_keys[tableName] == kv.Value)
                {
                    continue;
                }
                fieldName = kv.Key;
                fieldValue = kv.Value.GetSQLValue(this);
                setList.Add($"{fieldName}={fieldValue}");
            }
            sets = string.Join(',', setList);
            string sql = $"UPDATE {tableName} SET {sets} WHERE {primaryKey}={primaryKeyValue}";
            Console.WriteLine(sql);
        }
        public void Delete()
        {
            string tableName = TableName();
            string primaryKey = PKName();
            string primaryKeyValue = PKValue();
            string sql = $"DELETE FROM {tableName} WHERE {primaryKey}={primaryKeyValue}";
            Console.WriteLine(sql);
        }
        public void Select(string where)
        {

        }
        public string PKName()
        {
            return primary_keys[TableName()].Name;
        }
        public string PKValue()
        {
            return primary_keys[TableName()].GetSQLValue(this);
        }
    }
}
