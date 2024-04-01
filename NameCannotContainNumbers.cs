using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class NameCannotContainNumbers:FormatException
    {
        public NameCannotContainNumbers() { }
        public NameCannotContainNumbers(string message) : base(message) { }
    }
}
