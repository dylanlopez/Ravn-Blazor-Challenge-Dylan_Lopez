using Newtonsoft.Json;
using System.Collections.Generic;

namespace Presentation.Shared
{
	public class ResponseBase<T>
	{
		[JsonProperty(PropertyName = "count")]
		public int Count { get; set; }

		[JsonProperty(PropertyName = "next")]
		public string Next { get; set; }

		[JsonProperty(PropertyName = "previous")]
		public string Previous { get; set; }

		[JsonProperty(PropertyName = "results")]
		public List<T> Results { get; set; }
	}
}
