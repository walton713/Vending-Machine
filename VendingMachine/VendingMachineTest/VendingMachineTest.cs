using Microsoft.VisualStudio.TestTools.UnitTesting;

using Machine;
using System.Collections;

namespace VendingMachineTest
{
    [TestClass]
    public class VendingMachineTest
    {
        //The VendingMachine object to be used for testing
        VendingMachine vendingMachine;

        /// <summary>
        /// Initializes the VendingMachine object before each test.
        /// </summary>
        [TestInitialize]
        public void TestInit()
        {
            vendingMachine = new VendingMachine();
        }
        /// <summary>
        /// Testing the InsertCoin method with a Nickel.
        /// Display will show the value of a nickel.
        /// </summary>
        [TestMethod]
        public void WhenANickelIsInsertedItIsAccepted()
        {
            vendingMachine.InsertCoin(VendingMachine.Coins.NICKEL);
            Assert.AreEqual(VendingMachine.Coins.NICKEL, vendingMachine.CurrentCoins[0]);
            Assert.AreEqual(0.05, vendingMachine.CurrentAmount);
            Assert.AreEqual("0.05", vendingMachine.CheckDisplay());
        }

        /// <summary>
        /// Testing the InsertCoin method with a Dime.
        /// Display will show the value of a dime.
        /// </summary>
        [TestMethod]
        public void WhenADimeIsInsertedItIsAccepted()
        {
            vendingMachine.InsertCoin(VendingMachine.Coins.DIME);
            Assert.AreEqual(VendingMachine.Coins.DIME, vendingMachine.CurrentCoins[0]);
            Assert.AreEqual(0.10, vendingMachine.CurrentAmount);
            Assert.AreEqual("0.10", vendingMachine.CheckDisplay());
        }

        /// <summary>
        /// Testing the InsertCoin method with a Quarter.
        /// Display will show the value of a quarter.
        /// </summary>
        [TestMethod]
        public void WhenAQuarterIsInsertedItIsAccepted()
        {
            vendingMachine.InsertCoin(VendingMachine.Coins.QUARTER);
            Assert.AreEqual(VendingMachine.Coins.QUARTER, vendingMachine.CurrentCoins[0]);
            Assert.AreEqual(0.25, vendingMachine.CurrentAmount);
            Assert.AreEqual("0.25", vendingMachine.CheckDisplay());
        }

        /// <summary>
        /// Testing the InsertCoin method with a Penny.
        /// Display will show INSERT COIN.
        /// </summary>
        [TestMethod]
        public void WhenAPennyIsInsertedItIsRejected()
        {
            vendingMachine.InsertCoin(VendingMachine.Coins.PENNY);
            Assert.AreEqual(VendingMachine.Coins.PENNY, vendingMachine.CoinReturn[0]);
            Assert.AreEqual("INSERT COIN", vendingMachine.CheckDisplay());
        }

        /// <summary>
        /// Testing the display when no coin has been inserted.
        /// Display will show INSERT COIN.
        /// </summary>
        [TestMethod]
        public void WhenNoCoinIsInsertedDisplayIsInsertCoin()
        {
            Assert.AreEqual("INSERT COIN", vendingMachine.CheckDisplay());
        }

        /// <summary>
        /// Testing the SelectProduct method with Cola and enough money inserted.
        /// "cola" is returned from the SelectProduct method.
        /// CurrentAmount is now 0.00 and Display is THANK YOU.
        /// When the Display is checked again it shows INSERT COIN.
        /// </summary>
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

        /// <summary>
        /// Testing the SelectProduct method with Cola and no money inserted.
        /// CurrentAmount is 0.00 and Display is PRICE and the price of Cola.
        /// When the display is checked again it shows INSERT COIN.
        /// </summary>
        [TestMethod]
        public void WhenAColaIsSelectedAndThereIsNoMoneyPriceIsDisplayedThenInsertCoin()
        {
            Assert.AreEqual(null, vendingMachine.SelectProduct(vendingMachine.Cola));
            Assert.AreEqual(0.00, vendingMachine.CurrentAmount);
            Assert.AreEqual($"PRICE {vendingMachine.Cola.Cost:0.00}", vendingMachine.CheckDisplay());
            Assert.AreEqual("INSERT COIN", vendingMachine.CheckDisplay());
        }

        /// <summary>
        /// Testing the SelectProduct method with Chips and enough money inserted.
        /// "chips" is returned from the SelectProduct method.
        /// CurrentAmount is now 0.00 and Display is THANK YOU.
        /// When the Display is checked again it shows INSERT COIN.
        /// </summary>
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

        /// <summary>
        /// Testing the SelectProduct method with Chips and no money inserted.
        /// CurrentAmount is 0.00 and Display is PRICE and the price of Chips.
        /// When the display is checked again it shows INSERT COIN.
        /// </summary>
        [TestMethod]
        public void WhenChipsIsSelectedAndThereIsNoMoneyPriceIsDisplayedThenInsertCoin()
        {
            Assert.AreEqual(null, vendingMachine.SelectProduct(vendingMachine.Chips));
            Assert.AreEqual(0.00, vendingMachine.CurrentAmount);
            Assert.AreEqual($"PRICE {vendingMachine.Chips.Cost:0.00}", vendingMachine.CheckDisplay());
            Assert.AreEqual("INSERT COIN", vendingMachine.CheckDisplay());
        }

        /// <summary>
        /// Testing the SelectProduct method with Candy and enough money inserted.
        /// "candy" is returned from the SelectProduct method.
        /// CurrentAmount is now 0.00 and Display is THANK YOU.
        /// When the Display is checked again it shows INSERT COIN.
        /// </summary>
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

