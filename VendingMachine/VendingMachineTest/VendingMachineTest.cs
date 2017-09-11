using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Machine;

namespace VendingMachineTest
{
    [TestClass]
    public class VendingMachineTest
    {
        VendingMachine vendingMachine;

        [TestInitialize]
        public void TestInit()
        {
            vendingMachine = new VendingMachine();
        }

        [TestMethod]
        public void WhenANickelIsInsertedItIsAccepted()
        {
            vendingMachine.Insert(VendingMachine.Coins.NICKEL);
            Assert.AreEqual(VendingMachine.Coins.NICKEL, vendingMachine.CurrentCoins[0]);
        }

        [TestMethod]
        public void WhenADimeIsInsertedItIsAccepted()
        {
            vendingMachine.Insert(VendingMachine.Coins.DIME);
            Assert.AreEqual(VendingMachine.Coins.DIME, vendingMachine.CurrentCoins[0]);
        }

        [TestMethod]
        public void WhenAQuarterIsInsertedItIsAccepted()
        {
            vendingMachine.Insert(VendingMachine.Coins.QUARTER);
            Assert.AreEqual(VendingMachine.Coins.QUARTER, vendingMachine.CurrentCoins[0]);
        }
    }
}