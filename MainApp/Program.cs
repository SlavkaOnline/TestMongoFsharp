using System;
using Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace MainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("TestFSharp");
            var collection = db.GetCollection<Person>("person");
            
            var conventionPack = new ConventionPack {new CamelCaseElementNameConvention()};
            ConventionRegistry.Register("camelCase", conventionPack, t => true);
            
//            BsonClassMap.RegisterClassMap<Person>(cm =>
//            {
//                cm.AutoMap();
//                cm.MapIdProperty(c => c.Id)
//                    .SetIdGenerator(StringObjectIdGenerator.Instance)
//                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
//            });
            
            var p = new Person( Guid.NewGuid().ToString("N"), "Slava2");
            
            
            
            var rep = new Repository(collection);
            rep.addPerson(p);
            var person = Command.getPersonFromDb(rep);
            
            
            Console.WriteLine(person.Name);
        }
    }
}