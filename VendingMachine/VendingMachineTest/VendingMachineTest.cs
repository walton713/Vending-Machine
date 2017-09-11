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
    }
}