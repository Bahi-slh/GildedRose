
using GildedRose.Console.Constants;
using GildedRose.Console.Models;

namespace GildedRose.Console.BLL.Services
{
    public class SulfurasService : BaseService
    {
        private readonly ItemType _itemType;

        public SulfurasService(ItemType itemType = ItemType.Sulfuras)
        {
            _itemType = itemType;
        }

        public override Item UpdateQuality(Item item)
        {
            return new Item(item.Name, item.SellIn, QualityConstants.Legendary, _itemType);
        }
    }
}
