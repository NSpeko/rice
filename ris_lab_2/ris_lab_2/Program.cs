using System;
using ris_lab_2.model.candy;

namespace ris_lab_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            bool flag = true;
            while (flag)
            {
                switch (Console.ReadLine())
                {
                    case "add":
                    {
                        CandySupply tempHuinya=new CandySupply();
                        break;
                    }
                    case "all":
                    {
                        
                        break;
                    }
                    case "del":
                    {
                        
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