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
	public class VehicleController : ControllerBase
	{
    private readonly IHttpClientFactory _httpClientFactory;

    public VehicleController(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    [Route("get/{page?}")]
    public async Task<ResponseBase<Vehicle>> GetAll(string page = null)
    {
      var result = new ResponseBase<Vehicle>();
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
          using (var response = await httpClient.GetAsync("vehicles/" + pagination))
          {
            var apiResponse = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<ResponseBase<Vehicle>>(apiResponse);
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
    [Route("getById/{idVehicle?}")]
    public async Task<Vehicle> GetById(string idVehicle)
    {
      var result = new Vehicle();
      try
      {
        using (var httpClient = _httpClientFactory.CreateClient("swapi"))
        {
          using (var response = await httpClient.GetAsync("vehicles/" + idVehicle + "/"))
          {
            var apiResponse = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<Vehicle>(apiResponse);
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
