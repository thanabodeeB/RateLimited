using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RateLimited.Controllers
{
    [Route("api/[controller]")]
    public class HotelController : Controller
    {
        public ActionResult Index()
        {
            return null;
        }

        [ActionName("city")]                                  // change endpoint from /gethotelbycity to /city
        [HttpGet]                                             // Restrict to HTTP GET requests
        [RateLimited(Request = 10, Second = 5, StopFor = 5)]  // 10 requests every 5 seconds
        public JsonResult GetHotelbyCity(string city, string order = "")
        {
            List<Hotel> hdb = new HotelDatabase().GetHotels();
            List<Hotel> hotels = new List<Hotel>();
            if (order != "")
            {
                if (order == "desc")
                {
                    hotels = (from h in hdb where string.Equals(h.City, city, StringComparison.CurrentCultureIgnoreCase) orderby h.Price descending select h).ToList();
                }
                else
                {
                    hotels = (from h in hdb where string.Equals(h.City, city, StringComparison.CurrentCultureIgnoreCase) orderby h.Price ascending select h).ToList();
                }
            }
            else
            {
                hotels = (from h in hdb where string.Equals(h.City, city, StringComparison.CurrentCultureIgnoreCase) select h).ToList();
            }
            return JsonSerialize(hotels);
        }


        [ActionName("room")]                                    // change endpoint from /gethotelbyroom to /room
        [HttpGet]                                               // Restrict to HTTP GET requests
        [RateLimited(Request = 100, Second = 10, StopFor = 5)]  // 100 requests every 10 seconds
        public JsonResult GetHotelbyRoom(string room, string order = "")
        {
            List<Hotel> hdb = new HotelDatabase().GetHotels();
            List<Hotel> hotels = new List<Hotel>();

            if (order != "")
            {
                if (order == "desc")
                {
                    hotels = (from h in hdb where string.Equals(h.Room, room, StringComparison.CurrentCultureIgnoreCase) orderby h.Price ascending select h).ToList();
                }
                else
                {
                    hotels = (from h in hdb where string.Equals(h.Room, room, StringComparison.CurrentCultureIgnoreCase) orderby h.Price descending select h).ToList();
                }
            }
            else
            {
                hotels = (from h in hdb where string.Equals(h.Room, room, StringComparison.CurrentCultureIgnoreCase) select h).ToList();
            }

            return JsonSerialize(hotels);
        }

        private JsonResult JsonSerialize(object obj)
        {
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}