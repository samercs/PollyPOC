using Api.Client.Policy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController(IHttpClientFactory clientFactory, ClientPolicy clientPolicy) : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var client = clientFactory.CreateClient("ServerApi");
            var result = await client.GetAsync("/WeatherForecast");
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadAsStringAsync();
            return Ok(response);
        }

        [HttpGet("get1")]
        public async Task<IActionResult> Get1()
        {
            var client = clientFactory.CreateClient("ServerApi");
            var result = await clientPolicy.ImmediatHttpRetry.ExecuteAsync(() =>  client.GetAsync("/WeatherForecast"));
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadAsStringAsync();
            return Ok(response);
        }

        [HttpGet("get2")]
        public async Task<IActionResult> Get2()
        {
            var client = clientFactory.CreateClient("ServerApi");
            var result = await clientPolicy.LinearHttpRetry.ExecuteAsync(() =>  client.GetAsync("/WeatherForecast"));
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadAsStringAsync();
            return Ok(response);
        }

        [HttpGet("get3")]
        public async Task<IActionResult> Get3()
        {
            var client = clientFactory.CreateClient("ServerApi");
            var result = await clientPolicy.ExponentialHttpRetry.ExecuteAsync(() =>  client.GetAsync("/WeatherForecast"));
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadAsStringAsync();
            return Ok(response);
        }
    }
}
