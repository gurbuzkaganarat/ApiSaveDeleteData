﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiForm.Entity
{
    public class Meta
    {

        public int MetaId { get; set; }
        public int total_pages { get; set; }
        public int current_page { get; set; }
        public int next_page { get; set; }
        public int per_page { get; set; }
        public int total_count { get; set; }
    }
}
