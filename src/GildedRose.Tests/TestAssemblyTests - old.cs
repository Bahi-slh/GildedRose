//using GildedRose.Console;
//using Microsoft.VisualStudio.TestPlatform.TestHost;
//using System.Collections.Generic;
//using Xunit;
//using Program = GildedRose.Console.Program1;

//namespace GildedRose.Tests
//{
//    public class TestAssemblyTests
//    {
//        [Fact]
//        public void UpdateQuality_NormalItem_QualityAndSellInDecrease()
//        {
//            var items = new List<Item> { new Item { Name = "Normal Item", SellIn = 5, Quality = 10 } };
//            var program = new Program { Items = items };
//            program.UpdateQuality();
//            Assert.Equal(9, items[0].Quality);
//            Assert.Equal(4, items[0].SellIn);
//        }

//        [Fact]
//        public void UpdateQuality_ExpiredNormalItem_QualityDegradesTwiceAsFast()
//        {
//            var items = new List<Item> { new Item { Name = "Expired Item", SellIn = 0, Quality = 10 } };
//            var program = new Program { Items = items };
//            program.UpdateQuality();
//            Assert.Equal(8, items[0].Quality);
//            Assert.Equal(-1, items[0].SellIn);
//        }

//        [Fact]
//        public void UpdateQuality_QualityNeverNegative()
//        {
//            var items = new List<Item> { new Item { Name = "Zero Quality Item", SellIn = 5, Quality = 0 } };
//            var program = new Program { Items = items };
//            program.UpdateQuality();
//            Assert.Equal(0, items[0].Quality);
//            Assert.Equal(4, items[0].SellIn);
//        }

//        [Fact]
//        public void UpdateQuality_AgedBrie_IncreasesInQuality()
//        {
//            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 } };
//            var program = new Program { Items = items };
//            program.UpdateQuality();
//            Assert.Equal(11, items[0].Quality);
//            Assert.Equal(4, items[0].SellIn);
//        }

//        [Fact]
//        public void UpdateQuality_QualityNeverMoreThan50()
//        {
//            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 50 } };
//            var program = new Program { Items = items };
//            program.UpdateQuality();
//            Assert.Equal(50, items[0].Quality);
//            Assert.Equal(4, items[0].SellIn);
//        }

//        [Fact]
//        public void UpdateQuality_Sulfuras_NeverChanges()
//        {
//            var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
//            var program = new Program { Items = items };
//            program.UpdateQuality();
//            Assert.Equal(80, items[0].Quality);
//            Assert.Equal(0, items[0].SellIn);
//        }

//        [Fact]
//        public void UpdateQuality_BackstagePasses_IncreasesByOneIfMoreThan10Days()
//        {
//            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 } };
//            var program = new Program { Items = items };
//            program.UpdateQuality();
//            Assert.Equal(21, items[0].Quality);
//            Assert.Equal(14, items[0].SellIn);
//        }

//        [Fact]
//        public void UpdateQuality_BackstagePasses_IncreasesByTwoIf10DaysOrLess()
//        {
//            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 } };
//            var program = new Program { Items = items };
//            program.UpdateQuality();
//            Assert.Equal(22, items[0].Quality);
//            Assert.Equal(9, items[0].SellIn);
//        }

//        [Fact]
//        public void UpdateQuality_BackstagePasses_IncreasesByThreeIf5DaysOrLess()
//        {
//            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 } };
//            var program = new Program { Items = items };
//            program.UpdateQuality();
//            Assert.Equal(23, items[0].Quality);
//            Assert.Equal(4, items[0].SellIn);
//        }

//        [Fact]
//        public void UpdateQuality_BackstagePasses_QualityDropsToZeroAfterConcert()
//        {
//            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 } };
//            var program = new Program { Items = items };
//            program.UpdateQuality();
//            Assert.Equal(0, items[0].Quality);
//            Assert.Equal(-1, items[0].SellIn);
//        }
//    }
//}