﻿using FileManager.Models.Services.Executors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Models.Services
{
	public static class ServicesRegistrator
	{
		public static IServiceCollection AddServices(this IServiceCollection services) => services.AddSingleton<FileRuleExecutor>()
		// Register your services here
		;
	}
}
