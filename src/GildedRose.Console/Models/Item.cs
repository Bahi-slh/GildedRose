using GildedRose.Console.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.Models
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public ItemType Type { get; set; }
        public Item(string name, int sellIn, int quality, ItemType type)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
            Type = type;   
        }
    }
}
