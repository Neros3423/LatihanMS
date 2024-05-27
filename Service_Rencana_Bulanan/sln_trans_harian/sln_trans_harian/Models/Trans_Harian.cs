using System;
using System.Collections.Generic;

namespace sln_trans_harian.Models
{
    public partial class Trans_Harian
    {
        public long trans_id { get; set; }
        public long? keb_det_id { get; set; }
        public long? peng_id { get; set; }
        public decimal? jumlah { get; set; }
        public string? keterangan { get; set; }
        public string? tahun { get; set; }
        public string? bulan { get; set; }
    }
}
