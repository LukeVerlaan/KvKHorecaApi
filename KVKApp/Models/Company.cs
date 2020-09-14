using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace KVKApp.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string KvkNumber { get; set; }
        public string BranchNumber { get; set; }
        public string RSIN { get; set; }
        public TradeName TradeNames { get; set; }
        public bool HasEntryInBusinessRegister { get; set; }
        public bool HasNonMailingIndication { get; set; }
        public bool IsLegalPerson { get; set; }
        public bool IsBranch { get; set; }
        public bool IsMainBranch { get; set; }
        public List<Address> Addresses { get; set; }
    }

}
