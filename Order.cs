using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class Order
    {
        #region Instance Field
        private Pizza _pizzaName;
        private Customer _customerName;
        private int _numberOfPizzasInOrder;
        private int _orderID;
        private double _totalPrice;
        private static int _orderIDCounter=0;
        #endregion

        #region Constructor
        public Order(Customer CustomerName, Pizza PizzaName, int NumberOfPizzasInOrder)
        {
            _orderID = _orderIDCounter++;
            _customerName = CustomerName;
            _pizzaName = PizzaName;
            _numberOfPizzasInOrder = NumberOfPizzasInOrder;
            _totalPrice = TotalPrice;
        }
        #endregion

        #region Properties
        public Pizza PizzaName
        {
            get { return _pizzaName; }
        }
        public Customer CustomerName
        { 
            get { return _customerName; } 
        }
        public int NumberOfPizzasInOrder 
        {
            get { return _numberOfPizzasInOrder; }
        }
        public int OrderID
        { 
            get { return _orderID; }
        }
        public double TotalPrice
        { 
            get { return _totalPrice; } 
        }
        public static int OrderIDCounter
        {
            get { return _orderIDCounter; }
        }
        #endregion

        #region Methods
        public void CalculateTotalPrice()
        {
            _totalPrice = PizzaName.Price * _numberOfPizzasInOrder + 40;
        }
        public override string ToString() 
        {
            return $"Order {OrderID}: {NumberOfPizzasInOrder} x {PizzaName} for {CustomerName}";
        }
        #endregion
    }
}
