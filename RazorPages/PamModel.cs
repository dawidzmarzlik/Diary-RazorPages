﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages
{
    public class PamModel
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Text { get; set; }
        public string Datetime { get; set; }
    }
}
