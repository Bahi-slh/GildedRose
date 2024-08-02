using GildedRose.Console.BLL.Interfaces;
using GildedRose.Console.Models;

namespace GildedRose.Console.BLL.Services
{
    public abstract class BaseService : IService
    {
        public abstract Item UpdateQuality(Item item);

        public virtual bool HasExpired(int sellIn)
        {
            return sellIn < 0;
        }

        public virtual int DecreaseSellIn(int sellIn)
        {
            return sellIn - 1;
        }
    }
}