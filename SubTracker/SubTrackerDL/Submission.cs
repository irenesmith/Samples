using System;
using System.Collections.Generic;
using System.Text;

namespace SubTrackerDL
{
   public class Submission
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int PublisherId { get; set; }
        public DateTime SubmissionDate { get; set; }
        public DateTime ResponseDate { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Response { get; set; }
        public double Payment { get; set; }
    }
}
