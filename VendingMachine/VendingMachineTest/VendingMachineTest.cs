using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Machine;

namespace VendingMachineTest
{
    [TestClass]
    public class VendingMachineTest
    {
        [TestMethod]
        public void WhenANickelIsInsertedItIsAccepted()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Insert(VendingMachine.Coins.NICKEL);
            Assert.AreEqual(VendingMachine.Coins.NICKEL, vendingMachine.CurrentCoins[0]);
        }

        [TestMethod]
        public void WhenADimeIsInsertedItIsAccepted()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Insert(VendingMachine.Coins.DIME);
            Assert.AreEqual(VendingMachine.Coins.DIME, vendingMachine.CurrentCoins[0]);
        }
    }
}