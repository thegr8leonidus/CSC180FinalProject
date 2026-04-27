using System;
using System.Collections.Generic;
using System.Text;

namespace CSC180_final_project
{
    public class CartItem
    {
        public Item Product { get; private set; }
        public int Quantity { get; private set; }

        public CartItem(Item product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public double TotalPrice()
        {
            return Product.Price * Quantity;
        }
    }
}
