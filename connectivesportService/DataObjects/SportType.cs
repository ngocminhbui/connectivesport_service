﻿using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace connectivesportService.DataObjects
{
    public class SportType:EntityData
    {
        public SportType()
        {
            Sports = new List<Sport>();
        }

        public string Descrition { get; set; }

        public virtual ICollection<Sport> Sports { get; set; }
    }
}