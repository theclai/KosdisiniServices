using System;
using MongoDB.Bson.Serialization;
using KosdisiniServices.Domain.DataModel;

namespace KosdisiniServices.Persistence
{
    public class UserMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<User>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.Id);
              
            });
        }
    }
}
