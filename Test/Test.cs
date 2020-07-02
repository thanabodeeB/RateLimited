using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RateLimited;
using RateLimited.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Test
{

    [TestClass]
    public class TestClass
    {
        [TestMethod]
        public void TestHotelByCity()
        {
            //arrage
            HotelController hotelController = new HotelController();
            List<Hotel> hotels = new HotelDatabase().GetHotels();
            hotels = (from h in hotels where string.Equals(h.City, "bangkok", StringComparison.CurrentCultureIgnoreCase) select h).ToList();
            //act
            var result = hotelController.GetHotelbyCity("bangkok");
            List<Hotel> resultHotels = JsonConvert.DeserializeObject<List<Hotel>>(JsonConvert.SerializeObject(result.Data));
            //assert
            Assert.AreEqual(hotels.Count, resultHotels.Count);
        }

        [TestMethod]
        public void TestHotelByRoom()
        {
            //arrage
            HotelController hotelController = new HotelController();
            List<Hotel> hotels = new HotelDatabase().GetHotels();
            hotels = (from h in hotels where string.Equals(h.Room, "deluxe", StringComparison.CurrentCultureIgnoreCase) select h).ToList();

            //act
            var result = hotelController.GetHotelbyRoom("deluxe");
            List<Hotel> resultHotels = JsonConvert.DeserializeObject<List<Hotel>>(JsonConvert.SerializeObject(result.Data));
         
            //assert
            Assert.AreEqual(hotels.Count, resultHotels.Count);
        }

    }

}
