using System;
using System.Collections.Generic;
using System.Security;

namespace ORM_database
{


    class Program
    {
        static void Main(string[] args)
        {
            Item item = new Item();
            item.Insert();
        }
    }
    class Item : ORM
    {
        public const string TABLE_NAME = "items";
        public int ItemId { get; set; }
        public string Title { get; set; }
        protected override string TableName()
        {
            return TABLE_NAME;
        }
        public Item()
        {
            Console.WriteLine("Hello world");
        }
        static Item()
        {
            Int(TABLE_NAME, "itemId", (orm) => (orm as Item).ItemId);
            String(TABLE_NAME, "itemId", (orm) => (orm as Item).Title);
        }
    
    }
}
