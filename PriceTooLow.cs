using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class PriceTooLow:Exception
    {
        public PriceTooLow() 
        {
            
        }
        public PriceTooLow(string message) : base(message) { }
    }
}
