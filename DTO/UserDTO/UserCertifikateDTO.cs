using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace DTO.UserDTO
{
    public class UserCertifikateDTO
    {
        public DateTime DataFituar { get; set; }
        public DateTime DataSkadence { get; set; }
        public byte[] DokumentCertifikate { get; set; } = null!;
        public Guid UserId { get; set; }
        public Guid CertId { get; set; }

        public virtual CertifikateDTO Cert { get; set; } = null!;
    }
}
