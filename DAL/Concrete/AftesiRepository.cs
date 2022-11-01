using Entities.Models;
using DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    internal class AftesiRepository : BaseRepository<Aftesi, Guid>, IAftesiRepository
    {

        public AftesiRepository( HRDB123Context dbContext) : base(dbContext)
        {
        }

    }

}
