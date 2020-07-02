# Rate Limit implementation Code Challenge

For this project I use c# ASP.NET MVC to implement the funtionality.<br/>
The project should be able to complie in Visual Studio 2017 or newer.<br/>
I've decided not to use database for data storage for ease of testing and presenting.<br/>

# Rate Limit
My main job is to implement rate-limited API that satisfied these specification without usage of external library.<br/>
c. Both these values have to be easily configurable per endpoint (requests and/or periods), and should
fallback to a default 50 requests every 10 seconds if no configuration is provided.<br/>
d. If the rate gets higher than the threshold on an endpoint, the API should stop responding for 5
seconds on that endpoint ONLY, before allowing other requests.<br/>
e. Your rate limiter should be able to support multiple endpoints in future (not just for 2 endpoints
above).<br/>

So, in order to make rate limiter that can be easily and seperately configure for each endpoint<br/>
I wrote a custom attribute which can be easily apply to any endpoint by adding a line of code to apply attribute to that endpoint and can be specifically configure seperately for each endpoint. And by apply a custom attribute on each endpoint when one endpoint limit is exceeded other endpoints will not be affected.<br/>

This custom attribute can be use by simply put [RateLimit()] on top of any method<br/>
without specify requests and periods the default value will be 50 requests every 10 seconds.<br/>
I can specify those value by passing parameters into [RateLimit()] <br/>
Ex. [RateLimited(Request = 10, Second = 5)]<br/>
I also add a way to specify how long the endpoint will be stopping for<br/>
Ex. [RateLimited(Request = 10, Second = 5, StopFor = 5)]<br/>

So, I can specify how many request per minute I want for each endpoint and how long it should stop responding.<br/>
And also by doing it this way I can even put more than one limit on 1 endpoint for example. I want to endpoint A to be limited to 10 requests every 5 seconds stop for 5 seconds and also limited to 100 requests every 10 minutes stop for 5 minutes I can stack the attribute together.<br/>
Ex.  <img src="https://i.imgur.com/wOTQa2f.png" alt="">

# Testing
Admittedly I cannot find a way to implement working integration test for ASP.NET MVC, the solution which I've found are not up-to-date and overall not well supported.<br/>
So, instead I've implemented a unit test for each endpoint.

# Demonstration
I've written a simple console application that'll demonstrate rate limiter which can be found here: https://github.com/thanabodeeB/RateLimitDemo.<br/>
This console application will make a GET http request in interval that'll be more frequent than the configured limit to induce when the limit is exceeded.<br/>
And you can directly run .exe file in RateLimitDemo/bin/Debug/RateLimitDemo.exe in case the code cannot be compile.<br/>
I've program the hardcode for demo in 3 different ways<br/>
1.Localhost: if you could compile the web project with Visual Studio.<br/>
2.Hosted: that've deployed the web project for demonstration sake or in case you cannot compile the code for some reason.<br/>
3.Custom: for you to input the path and rate of rate limiting.<br/>
I've hosted the website on Azure Web Server for rate limit project here: http://hotelinfo.azurewebsites.net/<br/>
There are 2 endpoints.

[GET]
/hotel/city :string city, string order(optional)<br/>
ex. localhost/hotel/city?city=bangkok or localhost/hotel/city?city=bangkok&order=desc
<br/>Default rate limit is 10 requests every 5 seconds and stop for 5 seconds

[GET]
/hotel/room :string room, string order(optional)<br/>
ex. localhost/hotel/room?room=deluxe or localhost/hotel/room?room=deluxe&order=desc
<br/>Default rate limit is 100 requests every 10 seconds and stop for 5 seconds
