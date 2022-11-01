using DAL.Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    internal class DokumentaDetajeUserRepository : BaseRepository<DokumentaDetajeUser, Guid>, IDokumentaDetajeUserRepository
    {

        public DokumentaDetajeUserRepository(HRDB123Context dbContext) : base(dbContext)
        {
        }




    }


}
