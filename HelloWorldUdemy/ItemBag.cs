using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedCombat
{
    internal class ItemBag
    {
        internal List<Items> itemList = new List<Items>();
        public List<Items> ItemList { get; set; }

        internal void selectItem()
        {
            
            while (itemList != null)
            {
                Console.WriteLine("Items: " + itemList);
                string itemPrompt = Console.ReadLine().ToLower();
                foreach (Items selectItem in itemList)
                {
                    
                }
                Console.WriteLine("Your Item bag is empty..");
                break;
            }
        }

        internal void ShowInventory()
        {
            Console.WriteLine(itemList);
        }
    }
}
