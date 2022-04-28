using System;
using System.Threading.Tasks;
using PtfHub.Domain.Entities;

namespace PtfHub.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Attributes

        private readonly PTFContext _context;

        #endregion

        #region Constructor

        public UnitOfWork(PTFContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        #endregion
    }
}
