using System;
using System.Collections.Generic;
using System.Text;

namespace KVKApp.Models
{
    public class Address
    {
        public string Type { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string HouseNumberAddition { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public string FullAddress => $"{Street} {HouseNumber}{HouseNumberAddition}, {City}";
    }
}
