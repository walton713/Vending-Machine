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
            vendingMachine.InsertCoin(VendingMachine.Coins.NICKEL);
            Assert.AreEqual(VendingMachine.Coins.NICKEL, vendingMachine.CurrentCoins[0]);
            Assert.AreEqual(0.05, vendingMachine.CurrentAmount);
            Assert.AreEqual("0.05", vendingMachine.Display);
        }

        [TestMethod]
        public void WhenADimeIsInsertedItIsAccepted()
        {
            vendingMachine.InsertCoin(VendingMachine.Coins.DIME);
            Assert.AreEqual(VendingMachine.Coins.DIME, vendingMachine.CurrentCoins[0]);
            Assert.AreEqual(0.10, vendingMachine.CurrentAmount);
            Assert.AreEqual("0.10", vendingMachine.Display);
        }

        [TestMethod]
        public void WhenAQuarterIsInsertedItIsAccepted()
        {
            vendingMachine.InsertCoin(VendingMachine.Coins.QUARTER);
            Assert.AreEqual(VendingMachine.Coins.QUARTER, vendingMachine.CurrentCoins[0]);
            Assert.AreEqual(0.25, vendingMachine.CurrentAmount);
            Assert.AreEqual("0.25", vendingMachine.Display);
        }

        [TestMethod]
        public void WhenAPennyIsInsertedItIsRejected()
        {
            vendingMachine.InsertCoin(VendingMachine.Coins.PENNY);
            Assert.AreEqual(VendingMachine.Coins.PENNY, vendingMachine.CoinReturn[0]);
        }

        [TestMethod]
        public void WhenNoCoinIsInsertedDisplayIsInsertCoin()
        {
            Assert.AreEqual("INSERT COIN", vendingMachine.Display);
        }
    }
}