using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedCombat
{
    internal class Equipment
    {
        protected string name;

        public Equipment(string name)
        {
            this.name = name;  
        }
        public string Name { get; set; }


    }

    
    
}
