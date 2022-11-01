using DAL.Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    internal class LejeRepository : BaseRepository<Leje, Guid>, ILejeRepository
    {
        public LejeRepository(HRDB123Context dbContext) : base(dbContext)
        {

        }
        public IEnumerable<Leje> GetAllLeje()
        {
            return context.Include(x => x.User).Where(x => x.Aprovuar == 2).AsEnumerable();
        }

    }
}
