using System;
using System.Collections.Generic;

namespace sln_rencana_bulanan.Models
{
    public partial class Alokasi_Penghasilan
    {
        public long peng_id { get; set; }
        public string? peng_nama { get; set; }
        public int? peng_persen { get; set; }
        public string? keterangan { get; set; }
        public long? pem_id { get; set; }
    }
}
