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
        public enum Coins { NICKEL, DIME, QUARTER };

        public ArrayList CurrentCoins {get; private set;}

        public VendingMachine()
        {
            CurrentCoins = new ArrayList();
        }

        public void Insert(Coins coin)
        {
            CurrentCoins.Add(coin);
        }

        static void Main(string[] args)
        {
        }
    }
}
