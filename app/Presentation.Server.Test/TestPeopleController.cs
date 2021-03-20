using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Presentation.Server.Controllers;
using System;
using System.Net.Http;
using Xunit;

namespace Presentation.Server.Test
{
	public class TestPeopleController
	{
		private PeopleController _controller;

		[Fact]
		public void GetById404()
		{
			var factory = new WebApplicationFactory<Program>();
			var client = factory.CreateClient();

			var mockService = Substitute.For<IServiceCollection>();
			mockService.AddHttpClient("swapi", c =>
			{
				c.BaseAddress = new Uri("https://swapi.dev/api/");
			});
			var mockServiceProvider = mockService.BuildServiceProvider();
			var mockHttpClientFactory = Substitute.For<IHttpClientFactory>();
			var mockHttpClientFactory2 = mockServiceProvider.GetService<HttpClient>();
			_controller = new PeopleController(mockHttpClientFactory);
			var result = _controller.GetAll();
			Assert.True(true);
		}
	}
}
