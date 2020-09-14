using KVKApp.Models;
using KVKApp.Services.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KVKApp.Services.Api
{
    public class ApiService : IApiService
    {
        public async Task<IEnumerable<Company>> Sync()
        {
            List<Company> companies = new List<Company>();
            try
            {
                var response = await WebAccess.Get(AppSettings.KVKEndpoint + "testsearch/companies?q=test&branchNumber=000037143557");
                if (response != null)
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Debug.WriteLine(response.Data);
                        JObject obj = JsonConvert.DeserializeObject<JObject>(response.Data);
                        JObject innerObj = obj["data"] as JObject;
                        JArray data = innerObj["items"] as JArray;

                        if (data != null && data.Count() > 0)
                        {
                            foreach (var i in data)
                            {
                                if (!companies.Any(com => com.KvkNumber == i["kvkNumber"].ToString()))
                                {
                                    JObject tradeNames = i["tradeNames"] as JObject;
                                    JArray addresses = i["addresses"] as JArray;
                                    Company company = new Company
                                    {
                                        KvkNumber = i["kvkNumber"].ToString(),
                                        BranchNumber = i["branchNumber"].ToString(),
                                        RSIN = i["rsin"].ToString(),
                                        HasEntryInBusinessRegister = (bool)i["hasEntryInBusinessRegister"],
                                        HasNonMailingIndication = (bool)i["hasNonMailingIndication"],
                                        IsLegalPerson = (bool)i["isLegalPerson"],
                                        IsBranch = (bool)i["isBranch"],
                                        IsMainBranch = (bool)i["isMainBranch"],
                                        Addresses = new List<Address>()
                                    };
                                    JArray currentTradeNames = tradeNames["currentTradeNames"] as JArray;
                                    JArray currentStatutoryNames = tradeNames["currentStatutoryNames"] as JArray;

                                    TradeName tradeName = new TradeName
                                    {
                                        BusinessName = tradeNames["businessName"].ToString(),
                                        ShortBusinessName = tradeNames["shortBusinessName"].ToString(),
                                        CurrentTradeNames = new List<string>(),
                                        CurrentStatutoryNames = new List<string>()
                                    };
                                    foreach (var ctn in currentTradeNames)
                                    {
                                        tradeName.CurrentTradeNames.Add(ctn.ToString());
                                    }
                                    foreach (var csn in currentStatutoryNames)
                                    {
                                        tradeName.CurrentStatutoryNames.Add(csn.ToString());
                                    }
                                    company.TradeNames = tradeName;
                                    foreach (var a in addresses)
                                    {
                                        company.Addresses.Add(new Address
                                        {
                                            Type = a["type"].ToString(),
                                            Street = a["street"].ToString(),
                                            HouseNumber = a["houseNumber"].ToString(),
                                            HouseNumberAddition = a["houseNumberAddition"].ToString(),
                                            PostalCode = a["postalCode"].ToString(),
                                            City = a["city"].ToString(),
                                            Country = a["country"].ToString(),
                                        });
                                    }
                                    companies.Add(company);
                                }
                            }
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
            return companies.AsEnumerable();
        }
    }
}
