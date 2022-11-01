using DAL.Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    internal class EdukimRepository:BaseRepository<Edukim,Guid>,IEdukimRepository
    {
        public EdukimRepository(HRDB123Context dbContext) : base(dbContext)
        { }
            public Edukim GetById1(Guid id)
            {
                var Edukim = context.Include(x => x.UserEdukims).ThenInclude(x => x.User).Where(x => x.EduId == id).FirstOrDefault();
                return Edukim;
            }

        
    }
}
