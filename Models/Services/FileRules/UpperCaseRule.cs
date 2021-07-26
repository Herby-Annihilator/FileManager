using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Models.Services.FileRules
{
	class UpperCaseRule : FileRule
	{
		public override string Apply(string param)
		{
			return param.ToUpper();
		}
	}
}
