using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine
{
    public class VendingMachine
    {
        public enum Coins { NICKEL, DIME, QUARTER, PENNY };

        public ArrayList CurrentCoins {get; private set;}
        public ArrayList CoinReturn { get; private set; }
        public double CurrentAmount { get; private set; }
        public string Display { get; private set; }

        public VendingMachine()
        {
            CurrentCoins = new ArrayList();
            CoinReturn = new ArrayList();
            CurrentAmount = 0;
            Display = "INSERT COIN";
        }

        public void InsertCoin(Coins coin)
        {
            if (coin == Coins.PENNY)
            {
                CoinReturn.Add(coin);
                Display = "INSERT COIN";
            }
            else
            {
                CurrentCoins.Add(coin); 
                switch (coin)
                {
                    case Coins.NICKEL:
                        CurrentAmount += 0.05;
                        break;

                    case Coins.DIME:
                        CurrentAmount += 0.10;
                        break;

                    case Coins.QUARTER:
                        CurrentAmount += 0.25;
                        break;
                }
                Display = $"{CurrentAmount:0.00}";
            }
        }

        public string CheckDisplay()
        {
            return Display;
        }

        static void Main(string[] args)
        {
        }
    }
}
