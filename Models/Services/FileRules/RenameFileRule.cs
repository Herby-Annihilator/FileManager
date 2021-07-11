using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Models.Services.FileRules
{
	public class RenameFileRule : FileRule
	{
		public override bool Apply()
		{
			throw new NotImplementedException();
		}

		public RenameFileRule(FileRule rule)
		{
			this.rule = rule;
		}
	}
}
