using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Presentation.Shared
{
	public class Vehicle : IEntity
	{
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "model")]
		public string Model { get; set; }

		[JsonProperty(PropertyName = "manufacturer")]
		public string Manufacturer { get; set; }

		[JsonProperty(PropertyName = "cost_in_credits")]
		public string CostInCredits { get; set; }

		[JsonProperty(PropertyName = "length")]
		public string Length { get; set; }

		[JsonProperty(PropertyName = "max_atmosphering_speed")]
		public string MaxAtmospheringSpeed { get; set; }

		[JsonProperty(PropertyName = "crew")]
		public string Crew { get; set; }

		[JsonProperty(PropertyName = "passengers")]
		public string Passengers { get; set; }

		[JsonProperty(PropertyName = "cargo_capacity")]
		public string CargoCapacity { get; set; }

		[JsonProperty(PropertyName = "consumables")]
		public string Consumables { get; set; }

		[JsonProperty(PropertyName = "vehicle_class")]
		public string VehicleClass { get; set; }

		[JsonProperty(PropertyName = "pilots")]
		public List<string> Pilots { get; set; }

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
