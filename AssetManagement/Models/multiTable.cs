using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetManagement.Models
{
    public class multiTable
    {
        public asset_details assetDetails { get; set; }
        public employee employee { get; set; }
        public asset_type assetType { get; set; }
        public cost_details costDetails { get; set; }
        public cost_type costType { get; set; }
        public software_details softwareDetails { get; set; }

    }
}