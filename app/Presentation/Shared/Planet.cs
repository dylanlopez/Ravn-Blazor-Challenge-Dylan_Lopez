using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Presentation.Shared
{
	public class Planet : IEntity
	{
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "rotation_period")]
		public string RotationPeriod { get; set; }

		[JsonProperty(PropertyName = "orbital_period")]
		public string OrbitalPeriod { get; set; }

		[JsonProperty(PropertyName = "diameter")]
		public string Diameter { get; set; }

		[JsonProperty(PropertyName = "climate")]
		public string Climate { get; set; }

		[JsonProperty(PropertyName = "gravity")]
		public string Gravity { get; set; }

		[JsonProperty(PropertyName = "terrain")]
		public string Terrain { get; set; }

		[JsonProperty(PropertyName = "surface_water")]
		public string SurfaceWater { get; set; }

		[JsonProperty(PropertyName = "population")]
		public string Population { get; set; }

		[JsonProperty(PropertyName = "residents")]
		public List<string> Residents { get; set; }

		[JsonProperty(PropertyName = "films")]
		public List<string> Films { get; set; }

		[JsonProperty(PropertyName = "created")]
		public DateTime Created { get; set; }

		[JsonProperty(PropertyName = "edited")]
		public DateTime Edited { get; set; }

		[JsonProperty(PropertyName = "url")]
		public string Url { get; set; }
	}
}
