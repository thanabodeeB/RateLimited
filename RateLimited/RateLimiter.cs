using System;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web;

namespace RateLimited
{

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class RateLimitedAttribute : ActionFilterAttribute
    {
        //Default of 50 requests every 10 seconds if limit is exceeded the respond will be stop for of 5 seconds
        public int Second { get; set; } = 10;
        public int Request { get; set; } = 50;
        public int StopFor { get; set; } = 5;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string key = string.Join(
                "-",
                Second,
                StopFor,
                context.ActionDescriptor.ControllerDescriptor.ControllerName,
                context.ActionDescriptor.ActionName
            );

            int current = 1;
            if (HttpRuntime.Cache[key] != null)
            {
                Temp t = HttpRuntime.Cache[key] as Temp;

                current = t.Current + 1;

                if (current > Request)
                {
                    HttpRuntime.Cache.Insert(
                            key,
                            new Temp(0, t.Expiration),
                            null,
                            DateTime.UtcNow.AddSeconds(StopFor),
                            Cache.NoSlidingExpiration,
                            CacheItemPriority.Low,
                            null
                        );

                    context.Result = new ContentResult
                    {
                        Content = "Rate limit exceeded."
                    };
                    context.HttpContext.Response.StatusCode = 429;
                }
                else if (t.Current == 0)
                {
                    context.Result = new ContentResult
                    {
                        Content = "Rate limit exceeded."
                    };
                    context.HttpContext.Response.StatusCode = 429;
                }
                else
                {
                    t.Current++;
                    HttpRuntime.Cache.Insert(
                       key,
                       t,
                       null,
                       t.Expiration,
                       Cache.NoSlidingExpiration,
                       CacheItemPriority.Low,
                       null
                   );
                }
            }
            else
            {
                DateTime expiration = DateTime.UtcNow.AddSeconds(Second);
                HttpRuntime.Cache.Insert(
                        key,
                        new Temp(1, expiration),
                        null,
                        expiration,
                        Cache.NoSlidingExpiration,
                        CacheItemPriority.Low,
                        null
                    );
            }
        }

        private class Temp
        {
            public int Current { get; set; }
            public DateTime Expiration { get; set; }

            public Temp(int current, DateTime expiration)
            {
                Current = current;
                Expiration = expiration;
            }
        }
    }

}