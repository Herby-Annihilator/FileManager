using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Models.Services.Interfaces
{
	public interface IRule<T>
	{
		T Apply(T param);

		int Priority { get; set; }
	}
}
