namespace TurnBasedCombat
{
    internal class Item
    {
        protected string itemName;
        protected int total;
        protected bool singleUse;

        public Item(string itemName, int total, bool singleUse)
        {
            this.itemName = itemName;
            this.total = total;
            this.singleUse = singleUse;
        }   
        public Item()
        {
        }
        public string ItemName { get { return itemName; } }
        public int Total { get { return total; } }


    }
}