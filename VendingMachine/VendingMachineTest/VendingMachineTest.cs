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
            Assert.AreEqual("0.05", vendingMachine.CheckDisplay());
        }

        [TestMethod]
        public void WhenADimeIsInsertedItIsAccepted()
        {
            vendingMachine.InsertCoin(VendingMachine.Coins.DIME);
            Assert.AreEqual(VendingMachine.Coins.DIME, vendingMachine.CurrentCoins[0]);
            Assert.AreEqual(0.10, vendingMachine.CurrentAmount);
            Assert.AreEqual("0.10", vendingMachine.CheckDisplay());
        }

        [TestMethod]
        public void WhenAQuarterIsInsertedItIsAccepted()
        {
            vendingMachine.InsertCoin(VendingMachine.Coins.QUARTER);
            Assert.AreEqual(VendingMachine.Coins.QUARTER, vendingMachine.CurrentCoins[0]);
            Assert.AreEqual(0.25, vendingMachine.CurrentAmount);
            Assert.AreEqual("0.25", vendingMachine.CheckDisplay());
        }

        [TestMethod]
        public void WhenAPennyIsInsertedItIsRejected()
        {
            vendingMachine.InsertCoin(VendingMachine.Coins.PENNY);
            Assert.AreEqual(VendingMachine.Coins.PENNY, vendingMachine.CoinReturn[0]);
            Assert.AreEqual("INSERT COIN", vendingMachine.CheckDisplay());
        }

        [TestMethod]
        public void WhenNoCoinIsInsertedDisplayIsInsertCoin()
        {
            Assert.AreEqual("INSERT COIN", vendingMachine.CheckDisplay());
        }

        [TestMethod]
        public void WhenAProductIsSelectedAndThereIsEnoughMoneyItIsDispensed()
        {
            for (int i = 0; i < 4; i++)
            {
                vendingMachine.InsertCoin(VendingMachine.Coins.QUARTER);
            }
            Assert.AreEqual("cola", vendingMachine.SelectProduct("cola"));
            Assert.AreEqual(0.00, vendingMachine.CurrentAmount);
            Assert.AreEqual("THANK YOU", vendingMachine.CheckDisplay());
            Assert.AreEqual("INSERT COIN", vendingMachine.CheckDisplay());
        }

        [TestMethod]
        public void WhenAProductIsSelectedAndThereIsNotEnoughMoneyPriceIsDisplayedThenInsertCoin()
        {
            Assert.AreEqual(null, vendingMachine.SelectProduct("cola"));
            Assert.AreEqual(0.00, vendingMachine.CurrentAmount);
            Assert.AreEqual($"PRICE {vendingMachine.Cola.Cost:0.00}", vendingMachine.CheckDisplay());
            Assert.AreEqual("INSERT COIN", vendingMachine.CheckDisplay());
        }
    }
}