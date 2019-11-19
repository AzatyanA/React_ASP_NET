using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace React_ASP_NET.Models
{
    public class Candidate
    {
        public int CandidateID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public int Experience { get; set; }
        public int Age { get; set; }
    }
}