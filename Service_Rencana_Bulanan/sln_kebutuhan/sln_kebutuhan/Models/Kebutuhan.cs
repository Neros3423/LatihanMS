using System;
using System.Collections.Generic;

namespace sln_kebutuhan.Models
{
    public partial class Kebutuhan
    {
        public long keb_id { get; set; }
        public string? keb_nama { get; set; }
        public string? keterangan { get; set; }
    }
}
