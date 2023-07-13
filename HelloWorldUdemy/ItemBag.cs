using System;
using System.Collections.Generic;

namespace TurnBasedCombat
{
    internal class ItemBag
    {
        private List<Item> itemList = new List<Item>();

        internal void SelectItem(Player player)
        {
            Console.WriteLine("Items in the bag:");
            ShowInventory();

            if (itemList.Count == 0)
            {
                Console.WriteLine("Your item bag is empty.");
                return;
            }

            Console.Write("Enter the name of the item you want to use: ");
            string itemPrompt = Console.ReadLine().ToLower();

            Item selectedItem = itemList.Find(item => item.ItemName.ToLower() == itemPrompt);

            if (selectedItem != null)
            {
                Console.WriteLine(player.name + " just used " + selectedItem.ItemName + "...");
                UseItem(selectedItem);
            }
            else
            {
                Console.WriteLine("Invalid item selection.");
            }
        }

        internal void UseItem(Item selectedItem)
        {
            Player player = new Player();
            Console.WriteLine(player.name + " used " + selectedItem.ItemName + "...");
            player.health += 10;
            // TODO: Implement the logic to use the selected item
            
        }

        internal void AddItem(Item item)
        {
            itemList.Add(item);
            Console.WriteLine(item.ItemName + " added to the item bag.");
        }

        internal void RemoveItem(Item item)
        {
            bool success = itemList.Remove(item);
            if (success)
            {
                Console.WriteLine(item.ItemName + " removed from the item bag.");
            }
            else
            {
                Console.WriteLine(item.ItemName + " not found in the item bag.");
            }
        }

        internal void ShowInventory()
        {
            if (itemList.Count > 0)
            {
                foreach (Item item in itemList)
                {
                    Console.WriteLine("- " + item.ItemName);
                }
            }
            else
            {
                Console.WriteLine("No items; the bag is empty...");
            }
        }
    }
}
