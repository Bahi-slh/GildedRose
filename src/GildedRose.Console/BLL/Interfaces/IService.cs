using GildedRose.Console.Models;

namespace GildedRose.Console.BLL.Interfaces
{
    public interface IService
    {
        Item UpdateQuality(Item item);
        bool HasExpired(int sellIn);
        int DecreaseSellIn(int sellIn);
    }
}
