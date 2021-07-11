using FileManager.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Models.Services.FileRules
{
	public abstract class FileRule : IRule
	{
		protected IRule rule;
		public abstract bool Apply();
	}
}
