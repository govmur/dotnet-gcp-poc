using Microsoft.AspNetCore.Mvc;

namespace HelloWorldRestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {
        //sampe update to trigger push
        private static readonly string[] Summaries = new[]
        {
        "Good Morning", "Good Afternoon", "Good Evening","Good Night","Good Day"
    };

        private readonly ILogger<HelloWorldController> _logger;

        public HelloWorldController(ILogger<HelloWorldController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetGreeting")]
        public HelloWorld Get()
        {
            var greeting = new HelloWorld();
            var currentTime = DateTime.Now.TimeOfDay.Hours;
            var greetingText = string.Empty;
            if (currentTime < 12)
                greetingText = Summaries[0];
            else if (currentTime >= 12 && currentTime < 15)
                greetingText = Summaries[1];
            else if (currentTime >= 15 && currentTime < 20)
                greetingText = Summaries[2];
            else if (currentTime >= 20 && currentTime < 24)
                greetingText = Summaries[3];
            else
                greetingText = Summaries[4];

            greeting.Message = greetingText + ", Welcome to One Report GCP PoC!";
            greeting.Date = DateTime.Now;
            greeting.Hour = currentTime;
           
            return greeting;
        }
    }
}
