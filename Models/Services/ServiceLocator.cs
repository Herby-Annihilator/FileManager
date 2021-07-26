using FileManager.Models.Services.Executors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Models.Services
{
	public class ServiceLocator
	{
		public FileRuleExecutor FileRuleExecutor => App.Services.GetRequiredService<FileRuleExecutor>();
		
	}
}
