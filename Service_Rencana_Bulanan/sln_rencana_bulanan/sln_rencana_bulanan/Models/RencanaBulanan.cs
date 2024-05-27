using System;
using System.Collections.Generic;

namespace sln_rencana_bulanan.Models
{
    public partial class RencanaBulanan
    {
        public long RenBulId { get; set; }
        public string? Tahun { get; set; }
        public string? Bulan { get; set; }
        public decimal? Pemasukan { get; set; }
        public int? PersPeng { get; set; }
        public decimal? RupPeng { get; set; }
        public int? PersTab { get; set; }
        public decimal? RupTab { get; set; }
        public int? PersTakterduga { get; set; }
        public decimal? RupTakterduga { get; set; }
    }
}
