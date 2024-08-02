
using GildedRose.Console.Constants;
using GildedRose.Console.Models;

namespace GildedRose.Console.BLL.Services
{
    public class BackstagePassService : BaseService
    {
        private readonly ItemType _itemType;

        public BackstagePassService(ItemType itemType = ItemType.BackstagePasses)
        {
            _itemType = itemType;
        }

        public override Item UpdateQuality(Item item)
        {
            int newQuality = ImproveQuality(item.Quality, item.SellIn);
            int newSellIn = DecreaseSellIn(item.SellIn);
            if (HasExpired(newSellIn))
            {
                newQuality = 0;
            }
            return new Item(item.Name, newSellIn, newQuality, _itemType);
        }

        protected virtual int ImproveQuality(int quality, int sellIn)
        {
            if (quality >= QualityConstants.Max)
            {
                return quality;
            }

            if (sellIn <= 5)
            {
                return quality + 3;
            }

            if (sellIn <= 10)
            {
                return quality + 2;
            }

            return quality + 1;
        }
    }
}
