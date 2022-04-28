using System;
using System.Threading.Tasks;

namespace PtfHub.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
