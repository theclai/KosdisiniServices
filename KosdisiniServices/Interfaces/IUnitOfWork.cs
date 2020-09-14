using System;
using System.Threading.Tasks;

namespace KosdisiniServices.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
