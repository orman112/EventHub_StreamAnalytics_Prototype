using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventHub_StreamAnalytics_Prototype
{
    public static partial class Functions
    {
        private static readonly object _lock = new object();
        private static bool _initialized = false;
        private static IConfiguration _configuration;

        private static IConfiguration Initialize(ExecutionContext executionContext)
        {
            if (!_initialized)
            {
                lock (_lock)
                {
                    //ensure only initialized once
                    if (_configuration == null)
                    {
                        _configuration = new ConfigurationBuilder()
                            .SetBasePath(executionContext.FunctionAppDirectory)
                            .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                            .AddEnvironmentVariables()
                            .Build();

                        _initialized = true;
                    }
                }
            }

            return _configuration;
        }
    }
}
