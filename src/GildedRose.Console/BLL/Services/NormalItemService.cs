using GildedRose.Console.Constants;
using GildedRose.Console.Models;

namespace GildedRose.Console.BLL.Services
{
    public class NormalItemService : BaseService
    {
        private readonly ItemType _itemType;

        public NormalItemService(ItemType itemType = ItemType.Normal)
        {
            _itemType = itemType;
        }

        public override Item UpdateQuality(Item item)
        {
            int newQuality = DegradeQuality(item.Quality);
            int newSellIn = DecreaseSellIn(item.SellIn);
            if (HasExpired(newSellIn))
            {
                newQuality = DegradeQuality(newQuality);
            }
            return new Item(item.Name, newSellIn, newQuality, _itemType);
        }

        protected virtual int DegradeQuality(int quality)
        {
            return quality > QualityConstants.Min ? quality - 1 : quality;
        }
    }
}