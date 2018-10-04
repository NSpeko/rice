using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ris_lab_2.data;
using ris_lab_2.model.candy;

namespace ris_lab_2.repository
{
    public class CandyRepository
    {
        private List<CandySupply> candies = new List<CandySupply>();
        private FileWorker _fileWorker = FileWorker.GetInstance();

        public CandyRepository()
        {
            using (StreamWriter file = File.CreateText(@"D:\path.txt"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, _data);
            }
          
        }

        public void addCandy(CandySupply candy)
        {
            candies.Add(candy);
        }

        public List<CandySupply> getAll()
        {
            return candies;
        }
    }
}