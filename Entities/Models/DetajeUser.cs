using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class DetajeUser
    {
        public DetajeUser()
        {
            DokumentaDetajeUsers = new HashSet<DokumentaDetajeUser>();
        }

        public Guid Duid { get; set; }
        public int? GrupiPunes { get; set; }
        public string? PunaCaktuarNeGrup { get; set; }
        public DateTime DataFillim { get; set; }
        public DateTime? DataLargim { get; set; }
        public string? ArsyeLargim { get; set; }
        public byte[] KarteIdentiteti { get; set; } = null!;
        public byte[]? FotoProfili { get; set; }
        public string Adresa { get; set; } = null!;
        public string NumerTelefoni { get; set; } = null!;
        public string? PershkrimiVetes { get; set; }
        public Guid UserId { get; set; }

        public virtual AppUser User { get; set; } = null!;
        public virtual ICollection<DokumentaDetajeUser> DokumentaDetajeUsers { get; set; }
    }
}
