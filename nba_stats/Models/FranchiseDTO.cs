using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nba_stats.Models.DTO
{
    public class FranchiseDTO
    {
        private int _id;
        private String _name;
        private String _state;
        private String _city;
        private String _ginasium;

        public int id
        {
            get
            {
                return this._id;
            }

            set
            {
                this._id = value;
            }
        }


        public String name {
            get {
                return this._name;
            }

            set {
                this._name = value;
            }
        }

        public String state {
            get {
                return this._state;
            }

            set {
                this._state = value;
            }
        }

        public String city {
            get {
                return this._city;
            }

            set {
                this._city = value;
            }
        }

        public String ginasium {
            get {
                return this._ginasium;
            }

            set {
                this._ginasium = value;
            }
        }
        
    }
}
