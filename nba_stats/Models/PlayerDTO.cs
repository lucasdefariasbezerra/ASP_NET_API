using nba_stats.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nba_stats.Models
{
    public class PlayerDTO
    {
        private int _id;
        private int _franchiseId;
        private String _name;
        private String _position;
        private String _number;
        private FranchiseDTO _franchise;


        public int id {
            get {
                return this._id;
            }

            set {
                this._id = value;
            }
        }

        public int franchiseId
        {
            get
            {
                return this._franchiseId;
            }

            set
            {
                this._franchiseId = value;
            }
        }

        public String name
        {
            get
            {
                return this._name;
            }

            set
            {
                this._name = value;
            }
        }

        public String position
        {
            get
            {
                return this._position;
            }

            set
            {
                this._position = value;
            }
        }

        public String number
        {
            get
            {
                return this._number;
            }

            set
            {
                this._number = value;
            }
        }

        public FranchiseDTO franchise
        {
            get
            {
                return this._franchise;
            }

            set
            {
                this._franchise = value;
            }
        }
    }
}