using Infraestructure.Configuration;
using Infraestructure.Services.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data.DbContext
{
    public class DbContextMongoDB
    {
        //public IMongoCollection<Post> _postCollection;
        public readonly MongoDBSettings _mongoDBSettings;


        public DbContextMongoDB(IAppSettingsService appSettings)
        {
            _mongoDBSettings = appSettings.GetMongoDBSettings();
        }
        public IMongoDatabase GetMongoDatabase()
        {
            return new MongoClient(_mongoDBSettings.ConnectionString).GetDatabase(_mongoDBSettings.DatabaseName);
        }
    }
}
