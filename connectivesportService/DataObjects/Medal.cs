using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace connectivesportService.DataObjects
{
    public class Medal:EntityData
    {
        public Medal()
        {

        }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("ImageURL")]
        public string ImageURL { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        public virtual ICollection<Achievement> Achievements { get; set; }
    }
}