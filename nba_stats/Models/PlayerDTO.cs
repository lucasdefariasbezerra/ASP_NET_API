using nba_stats.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nba_stats.Models
{
    public class PlayerDTO
    {
        public int id { get; set; }
        public int franchiseId { get; set; }
        public String name { get; set; }
        public String position { get; set; }
        public String number { get; set; }
        public FranchiseDTO franchise { get; set; }

    }
}