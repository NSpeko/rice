using System;

namespace ris_lab_2.model.candy
{
    public class CandySupply
    {
        public string supplyWhat { get; set; }
        public long supplyAmount { get; set; }
        public long supplyPrice { get; set; }

        public CandySupply(string name, long amount, long price)
        {
            supplyWhat = name;
            supplyAmount = amount;
            supplyPrice = price;
        }

        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}$", supplyWhat, arg1: supplyAmount.ToString(), arg2: supplyPrice.ToString());
        }
    }
}