using System;
using System.Collections.Generic;
using ris_lab_2.model.candy;
using ris_lab_2.repository;
using ris_lab_2.service;

namespace ris_lab_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            CandyRepository repository=new CandyRepository();
            List<CandySupply> candies =repository.getAll();
            CandyService candyService=new CandyService();
            bool flag = true;
            while (flag)
            {
                candyService.printAllCandy(candies);
                Console.WriteLine("Enter function name(add, all, del, exi):");
                switch (Console.ReadLine())
                {
                    case "add":
                    {
                        candies=candyService.addCandy(candies);
                        break;
                    }
                    case "all":
                    {
                        candyService.printAllCandy(candies);
                        break;
                    }
                    case "del":
                    {
                        candies=candyService.deleteCandy(candies);
                        break;
                    }
                    case "exi":
                    {
                        flag = false;
                        break;
                    }
                    default: break;  
                }
            }
        }
    }
}