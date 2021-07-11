using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Models.Services.FileRules
{
	public class UpperCaseRule : FileRule
	{
		public override bool Apply()
		{
			throw new NotImplementedException();
		}

		public UpperCaseRule(FileRule rule)
		{
			this.rule = rule;
		}
	}
}
