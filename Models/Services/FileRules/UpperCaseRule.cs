﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Models.Services.FileRules
{
	class UpperCaseRule : FileRule
	{
		public UpperCaseRule(FileRule rule)
		{
			this.rule = rule;
		}
		public override string Apply(string param)
		{
			string result = rule.Apply(param);
			return result.ToUpper();
		}
	}
}
