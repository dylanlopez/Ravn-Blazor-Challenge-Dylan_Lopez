using System;

namespace Presentation.Shared
{
	public interface IEntity 
	{
		string Name { get; set; }
		DateTime Created { get; set; }
		DateTime Edited { get; set; }
		string Url { get; set; }
	}
}
