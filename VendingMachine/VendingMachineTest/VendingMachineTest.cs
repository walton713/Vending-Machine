﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

using Machine;
using System.Collections;

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
        public void WhenAColaIsSelectedAndThereIsEnoughMoneyItIsDispensed()
        {
            for (int i = 0; i < 4; i++)
            {
                vendingMachine.InsertCoin(VendingMachine.Coins.QUARTER);
            }
            Assert.AreEqual("cola", vendingMachine.SelectProduct(vendingMachine.Cola));
            Assert.AreEqual(0.00, vendingMachine.CurrentAmount);
            Assert.AreEqual("THANK YOU", vendingMachine.CheckDisplay());
            Assert.AreEqual("INSERT COIN", vendingMachine.CheckDisplay());
        }

        [TestMethod]
        public void WhenAColaIsSelectedAndThereIsNoMoneyPriceIsDisplayedThenInsertCoin()
        {
            Assert.AreEqual(null, vendingMachine.SelectProduct(vendingMachine.Cola));
            Assert.AreEqual(0.00, vendingMachine.CurrentAmount);
            Assert.AreEqual($"PRICE {vendingMachine.Cola.Cost:0.00}", vendingMachine.CheckDisplay());
            Assert.AreEqual("INSERT COIN", vendingMachine.CheckDisplay());
        }

        [TestMethod]
        public void WhenChipsIsSelectedAndThereIsEnoughMoneyItIsDispensed()
        {
            for (int i = 0; i < 2; i++)
            {
                vendingMachine.InsertCoin(VendingMachine.Coins.QUARTER);
            }
            Assert.AreEqual("chips", vendingMachine.SelectProduct(vendingMachine.Chips));
            Assert.AreEqual(0.00, vendingMachine.CurrentAmount);
            Assert.AreEqual("THANK YOU", vendingMachine.CheckDisplay());
            Assert.AreEqual("INSERT COIN", vendingMachine.CheckDisplay());
        }

        [TestMethod]
        public void WhenChipsIsSelectedAndThereIsNoMoneyPriceIsDisplayedThenInsertCoin()
        {
            Assert.AreEqual(null, vendingMachine.SelectProduct(vendingMachine.Chips));
            Assert.AreEqual(0.00, vendingMachine.CurrentAmount);
            Assert.AreEqual($"PRICE {vendingMachine.Chips.Cost:0.00}", vendingMachine.CheckDisplay());
            Assert.AreEqual("INSERT COIN", vendingMachine.CheckDisplay());
        }

        [TestMethod]
        public void WhenCandyIsSelectedAndThereIsEnoughMoneyItIsDispensed()
        {
            for (int i = 0; i < 2; i++)
            {
                vendingMachine.InsertCoin(VendingMachine.Coins.QUARTER);
            }
            vendingMachine.InsertCoin(VendingMachine.Coins.DIME);
            vendingMachine.InsertCoin(VendingMachine.Coins.NICKEL);
            Assert.AreEqual("candy", vendingMachine.SelectProduct(vendingMachine.Candy));
            Assert.AreEqual(0.00, vendingMachine.CurrentAmount);
            Assert.AreEqual("THANK YOU", vendingMachine.CheckDisplay());
            Assert.AreEqual("INSERT COIN", vendingMachine.CheckDisplay());
        }

        [TestMethod]
        public void WhenCandyIsSelectedAndThereIsNoMoneyPriceIsDisplayedThenInsertCoin()
        {
            Assert.AreEqual(null, vendingMachine.SelectProduct(vendingMachine.Candy));
            Assert.AreEqual(0.00, vendingMachine.CurrentAmount);
            Assert.AreEqual($"PRICE {vendingMachine.Candy.Cost:0.00}", vendingMachine.CheckDisplay());
            Assert.AreEqual("INSERT COIN", vendingMachine.CheckDisplay());
        }

        [TestMethod]
        public void WhenColaIsSelectedAndThereIsNotEnoughMoneyPriceIsDisplayedThenCurrentAmount()
        {
            vendingMachine.InsertCoin(VendingMachine.Coins.QUARTER);
            Assert.AreEqual(null, vendingMachine.SelectProduct(vendingMachine.Cola));
            Assert.AreEqual(0.25, vendingMachine.CurrentAmount);
            Assert.AreEqual($"PRICE {vendingMachine.Cola.Cost:0.00}", vendingMachine.CheckDisplay());
            Assert.AreEqual($"{vendingMachine.CurrentAmount:0.00}", vendingMachine.CheckDisplay());
        }

        [TestMethod]
        public void WhenChipsIsSelectedAndThereIsNotEnoughMoneyPriceIsDisplayedThenCurrentAmount()
        {
            vendingMachine.InsertCoin(VendingMachine.Coins.DIME);
            Assert.AreEqual(null, vendingMachine.SelectProduct(vendingMachine.Chips));
            Assert.AreEqual(0.10, vendingMachine.CurrentAmount);
            Assert.AreEqual($"PRICE {vendingMachine.Chips.Cost:0.00}", vendingMachine.CheckDisplay());
            Assert.AreEqual($"{vendingMachine.CurrentAmount:0.00}", vendingMachine.CheckDisplay());
        }

        [TestMethod]
        public void WhenCandyIsSelectedAndThereIsNotEnoughMoneyPriceIsDisplayedThenCurrentAmount()
        {
            vendingMachine.InsertCoin(VendingMachine.Coins.NICKEL);
            Assert.AreEqual(null, vendingMachine.SelectProduct(vendingMachine.Candy));
            Assert.AreEqual(0.05, vendingMachine.CurrentAmount);
            Assert.AreEqual($"PRICE {vendingMachine.Candy.Cost:0.00}", vendingMachine.CheckDisplay());
            Assert.AreEqual($"{vendingMachine.CurrentAmount:0.00}", vendingMachine.CheckDisplay());
        }

        [TestMethod]
        public void WhenThereIsMoreMoneyThanTheProductCostTheRemainingMoneyIsPutInTheCoinReturn()
        {
            for (int i = 0; i < 3; i++)
            {
                vendingMachine.InsertCoin(VendingMachine.Coins.QUARTER);
            }
                Assert.AreEqual("candy", vendingMachine.SelectProduct(vendingMachine.Candy));
                Assert.AreEqual(VendingMachine.Coins.DIME, vendingMachine.CoinReturn[0]);
                Assert.AreEqual(0.00, vendingMachine.CurrentAmount);
                Assert.AreEqual(0, vendingMachine.CurrentCoins.Count);
                Assert.AreEqual("THANK YOU", vendingMachine.CheckDisplay());
                Assert.AreEqual("INSERT COIN", vendingMachine.CheckDisplay());
        }

        [TestMethod]
        public void WhenTheReturnCoinsButtonIsPressedInsertedCoinsArePutInTheCoinReturn()
        {
            ArrayList coins = new ArrayList();
            coins.Add(VendingMachine.Coins.NICKEL);
            coins.Add(VendingMachine.Coins.DIME);
            coins.Add(VendingMachine.Coins.QUARTER);
            for (int i = 0; i < coins.Count; i++)
            {
                vendingMachine.InsertCoin((VendingMachine.Coins)coins[i]);
            }
            for (int i = 0; i < coins.Count; i++)
            {
                Assert.AreEqual(coins[i], vendingMachine.CurrentCoins[i]);
            }
            vendingMachine.ReturnCoins();
            for (int i = 0; i < coins.Count; i++)
            {
                Assert.AreEqual(coins[i], vendingMachine.CoinReturn[i]);
            }
        }

        [TestMethod]
        public void WhenAProductIsSoldOutDisplayReadsSoldOutThenAmountOrInsertCoin()
        {
            for (int i = 0; i < 2; i++)
            {
                vendingMachine.InsertCoin(VendingMachine.Coins.QUARTER);
            }
            vendingMachine.SelectProduct(vendingMachine.Chips);
            for (int i = 0; i < 2; i++)
            {
                vendingMachine.InsertCoin(VendingMachine.Coins.QUARTER);
            }
            Assert.AreEqual(null, vendingMachine.SelectProduct(vendingMachine.Chips));
            Assert.AreEqual("SOLD OUT", vendingMachine.CheckDisplay());
            Assert.AreEqual($"{vendingMachine.CurrentAmount:0.00}", vendingMachine.CheckDisplay());
        }
    }
}