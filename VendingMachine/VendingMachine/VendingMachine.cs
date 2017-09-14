using System;
using System.Collections;

namespace Machine
{
    /// <summary>
    /// The VendingMachine Class sets up the vending machine so that the customer
    /// can buy products and the vendor can earn money.
    /// </summary>
    public class VendingMachine
    {
        //Enum which holds the values of coins that can be inserted into the vending machine
        public enum Coins { NICKEL, DIME, QUARTER, PENNY };

        //The coins which have been inserted into the machine
        public ArrayList CurrentCoins {get; private set;}
        
        //The coins which have been returned by the machine
        public ArrayList CoinReturn { get; private set; }

        //The Products that the machine contains
        public Product Cola { get; private set; }
        public Product Chips { get; private set; }
        public Product Candy { get; private set; }

        //The value of the coins that have been inserted into the machine
        public double CurrentAmount { get; private set; }

        //The message that the machine is currently displaying
        public string Display { get; private set; }

        /// <summary>
        /// Default constructor that sets up the VendingMachine object
        /// </summary>
        public VendingMachine()
        {
            CurrentCoins = new ArrayList();
            CoinReturn = new ArrayList();
            Cola = new Product("cola", 1.00);
            Chips = new Product("chips", 0.50);
            Candy = new Product("candy", 0.65);
            CurrentAmount = 0;
            Display = "INSERT COIN";
        }

        /// <summary>
        /// When a coin is inserted, if the coin is a Nickel, Dime or Quarter
        /// it is accepted by the machine. If it is a Penny it is placed in the
        /// Coin Return.
        /// </summary>
        /// <param name="coin">The coin that has been inserted into the machine</param>
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

        /// <summary>
        /// When the display is checked, the current value is saved and the display is
        /// updated accordingly.
        /// </summary>
        /// <returns>The current value of the Display</returns>
        public string CheckDisplay()
        {
            string message = Display;
            if (message == "THANK YOU")
            {
                Display = "INSERT COIN";
            }
            else if (message.StartsWith("PRICE") || message == "SOLD OUT")
            {
                if (CurrentAmount == 0.00)
                {
                    Display = "INSERT COIN";
                }
                else
                {
                    Display = $"{CurrentAmount:0.00}";
                }
            }
            return message;
        }


        /// <summary>
        /// When a product is selected, if enough money has been inserted and
        /// the product is not sold out it is dispensed. If more money was inserted
        /// than is required to purchase the product, the change is placed in the Coin
        /// Return.
        /// </summary>
        /// <param name="product">The product which has been selected.</param>
        /// <returns>If the product was dispensed, it returns the name of the product.
        /// If the product was not dispensed, it returns null.</returns>
        public string SelectProduct(Product product)
        {
            if (product.Quantity < 1)
            {
                Display = "SOLD OUT";
                return null;
            }
            else if (CurrentAmount >= product.Cost)
            {
                CurrentAmount = Math.Round(CurrentAmount - product.Cost, 2);
                product.Quantity--;
                GetChange(product);
                while (CurrentCoins.Count > 0)
                {
                    CurrentCoins.RemoveAt(0);
                }
                Display = "THANK YOU";
                return product.Name;
            }
            else
            {
                Display = $"PRICE {product.Cost:0.00}";
                return null;
            }
        }

        /// <summary>
        /// When more money has been inserted than the cost of the product,
        /// change is placed in the Coin Return.
        /// </summary>
        /// <param name="product">The product that was selected.</param>
        public void GetChange(Product product)
        {
            while (CurrentAmount > 0.00)
            {
                if ((CurrentAmount - 0.25) >= 0)
                {
                    CoinReturn.Add(Coins.QUARTER);
                    CurrentAmount -= 0.25;
                }
                else if ((CurrentAmount - 0.10) >= 0)
                {
                    CoinReturn.Add(Coins.DIME);
                    CurrentAmount -= 0.10;
                }
                else if ((CurrentAmount - 0.05) >= 0)
                {
                    CoinReturn.Add(Coins.NICKEL);
                    CurrentAmount -= 0.05;
                }
            }
        }

        /// <summary>
        /// When the Return Coins button is pressed, the coins that were inserted
        /// into the machine are placed in the Coin Return.
        /// </summary>
        public void ReturnCoins()
        {
            while (CurrentCoins.Count > 0)
            {
                CoinReturn.Add(CurrentCoins[0]);
                CurrentCoins.RemoveAt(0);
            }
        }

        static void Main(string[] args)
        {
        }
    }

    /// <summary>
    /// The Product Class contains the information for each product
    /// contained in the Vending Machine.
    /// </summary>
    public class Product
    {
        //The name of the product
        public string Name { get; private set; }

        //The cost of the product
        public double Cost { get; private set; }

        //The quantity of the product in the machine
        public int Quantity { get; set; }

        /// <summary>
        /// Constructor for the product class.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <param name="cost">The cost of the product.</param>
        public Product(string name, double cost)
        {
            Name = name;
            Cost = cost;
            Quantity = 1;
        }
    }
}
