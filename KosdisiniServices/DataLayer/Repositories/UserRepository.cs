using System;
using KosdisiniServices.Core;
using KosdisiniServices.Domain.DataModel;
using KosdisiniServices.Interfaces;

namespace KosdisiniServices.DataLayer.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IMongoDbContext context) : base(context)
        {
        }
    }
}
