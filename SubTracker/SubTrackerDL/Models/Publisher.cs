using System;
using System.Collections.Generic;
using System.Text;

namespace SubTrackerDL.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public Boolean PayingMarket { get; set; }
        public string Name { get; set; }
        public string Accepts { get; set; }
        public Range Lengths { get; set; }
        public string Notes { get; set; }
    }
}
