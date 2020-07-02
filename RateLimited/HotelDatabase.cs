using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RateLimited
{
    public class HotelDatabase
    {
        private List<Hotel> hotel = new List<Hotel>();
        public HotelDatabase()
        {
            hotel.Add(new Hotel { City = "Bangkok", HotelID = 1, Room = "Deluxe", Price = 1000 });
            hotel.Add(new Hotel { City = "Amsterdam", HotelID = 2, Room = "Superior", Price = 2000 });
            hotel.Add(new Hotel { City = "Ashburn", HotelID = 3, Room = "Sweet Suite", Price = 1300 });
            hotel.Add(new Hotel { City = "Amsterdam", HotelID = 4, Room = "Deluxe", Price = 2200 });
            hotel.Add(new Hotel { City = "Ashburn", HotelID = 5, Room = "Sweet Suite", Price = 1200 });
            hotel.Add(new Hotel { City = "Bangkok", HotelID = 6, Room = "Superior", Price = 2000 });
            hotel.Add(new Hotel { City = "Ashburn", HotelID = 7, Room = "Deluxe", Price = 1600 });
            hotel.Add(new Hotel { City = "Bangkok", HotelID = 8, Room = "Superior", Price = 2400 });
            hotel.Add(new Hotel { City = "Amsterdam", HotelID = 9, Room = "Sweet Suite", Price = 30000 });
            hotel.Add(new Hotel { City = "Ashburn", HotelID = 10, Room = "Superior", Price = 1100 });
            hotel.Add(new Hotel { City = "Bangkok", HotelID = 11, Room = "Deluxe", Price = 60 });
            hotel.Add(new Hotel { City = "Ashburn", HotelID = 12, Room = "Deluxe", Price = 1800 });
            hotel.Add(new Hotel { City = "Amsterdam", HotelID = 13, Room = "Superior", Price = 1000 });
            hotel.Add(new Hotel { City = "Bangkok", HotelID = 14, Room = "Sweet Suite", Price = 25000 });
            hotel.Add(new Hotel { City = "Bangkok", HotelID = 15, Room = "Deluxe", Price = 900 });
            hotel.Add(new Hotel { City = "Ashburn", HotelID = 16, Room = "Superior", Price = 800 });
            hotel.Add(new Hotel { City = "Ashburn", HotelID = 17, Room = "Deluxe", Price = 2800 });
            hotel.Add(new Hotel { City = "Bangkok", HotelID = 18, Room = "Sweet Suite", Price = 5300 });
            hotel.Add(new Hotel { City = "Ashburn", HotelID = 19, Room = "Superior", Price = 1000 });
            hotel.Add(new Hotel { City = "Ashburn", HotelID = 20, Room = "Superior", Price = 4444 });
            hotel.Add(new Hotel { City = "Ashburn", HotelID = 21, Room = "Deluxe", Price = 7000 });
            hotel.Add(new Hotel { City = "Ashburn", HotelID = 22, Room = "Sweet Suite", Price = 14000 });
            hotel.Add(new Hotel { City = "Amsterdam", HotelID = 23, Room = "Deluxe", Price = 5000 });
            hotel.Add(new Hotel { City = "Ashburn", HotelID = 24, Room = "Superior", Price = 1400 });
            hotel.Add(new Hotel { City = "Ashburn", HotelID = 25, Room = "Deluxe", Price = 1900 });
            hotel.Add(new Hotel { City = "Amsterdam", HotelID = 26, Room = "Deluxe", Price = 2300 });
        }
        public List<Hotel> GetHotels()
        {
            return hotel;
        }
    }
}

