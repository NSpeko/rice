using System;
using System.Collections.Generic;
using ris_lab_2.model.candy;
using ris_lab_2.repository;

namespace ris_lab_2.service
{
    public class CandyService
    {
        private CandyRepository repo = new CandyRepository();

        public List<CandySupply> addCandy(List<CandySupply> candies)
        {
            Console.Clear();
            Console.WriteLine("Enter supply name");
            var name = Console.ReadLine();

            Console.WriteLine("Enter supply amount");
            var amount = Console.ReadLine();

            Console.WriteLine("Enter supply price");
            var price = Console.ReadLine();
            candies.Add(new CandySupply(name,Convert.ToInt64(amount),Convert.ToInt64(price)));
            repo.addCandy(candies);
            this.printAllCandy(candies);
            return candies;
        }

        public void printAllCandy(List<CandySupply> candies)
        {
            Console.Clear();
            candies.ForEach((el) => { Console.WriteLine(el.ToString()); });
        }

        public List<CandySupply> deleteCandy(List<CandySupply> candies)
        {
            this.printAllCandy(candies);
            Console.WriteLine("Enter track id");
            var temp = Console.ReadLine();
            if (candies.Count > Convert.ToInt32(temp) - 1)
            {
                candies.RemoveAt(Convert.ToInt32(temp)-1);
            }
            repo.addCandy(candies);

            return candies;
        }
    }
}