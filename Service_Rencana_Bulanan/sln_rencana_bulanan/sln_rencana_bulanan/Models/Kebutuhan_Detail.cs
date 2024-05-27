using System;
using System.Collections.Generic;

namespace sln_rencana_bulanan.Models
{
    public partial class Kebutuhan_Detail
    {
        public long keb_det_id { get; set; }
        public long keb_id { get; set; }
        public string? keb_det_nama { get; set; }
        public string? status { get; set; }
    }
}
