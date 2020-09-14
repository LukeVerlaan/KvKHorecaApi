using System;
using System.Collections.Generic;
using System.Text;

namespace KVKApp.Models
{
    public class TradeName
    {
        public string BusinessName { get; set; }
        public string ShortBusinessName { get; set; }
        public List<string> CurrentTradeNames { get; set; }
        public List<string> CurrentStatutoryNames { get; set; }
    }
}