        /// <summary>
        /// Testing the SelectProduct method with Candy and no money inserted.
        /// CurrentAmount is 0.00 and Display is PRICE and the price of Candy.
        /// When the display is checked again it shows INSERT COIN.
        /// </summary>
        [TestMethod]
        public void WhenCandyIsSelectedAndThereIsNoMoneyPriceIsDisplayedThenInsertCoin()
        {
            Assert.AreEqual(null, vendingMachine.SelectProduct(vendingMachine.Candy));
            Assert.AreEqual(0.00, vendingMachine.CurrentAmount);
            Assert.AreEqual($"PRICE {vendingMachine.Candy.Cost:0.00}", vendingMachine.CheckDisplay());
            Assert.AreEqual("INSERT COIN", vendingMachine.CheckDisplay());
        }

        /// <summary>
        /// Testing the SelectProduct method with Cola and not enough money is inserted.
        /// CurrentAmount is the amount of money that has been inserted.
        /// Display is PRICE and the price of Cola.
        /// When the display is checked again it shows the CurrentAmount.
        /// </summary>
        [TestMethod]
        public void WhenColaIsSelectedAndThereIsNotEnoughMoneyPriceIsDisplayedThenCurrentAmount()
        {
            vendingMachine.InsertCoin(VendingMachine.Coins.QUARTER);
            Assert.AreEqual(null, vendingMachine.SelectProduct(vendingMachine.Cola));
            Assert.AreEqual(0.25, vendingMachine.CurrentAmount);
            Assert.AreEqual($"PRICE {vendingMachine.Cola.Cost:0.00}", vendingMachine.CheckDisplay());
            Assert.AreEqual($"{vendingMachine.CurrentAmount:0.00}", vendingMachine.CheckDisplay());
        }

        /// <summary>
        /// Testing the SelectProduct method with Chips and not enough money is inserted.
        /// CurrentAmount is the amount of money that has been inserted.
        /// Display is PRICE and the price of Chips.
        /// When the display is checked again it shows the CurrentAmount.
        /// </summary>
        [TestMethod]
        public void WhenChipsIsSelectedAndThereIsNotEnoughMoneyPriceIsDisplayedThenCurrentAmount()
        {
            vendingMachine.InsertCoin(VendingMachine.Coins.DIME);
            Assert.AreEqual(null, vendingMachine.SelectProduct(vendingMachine.Chips));
            Assert.AreEqual(0.10, vendingMachine.CurrentAmount);
            Assert.AreEqual($"PRICE {vendingMachine.Chips.Cost:0.00}", vendingMachine.CheckDisplay());
            Assert.AreEqual($"{vendingMachine.CurrentAmount:0.00}", vendingMachine.CheckDisplay());
        }

        /// <summary>
        /// Testing the SelectProduct method with Candy and not enough money is inserted.
        /// CurrentAmount is the amount of money that has been inserted.
        /// Display is PRICE and the price of Candy.
        /// When the display is checked again it shows the CurrentAmount.
        /// </summary>
        [TestMethod]
        public void WhenCandyIsSelectedAndThereIsNotEnoughMoneyPriceIsDisplayedThenCurrentAmount()
        {
            vendingMachine.InsertCoin(VendingMachine.Coins.NICKEL);
            Assert.AreEqual(null, vendingMachine.SelectProduct(vendingMachine.Candy));
            Assert.AreEqual(0.05, vendingMachine.CurrentAmount);
            Assert.AreEqual($"PRICE {vendingMachine.Candy.Cost:0.00}", vendingMachine.CheckDisplay());
            Assert.AreEqual($"{vendingMachine.CurrentAmount:0.00}", vendingMachine.CheckDisplay());
        }

        /// <summary>
        /// Testing the GetChange method. When Candy is selected with 0.75 in the machine
        /// a Dime is placed in the Coin Return. The display shows THANK YOU.
        /// When the display is checked again, it shows INSERT COIN.
        /// </summary>
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

        /// <summary>
        /// Testing the ReturnCoins method. When money has been inserted and the Return Coins
        /// button is pressed, the inserted coins are placed in the Coin Return.
        /// </summary>
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

        /// <summary>
        /// Testing the SelectProduct method when the product is sold out and enough money has
        /// been inserted. The product is not dispensed and the Display shows SOLD OUT.
        /// When the display is checked again it shows the CurrentAmount.
        /// </summary>
        [TestMethod]
        public void WhenAProductIsSoldOutDisplayReadsSoldOutThenAmount()
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

        /// <summary>
        /// Testing the SelectProduct method when the product is sold out and no money
        /// has been inserted. The product is not dispensed and the Display shows SOLD OUT.
        /// When the Display is checked again it shows INSERT COIN.
        /// </summary>
        [TestMethod]
        public void WhenAProductIsSoldOutDisplayReadsSoldOutThenInsertCoin()
        {
            for (int i = 0; i < 2; i++)
            {
                vendingMachine.InsertCoin(VendingMachine.Coins.QUARTER);
            }
            vendingMachine.SelectProduct(vendingMachine.Chips);
            Assert.AreEqual(null, vendingMachine.SelectProduct(vendingMachine.Chips));
            Assert.AreEqual("SOLD OUT", vendingMachine.CheckDisplay());
            Assert.AreEqual("INSERT COIN", vendingMachine.CheckDisplay());
        }

        [TestMethod]
        public void WhenTheMachineCannotMakeChangeForAnyProductsExactChangeIsDisplayed()
        {
            //TODO: Exact Change Only
            //As a customer
            //I want to be told when exact change is required
            //So that I can determine if I can buy something with the money I have before inserting it
        }
    }
}