using Infraestructure.Data.DbContext;
using Infraestructure.Data.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;
        public Repository(DbContextMongoDB context)
        {
            _collection = context.GetMongoDatabase().GetCollection<T>($"{typeof(T).Name}Collection");
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(FilterDefinition<T>.Empty).ToListAsync();
        }
        public async Task<T?> GetByIdAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }
        public async Task AddAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }
        public async Task UpdateAsync(string id, T entity)
        {
            var filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
            await _collection.ReplaceOneAsync(filter, entity);
        }
        public async Task DeleteAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
            await _collection.DeleteOneAsync(filter);
        }
    }
}
