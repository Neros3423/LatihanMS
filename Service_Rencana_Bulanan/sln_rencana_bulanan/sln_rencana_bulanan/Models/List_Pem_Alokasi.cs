using System;
using System.Collections.Generic;

namespace sln_rencana_bulanan.Models
{
    public partial class List_Pem_Alokasi
    {
        public long? peng_id { get; set; }
        public string? peng_nama { get; set; }
        public int? peng_persen { get; set; }
        public string? keterangan { get; set; }
        public long? pem_id { get; set; }
        public string? pem_nama { get; set; }
        public decimal? jumlah { get; set; }
        public string? pem_ket { get; set; }
        public string? tahun { get; set; }
        public string? bulan { get; set; }
    }
}
