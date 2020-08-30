using SubTrackerDL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubTrackerDL
{
    public class WritingProject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int WordCount { get; set; }
        public string Notes { get; set; }
        public ProjectType ProjectType { get; set; }
    }
}
