using System;
using System.Collections.Generic;

namespace sln_rencana_bulanan.Models
{
    public partial class Pemasukkan
    {
        public long pem_id { get; set; }
        public string? pem_nama { get; set; }
        public decimal? jumlah { get; set; }
        public string? keterangan { get; set; }
        public string? tahun { get; set; }
        public string? bulan { get; set; }
    }
}
