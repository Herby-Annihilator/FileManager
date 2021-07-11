using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Models.Data
{
	public class FileNames
	{
		public string Name { get; set; }
		public string Location { get; set; }

		public FileNames(string name, string location)
		{
			Name = name;
			Location = location;
		}
	}
}
