using GildedRose.Console.Constants;
using GildedRose.Console.Models;

namespace GildedRose.Console.BLL.Services
{
    public class AgedBrieService : BaseService
    {
        private readonly ItemType _itemType;

        public AgedBrieService(ItemType itemType = ItemType.AgedBrie)
        {
            _itemType = itemType;
        }

        public override Item UpdateQuality(Item item)
        {
            int newQuality = ImproveQuality(item.Quality);
            int newSellIn = DecreaseSellIn(item.SellIn);
            if (HasExpired(newSellIn))
            {
                newQuality = ImproveQuality(newQuality);
            }
            return new Item(item.Name, newSellIn, newQuality, _itemType);
        }

        protected virtual int ImproveQuality(int quality)
        {
            return quality < QualityConstants.Max ? quality + 1 : quality;
        }
    }
}
