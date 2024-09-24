using Infraestructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Services.Interfaces
{
    public interface IAppSettingsService
    {
        CORSSettings GetCORSSettings();
        MongoDBSettings GetMongoDBSettings();
    }
}
