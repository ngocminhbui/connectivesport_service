﻿using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace connectivesportService.DataObjects
{
    public class Goal:EntityData
    {

        [JsonProperty("CustomMessage")]
        public string CustomMessage { get; set; }


        [JsonProperty("BattleForRank")]
        public int? BattleForRank { get; set; }

        [JsonProperty("Count")]
        public int? Count { get; set; }

        [JsonProperty("Length")]
        public double? Length { get; set; }

        [JsonProperty("Frequency")]
        public int? Frequency { get; set; }

        [JsonProperty("ProposedTime")]
        public DateTime? ProposedTime { get; set; }

        [JsonProperty("DateAccepted")]
        public DateTime? DateAccepted { get; set; }

        [JsonProperty("DateCompleted")]
        public DateTime? DateCompleted { get; set; }



        public virtual Sport Sport { get; set; }

        [JsonProperty("SportId")]
        public string SportId { get; set; }

        [JsonProperty("UserId")]
        public string UserId { get; set; }
        public User User { get; set; }
        


    }
}