using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class EmptyName : FormatException
    {
        public EmptyName() 
        {
            
        }
        public EmptyName(string message) : base(message) 
        {
            
        }
    }
}
