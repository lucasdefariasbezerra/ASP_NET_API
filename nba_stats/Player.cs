//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace nba_stats
{
    using System;
    using System.Collections.Generic;
    
    public partial class Player
    {
        public int id { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public string number { get; set; }
        public int franchise { get; set; }
        public Nullable<int> active { get; set; }
    
        public virtual Franchise Franchise1 { get; set; }
    }
}
