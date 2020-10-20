using System;
using System.Collections.Generic;
using System.Data;
using System.Security;

namespace ORM_database
{
    class Program
    {
        static void Main(string[] args)
        {
            Item item = new Item();
            item.ItemId = 101;
            item.Title = "Stol";
            item.Description = "Noget man sidde på";
            item.Insert();
            item.Title = "Ægget";
            item.Update();
            item.Delete();
        }
    }
    class Item : ORM
    {
        public const string TABLE_NAME = "items";
        public int ItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
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
            String(TABLE_NAME, "Navn", (orm) => (orm as Item).Title);
            String(TABLE_NAME, "description", (orm) => (orm as Item).Description);
            PrimaryKey(TABLE_NAME, "itemId");
        }
    }
}
