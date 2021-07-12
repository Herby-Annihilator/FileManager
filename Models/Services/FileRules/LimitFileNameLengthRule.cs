using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Models.Services.FileRules
{
	public class LimitFileNameLengthRule : FileRule
	{
		private int _length;
		public LimitFileNameLengthRule(FileRule rule, int length)
		{
			this.rule = rule;
			_length = length;
		}
		public override string Apply(string param)
		{
			string result = rule.Apply(param);
			int legalLen;
			if (_length < 1 || _length > result.Length)
				legalLen = result.Length;
			else
				legalLen = _length;
			return result.Substring(0, legalLen);
		}
	}
}
