﻿using System;
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
        public ArrayList StoredCoins { get; private set; }
        public Product Cola { get; private set; }
        public Product Chips { get; private set; }
        public Product Candy { get; private set; }
        public double CurrentAmount { get; private set; }
        public string Display { get; private set; }

        public VendingMachine()
        {
            CurrentCoins = new ArrayList();
            CoinReturn = new ArrayList();
            StoredCoins = new ArrayList();
            Cola = new Product("cola", 1.00);
            Chips = new Product("chips", 0.50);
            Candy = new Product("candy", 0.65);
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
            string message = Display;
            if (message == "THANK YOU")
            {
                Display = "INSERT COIN";
            }
            else if (message.StartsWith("PRICE"))
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

        public string SelectProduct(string product)
        {
            switch (product)
            {
                case "cola":
                    if (CurrentAmount >= Cola.Cost)
                    {
                        CurrentAmount = 0.00;
                        Display = "THANK YOU";
                        return "cola";
                    }
                    else
                    {
                        Display = $"PRICE {Cola.Cost:0.00}";
                        return null;
                    }

                case "chips":
                    if (CurrentAmount >=Chips.Cost)
                    {
                        CurrentAmount = 0.00;
                        Display = "THANK YOU";
                        return "chips";
                    }
                    else
                    {
                        Display = $"PRICE {Chips.Cost:0.00}";
                        return null;
                    }

                case "candy":
                    if (CurrentAmount >= Candy.Cost)
                    {
                        CurrentAmount = 0.00;
                        Display = "THANK YOU";
                        return "candy";
                    }
                    else
                    {
                        Display = $"PRICE {Candy.Cost:0.00}";
                        return null;
                    }

                default:
                    return null;
            }
        }

        static void Main(string[] args)
        {
        }
    }

    public class Product
    {
        public string Name { get; private set; }
        public double Cost { get; private set; }

        public Product(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}
