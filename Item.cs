using System;
using System.Collections.Generic;
using System.Text;

namespace CSC180_final_project
{
    public class Item : IPriceable
    {
        private string name;
        private double price;
        private string[] ingredients;

        public string Name { get { return name; } }
        public double Price { get { return price; } }
        public string[] Ingredients { get { return ingredients; } }

        public Item(string name, double price, string[] ingredients)
        {
            this.name = name;
            this.price = price;
            this.ingredients = ingredients;
        }

        public double GetPrice()
        {
            return price;
        }
    }
}