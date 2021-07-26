using FileManager.Models.Services.FileRules;
using FileManager.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Models.Services.Executors
{
	public class FileRuleExecutor : IRuleExecutor<string>
	{
		public FileRuleExecutor()
		{
			rules = new List<IRule<string>>();
		}
		protected List<IRule<string>> rules;

		public bool Add(IRule<string> rule)
		{
			if (rules.Contains(rule))
				return false;
			rules.Add(rule);
			return true;
		}

		public bool Remove(IRule<string> rule)
		{
			if (!rules.Contains(rule))
				return false;
			rules.Remove(rule);
			return true;
		}

		public string Invoke(string param)
		{
			string result = param;
			foreach (var rule in rules)
			{
				rule.Apply(result);
			}
			return result;
		}
	}
}
