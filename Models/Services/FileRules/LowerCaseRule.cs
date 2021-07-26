using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Models.Services.FileRules
{
	public class LowerCaseRule : FileRule
	{
		public override string Apply(string param)
		{
			return param.ToLower();
		}
	}
}
