using GildedRose.Console.Constants;
using GildedRose.Console.Models;
using System.Collections.Generic;

namespace GildedRose.Console.BLL
{
    public class InventoryManager
    {
        private readonly ServiceFactory _serviceFactory;

        public InventoryManager()
        {
            _serviceFactory = new ServiceFactory();
        }

        public void UpdateQuality(IList<Item> items)
        {
            foreach (var item in items)
            {
                var itemType = GetItemType(item.Name);
                var service = _serviceFactory.GetService(itemType);
                var updatedItem = service.UpdateQuality(item);
                item.SellIn = updatedItem.SellIn;
                item.Quality = updatedItem.Quality;
            }
        }

        private ItemType GetItemType(string name)
        {
            if (name.Contains("Aged Brie"))
            {
                return ItemType.AgedBrie;
            }
            if (name.Contains("Backstage passes"))
            {
                return ItemType.BackstagePasses;
            }
            if (name.Contains("Sulfuras"))
            {
                return ItemType.Sulfuras;
            }
            if (name.Contains("Conjured"))
            {
                return ItemType.Conjured;
            }
            return ItemType.Normal;
        }
    }
}
