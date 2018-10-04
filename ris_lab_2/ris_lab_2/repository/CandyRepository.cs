using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ris_lab_2.model.candy;

namespace ris_lab_2.repository
{
    public class CandyRepository
    {
        public CandyRepository()
        {
        }

        public void addCandy(List<CandySupply> candies)
        {
            using (StreamWriter file = File.CreateText(@"D:\proj\rice\ris_lab_2\ris_lab_2\dist\candy-supply.txt"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(textWriter: file, value: candies);
            }
        }

        public List<CandySupply> getAll()
        {
            List<CandySupply> tempCandies = new List<CandySupply>();
            // read JSON directly from a file
            using (StreamReader file = File.OpenText(@"D:\proj\rice\ris_lab_2\ris_lab_2\dist\candy-supply.txt"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JArray o2 = (JArray) JToken.ReadFrom(reader);
                foreach (var jToken in o2)
                {
                    tempCandies.Add(new CandySupply(jToken["supplyWhat"].ToString()
                        , (long) jToken["supplyAmount"]
                        , (long) jToken["supplyPrice"]));
                }
            }

            return tempCandies;
        }
    }
}