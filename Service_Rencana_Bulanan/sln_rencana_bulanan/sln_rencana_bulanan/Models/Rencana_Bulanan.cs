using System;
using System.Collections.Generic;

namespace sln_rencana_bulanan.Models
{
    public partial class Rencana_Bulanan
    {
        public long ren_bul_id { get; set; }
        public string? tahun { get; set; }
        public string? bulan { get; set; }
        public decimal? pemasukan { get; set; }
        public int? pers_peng { get; set; }
        public decimal? rup_peng { get; set; }
        public int? pers_tab { get; set; }
        public decimal? rup_tab { get; set; }
        public int? pers_takterduga { get; set; }
        public decimal? rup_takterduga { get; set; }
    }
}
