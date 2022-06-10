using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Microsoft.OpenApi.Writers;

namespace CoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize(Roles = "Developers")]
    //[RequiredScope(new string[] { "AAccess.All" })]
    public class WeatherForecastController : ControllerBase
    {
        static readonly string[] scopeRequiredByApi = new string[] { "Access.All" };

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        //[Authorize]
        //[Authorize(Roles = "Administrator,SuperAdmin")]
        //[Authorize(Roles = "Developers")]
        //[Authorize("Access.All")]
        //[RequiredScope("Access.Alsl")]
        //[Authorize("RolePolicy")]
        [Authorize("ScopePolicy")]
        [Authorize("RolePolicy")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}