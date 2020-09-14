using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using KosdisiniServices.Domain.DataModel;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace KosdisiniServices.Persistence
{
    public static class MongoDbPersistence
    {
        public static void Configure()
        {
            UserMap.Configure();

            // Set Guid to CSharp style (with dash -)
            //BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

            // Conventions
            var pack = new ConventionPack
                {
                    new IgnoreExtraElementsConvention(true),
                    new IgnoreIfDefaultConvention(true)
                };
            ConventionRegistry.Register("Kos disini Conventions", pack, t => true);
        }
    }
}
