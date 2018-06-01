using Domain;
using MongoDB.Driver;

namespace MainApp
{
    public class EntityRepository : IEntityRepository
    {
        private readonly IMongoDatabase _database;

        public EntityRepository(IMongoDatabase database)
        {
            _database = database;
        }


        public void addAnimal(Animal animal)
        {
            var collection = GetCollection<Animal>(nameof(Entity));
            collection.InsertOne(animal);
        }

        public Animal getAnimal(string id)
        {
            var collection = GetCollection<Animal>(nameof(Entity));
            return collection.Find(a => a.Id == id).SingleOrDefault();
        }

        public void addPerson(Person person)
        {
            var collection = GetCollection<Person>(nameof(Entity));
            collection.InsertOne(person);
        }

        public Person getPerson(string id)
        {
            var collection = GetCollection<Person>(nameof(Entity));
            return collection.Find(a => a.Id == id).SingleOrDefault();
        }

        private IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
        
        
    }
}