using Domain;
using MongoDB.Driver;

namespace MainApp
{
    public class Repository: IRepository
    {
        public Person getPerson => _collections.Find(_ => true).SingleOrDefault();
        public void addPerson(Person person)
        {
            _collections.InsertOne(person);
        }

        private readonly IMongoCollection<Person> _collections;

        public Repository(IMongoCollection<Person> collections)
        {
            _collections = collections;
        }
        
    }
}