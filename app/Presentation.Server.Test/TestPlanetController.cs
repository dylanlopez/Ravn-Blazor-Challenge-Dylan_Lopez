using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Presentation.Server.Controllers;
using Presentation.Shared;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Presentation.Server.Test
{
	public class TestPlanetController
	{
		private PlanetController _controller;
		private IHttpClientFactory _mockHttpClientFactory;

		public TestPlanetController()
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", true, true)
				.AddEnvironmentVariables();
			var configuration = builder.Build();
			var services = new ServiceCollection();
			var starup = new Startup(configuration);
			services.AddSingleton(Mock.Of<IWebHostEnvironment>(w =>
				w.ApplicationName == "Presentation.Server" &&
				w.EnvironmentName == "Development"
			));
			services.AddHttpClient("swapi", c =>
			{
				c.BaseAddress = new Uri("https://swapi.dev/api/");
			});
			starup.ConfigureServices(services);
			_mockHttpClientFactory = services.BuildServiceProvider().GetService<IHttpClientFactory>();
		}

		[Fact]
		public async Task GetOk()
		{
			//Arrange
			var responseBase = new ResponseBase<Planet>() { Count = 60, Next = "http://swapi.dev/api/planets/?page=2", Previous = null };
			//Act
			_controller = new PlanetController(_mockHttpClientFactory);
			var result = await _controller.Get();
			//Assert
			result.Should().NotBeNull();
			result.Count.Should().Equals(responseBase.Count);
			result.Next.Should().Equals(responseBase.Next);
			result.Previous.Should().Equals(responseBase.Previous);
		}

		[Fact]
		public async Task GetNotExists()
		{
			//Arrange

			//Act
			_controller = new PlanetController(_mockHttpClientFactory);
			var result = await _controller.Get("9");
			//Assert
			result.Should().BeNull();
		}

		[Fact]
		public async Task GetByIdOk()
		{
			//Arrange
			var planet = new Planet() { Name = "Tatooine", Url = "http://swapi.dev/api/planets/1/" };
			//Act
			_controller = new PlanetController(_mockHttpClientFactory);
			var result = await _controller.GetById("1");
			//Assert
			result.Should().NotBeNull();
			result.Name.Should().Equals(planet.Name);
			result.Url.Should().Equals(planet.Url);
		}

		[Fact]
		public async Task GetByIdNotExists()
		{
			//Arrange

			//Act
			_controller = new PlanetController(_mockHttpClientFactory);
			var result = await _controller.GetById("99");
			//Assert
			result.Should().BeNull();
		}
	}
}
