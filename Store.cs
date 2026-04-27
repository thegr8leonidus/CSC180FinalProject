using System;
using System.Collections.Generic;
using System.Text;

namespace CSC180_final_project
{
    public class Store
    {
        public List<Item> Inventory { get; private set; } = new List<Item>();
        public List<CartItem> Cart { get; private set; } = new List<CartItem>();

        public Store()
        {
            LoadInventory();
        }

        private void LoadInventory()
        {
            Inventory.Add(new Item("Milk", 2.99, new string[] { "Milk", "Vitamin D" }));
            Inventory.Add(new Item("Bread", 1.99, new string[] { "Flour", "Yeast", "Salt" }));
            Inventory.Add(new Item("Eggs", 3.99, new string[] { "Eggs" }));
            Inventory.Add(new Item("Cheese", 4.99, new string[] { "Milk", "Salt", "Enzymes" }));
            Inventory.Add(new Item("Butter", 5.99, new string[] { "Cream", "Salt" }));
            Inventory.Add(new Item("Chicken Breast", 7.49, new string[] { "Chicken" }));
        }

        public Item FindItem(string name)
        {
            foreach (var item in Inventory)
            {
                if (item.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    return item;
            }
            return null;
        }

        public void AddToCart(Item item, int quantity)
        {
            Cart.Add(new CartItem(item, quantity));
        }

        public double CartTotal()
        {
            double total = 0;
            foreach (var c in Cart)
                total += c.TotalPrice();
            return total;
        }

        public void SaveReceipt()
        {
            using (StreamWriter writer = new StreamWriter("receipt.txt"))
            {
                writer.WriteLine("===== RECEIPT =====");
                foreach (var c in Cart)
                {
                    writer.WriteLine($"{c.Product.Name} x{c.Quantity} = ${c.TotalPrice():0.00}");
                }
                writer.WriteLine($"TOTAL: ${CartTotal():0.00}");
            }
        }
    }
}
