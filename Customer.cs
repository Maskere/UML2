using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class Customer
    {
        #region Instance Field
        private string _customerName;
        private string _email;
        private string _phoneNumber;
        #endregion

        #region Constructor
        public Customer(string Name)
        {
            _customerName = Name;
            _phoneNumber = PhoneNumber;
            _email = Email;
        }
        #endregion

        #region Properties
        public string CustomerName
        {
            get { return _customerName; }
        }
        public string Email
        {
            get { return _email; }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
        }
        #endregion

        #region Methods
        public override string ToString() 
        {
            return $"{CustomerName}";
        }
        #endregion
    }
}
