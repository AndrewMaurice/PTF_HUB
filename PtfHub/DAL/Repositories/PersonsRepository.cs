using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PtfHub.Domain.Entities;

namespace PtfHub.DAL.Repositories
{
    public class PersonsRepository : GenericRepository<Person>
    {
        #region Attributes

        private readonly PTFContext _context;

        #endregion

        #region Constructor

        public PersonsRepository(PTFContext pTFContext) : base(pTFContext)
        {
            _context = pTFContext;
        }

        #endregion

        #region Methods

        public async Task<Person> GetPersonFromDb(Guid personId)
        {
            return await _context.People
                .Include(p => p.Education)
                .ThenInclude(p => p.University)
                .FirstOrDefaultAsync(p => p.Guid == personId);
        }

        #endregion
    }
}
