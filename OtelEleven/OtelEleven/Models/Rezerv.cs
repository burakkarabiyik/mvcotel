using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OtelEleven.Models;

namespace OtelEleven.Models
{
    public class Rezerv
    {
        public IEnumerable<Oda> oda { get; set; }
        public Rezervasyon Rezervasyon { get; set; }

    }
}