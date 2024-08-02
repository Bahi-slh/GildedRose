using GildedRose.Console;
using GildedRose.Console.Constants;
using GildedRose.Console.Models;
using System.Collections.Generic;
using Xunit;
using Program = GildedRose.Console.Program;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        [Fact]
        public void UpdateQuality_NormalItem_QualityAndSellInDecrease()
        {
            var items = new List<Item> { new Item("Normal Item", 5, 10, ItemType.Normal) };
            var program = new Program { Items = items };
            program.UpdateQuality();
            Assert.Equal(9, items[0].Quality);
            Assert.Equal(4, items[0].SellIn);
        }

        [Fact]
        public void UpdateQuality_ExpiredNormalItem_QualityDegradesTwiceAsFast()
        {
            var items = new List<Item> { new Item("Expired Item", 0, 10, ItemType.Normal) };
            var program = new Program { Items = items };
            program.UpdateQuality();
            Assert.Equal(8, items[0].Quality);
            Assert.Equal(-1, items[0].SellIn);
        }

        [Fact]
        public void UpdateQuality_QualityNeverNegative()
        {
            var items = new List<Item> { new Item("Zero Quality Item", 5, 0, ItemType.Normal) };
            var program = new Program { Items = items };
            program.UpdateQuality();
            Assert.Equal(0, items[0].Quality);
            Assert.Equal(4, items[0].SellIn);
        }

        [Fact]
        public void UpdateQuality_AgedBrie_IncreasesInQuality()
        {
            var items = new List<Item> { new Item("Aged Brie", 5, 10, ItemType.AgedBrie) };
            var program = new Program { Items = items };
            program.UpdateQuality();
            Assert.Equal(11, items[0].Quality);
            Assert.Equal(4, items[0].SellIn);
        }

        [Fact]
        public void UpdateQuality_QualityNeverMoreThan50()
        {
            var items = new List<Item> { new Item("Aged Brie", 5, 50, ItemType.AgedBrie) };
            var program = new Program { Items = items };
            program.UpdateQuality();
            Assert.Equal(50, items[0].Quality);
            Assert.Equal(4, items[0].SellIn);
        }

        [Fact]
        public void UpdateQuality_Sulfuras_NeverChanges()
        {
            var items = new List<Item> { new Item("Sulfuras, Hand of Ragnaros", 0, 80, ItemType.Sulfuras) };
            var program = new Program { Items = items };
            program.UpdateQuality();
            Assert.Equal(80, items[0].Quality);
            Assert.Equal(0, items[0].SellIn);
        }

        [Fact]
        public void UpdateQuality_BackstagePasses_IncreasesByOneIfMoreThan10Days()
        {
            var items = new List<Item> { new Item("Backstage passes to a TAFKAL80ETC concert", 15, 20, ItemType.BackstagePasses) };
            var program = new Program { Items = items };
            program.UpdateQuality();
            Assert.Equal(21, items[0].Quality);
            Assert.Equal(14, items[0].SellIn);
        }

        [Fact]
        public void UpdateQuality_BackstagePasses_IncreasesByTwoIf10DaysOrLess()
        {
            var items = new List<Item> { new Item("Backstage passes to a TAFKAL80ETC concert", 10, 20, ItemType.BackstagePasses) };
            var program = new Program { Items = items };
            program.UpdateQuality();
            Assert.Equal(22, items[0].Quality);
            Assert.Equal(9, items[0].SellIn);
        }

        [Fact]
        public void UpdateQuality_BackstagePasses_IncreasesByThreeIf5DaysOrLess()
        {
            var items = new List<Item> { new Item("Backstage passes to a TAFKAL80ETC concert", 5, 20, ItemType.BackstagePasses) };
            var program = new Program { Items = items };
            program.UpdateQuality();
            Assert.Equal(23, items[0].Quality);
            Assert.Equal(4, items[0].SellIn);
        }

        [Fact]
        public void UpdateQuality_BackstagePasses_QualityDropsToZeroAfterConcert()
        {
            var items = new List<Item> { new Item("Backstage passes to a TAFKAL80ETC concert", 0, 20, ItemType.BackstagePasses) };
            var program = new Program { Items = items };
            program.UpdateQuality();
            Assert.Equal(0, items[0].Quality);
            Assert.Equal(-1, items[0].SellIn);
        }

        [Fact]
        public void UpdateQuality_ConjuredItem_QualityDegradesTwiceAsFast()
        {
            var items = new List<Item> { new Item("Conjured Mana Cake", 3, 6, ItemType.Conjured) };
            var program = new Program { Items = items };
            program.UpdateQuality();
            Assert.Equal(4, items[0].Quality);
            Assert.Equal(2, items[0].SellIn);
        }
    }
}
