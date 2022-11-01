using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.UserDTO
{
    public  class CertifikateDTO
    {
        public Guid CertId { get; set; }
        public string CertEmri { get; set; } = null!;
        public string CertPershkrim { get; set; } = null!;
    }
}
