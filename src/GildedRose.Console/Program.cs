using GildedRose.Console.BLL;
using GildedRose.Console.Constants;
using GildedRose.Console.Models;
using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;

        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item("+5 Dexterity Vest", 10, 20, ItemType.Normal),
                    new Item("Aged Brie", 2, 0, ItemType.AgedBrie),
                    new Item("Elixir of the Mongoose", 5, 7, ItemType.Normal),
                    new Item("Sulfuras, Hand of Ragnaros", 0, 80, ItemType.Sulfuras),
                    new Item("Backstage passes to a TAFKAL80ETC concert", 15, 20, ItemType.BackstagePasses),
                    new Item("Conjured Mana Cake", 3, 6, ItemType.Conjured)
                }
            };

            app.UpdateQuality();

            System.Console.ReadKey();
        }

        public void UpdateQuality()
        {
            var inventoryManager = new InventoryManager();
            inventoryManager.UpdateQuality(Items);
        }
    }
}
