using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Presentation.Shared
{
	public class People : IEntity
	{
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "height")]
		public string Height { get; set; }

		[JsonProperty(PropertyName = "mass")]
		public string Mass { get; set; }

		[JsonProperty(PropertyName = "hair_color")]
		public string HairColor { get; set; }

		[JsonProperty(PropertyName = "skin_color")]
		public string SkinColor { get; set; }

		[JsonProperty(PropertyName = "eye_color")]
		public string EyeColor { get; set; }

		[JsonProperty(PropertyName = "birth_year")]
		public string BirthYear { get; set; }

		[JsonProperty(PropertyName = "gender")]
		public string Gender { get; set; }

		[JsonProperty(PropertyName = "homeworld")]
		public string Homeworld { get; set; }

		[JsonIgnore]
		public Planet HomePlanet { get; set; }

		[JsonProperty(PropertyName = "films")]
		public List<string> Films { get; set; }

		[JsonProperty(PropertyName = "species")]
		public List<string> Species { get; set; }

		[JsonProperty(PropertyName = "vehicles")]
		public List<string> UrlVehicles { get; set; }

		[JsonIgnore]
		public List<Vehicle> Vehicles { get; set; }

		[JsonProperty(PropertyName = "starships")]
		public List<string> Starships { get; set; }

		[JsonProperty(PropertyName = "created")]
		public DateTime Created { get; set; }

		[JsonProperty(PropertyName = "edited")]
		public DateTime Edited { get; set; }

		[JsonProperty(PropertyName = "url")]
		public string Url { get; set; }
	}
}
