using GildedRose.Console.BLL.Interfaces;
using GildedRose.Console.BLL.Services;
using GildedRose.Console.Constants;

namespace GildedRose.Console.BLL
{
    public class ServiceFactory
    {
        public IService GetService(ItemType itemType)
        {
            return itemType switch
            {
                ItemType.AgedBrie => new AgedBrieService(),
                ItemType.BackstagePasses => new BackstagePassService(),
                ItemType.Sulfuras => new SulfurasService(),
                ItemType.Conjured => new ConjuredItemService(),
                _ => new NormalItemService(),
            };
        }
    }
}
