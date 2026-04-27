namespace CSC180_final_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            Console.WriteLine("=== Welcome to the Grocery Store ===");

            while (true)
            {
                Console.WriteLine("\n1. View Inventory");
                Console.WriteLine("2. Add Item to Cart");
                Console.WriteLine("3. View Cart");
                Console.WriteLine("4. Checkout");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowInventory(store);
                        break;
                    case "2":
                        AddItemToCart(store);
                        break;
                    case "3":
                        ShowCart(store);
                        break;
                    case "4":
                        Checkout(store);
                        return;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void ShowInventory(Store store)
        {
            Console.WriteLine("\n=== Inventory ===");
            foreach (var item in store.Inventory)
            {
                Console.WriteLine($"{item.Name} - ${item.Price}");
            }
        }

        static void AddItemToCart(Store store)
        {
            Console.Write("Enter item name: ");
            string name = Console.ReadLine();

            Item found = store.FindItem(name);

            if (found == null)
            {
                Console.WriteLine("Item not found.");
                return;
            }

            Console.Write("Enter quantity: ");
            int qty = Convert.ToInt32(Console.ReadLine());

            store.AddToCart(found, qty);
            Console.WriteLine($"{qty} x {found.Name} added to cart.");
        }

        static void ShowCart(Store store)
        {
            Console.WriteLine("\n=== Your Cart ===");
            foreach (var c in store.Cart)
            {
                Console.WriteLine($"{c.Product.Name} x{c.Quantity} = ${c.TotalPrice():0.00}");
            }
            Console.WriteLine($"TOTAL: ${store.CartTotal():0.00}");
        }

        static void Checkout(Store store)
        {
            Console.WriteLine("\n=== Checkout ===");
            ShowCart(store);

            store.SaveReceipt();
            Console.WriteLine("Receipt saved to receipt.txt");
        }
    }
}