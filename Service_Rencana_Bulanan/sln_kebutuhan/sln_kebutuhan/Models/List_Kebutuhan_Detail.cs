﻿using System;
using System.Collections.Generic;

namespace sln_kebutuhan.Models
{
    public partial class List_Kebutuhan_Detail
    {
        public long keb_det_id { get; set; }
        public long keb_id { get; set; }
        public string? keb_det_nama { get; set; }
        public string? status { get; set; }
        public string? keb_nama { get; set; }
        public string? keterangan { get; set; }
    }
}
