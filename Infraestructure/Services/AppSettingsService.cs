using Infraestructure.Configuration;
using Infraestructure.Services.Interfaces;
using Infraestructure.Settings;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Services
{
    public class AppSettingsService : IAppSettingsService
    {
        private readonly IConfiguration _configuration;
        private readonly string _thisPath = AppDirectories.ConfigurationDirectory;

        public AppSettingsService()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(_thisPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }
        public MongoDBSettings GetMongoDBSettings()
        {
            var mongoDBSettings = new MongoDBSettings();
            _configuration.GetSection("MongoDBSettings").Bind(mongoDBSettings);
            return mongoDBSettings;
        }
        public CORSSettings GetCORSSettings()
        {
            var corsSettings = new CORSSettings();
            _configuration.GetSection("CORSSettings").Bind(corsSettings);
            return corsSettings;
        }
    }
}
