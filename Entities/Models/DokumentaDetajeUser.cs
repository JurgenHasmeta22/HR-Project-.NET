using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class DokumentaDetajeUser
    {
        public Guid DokumentId { get; set; }
        public Guid Duid { get; set; }
        public byte[] Dokument { get; set; } = null!;

        public virtual DetajeUser Du { get; set; } = null!;
    }
}
