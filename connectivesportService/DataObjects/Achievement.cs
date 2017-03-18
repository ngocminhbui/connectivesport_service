using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace connectivesportService.DataObjects
{
    public class Achievement : EntityData
    {
        public Achievement()
        {

        }

        [JsonProperty("AchieveDate")]
        public DateTime? AchieveDate { get; set; } = (DateTime?)null;


        [JsonProperty("AchieveUserId")]
        public string AchieveUserId { get; set; }

        [JsonProperty("MedalId")]
        public string MedalId { get; set; }

        public virtual User AchieveUser { get; set; }


        public virtual Medal Medal {get;set;}
    }
}