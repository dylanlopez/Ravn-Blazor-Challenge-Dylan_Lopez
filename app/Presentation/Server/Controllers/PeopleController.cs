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
	public class PeopleController : ControllerBase
	{
    private readonly IHttpClientFactory _httpClientFactory;

    public PeopleController(IHttpClientFactory httpClientFactory)
		{
      _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    [Route("get/{page?}")]
    public async Task<ResponseBase<People>> Get(string page = null)
    {
      var result = new ResponseBase<People>();
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
          using (var response = await httpClient.GetAsync("people/" + pagination))
          {
            var apiResponse = await response.Content.ReadAsStringAsync();
            if (apiResponse.Equals(@"{""detail"":""Not found""}"))
            {
              return null;
            }
            result = JsonConvert.DeserializeObject<ResponseBase<People>>(apiResponse);
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
    [Route("getById/{idPeople?}")]
    public async Task<People> GetById(string idPeople)
    {
      var result = new People();
      try
      {
        using (var httpClient = _httpClientFactory.CreateClient("swapi"))
        {
          using (var response = await httpClient.GetAsync("people/" + idPeople + "/"))
          {
            var apiResponse = await response.Content.ReadAsStringAsync();
            if (apiResponse.Equals(@"{""detail"":""Not found""}"))
            {
              return null;
						}
            result = JsonConvert.DeserializeObject<People>(apiResponse);
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
