using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Presentation.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Presentation.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PlanetController : ControllerBase
	{
    private readonly IHttpClientFactory _httpClientFactory;

    public PlanetController(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    [Route("get/{page?}")]
    public async Task<ResponseBase<Planet>> Get(string page = null)
    {
      var result = new ResponseBase<Planet>();
      var pagination = "";
      try
      {
        if (page != null)
        {
          if (!page.Equals(string.Empty))
          {
            pagination = "?page=" + page;
          }
        }
        using (var httpClient = _httpClientFactory.CreateClient("swapi"))
        {
          using (var response = await httpClient.GetAsync("planets/" + pagination))
          {
            var apiResponse = await response.Content.ReadAsStringAsync();
            if (apiResponse.Equals(@"{""detail"":""Not found""}"))
            {
              return null;
            }
            result = JsonConvert.DeserializeObject<ResponseBase<Planet>>(apiResponse);
          }
        }
        return result;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    [HttpGet]
    [Route("getById/{idPlanet?}")]
    public async Task<Planet> GetById(string idPlanet)
    {
      var result = new Planet();
      try
      {
        using (var httpClient = _httpClientFactory.CreateClient("swapi"))
        {
          using (var response = await httpClient.GetAsync("planets/" + idPlanet + "/"))
          {
            var apiResponse = await response.Content.ReadAsStringAsync();
            if (apiResponse.Equals(@"{""detail"":""Not found""}"))
            {
              return null;
            }
            result = JsonConvert.DeserializeObject<Planet>(apiResponse);
          }
        }
        return result;
      }
      catch (Exception ex)
      {
        return null;
      }
    }
  }
}
