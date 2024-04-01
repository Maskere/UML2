using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class BigMamma
    {
        #region Instance Field
        private Order _order;
        private Customer _customerName;
        private Pizza _pizzaName;
        private int _numberOfPizzasInOrder;
        private string _orderID;
        private Invoice _invoice;
        private MenuCatalog _menuCatalog;
        #endregion

        #region Constructor
        public BigMamma() 
        {
            _order = new Order(CustomerName,Pizza, NumberOfPizzasInOrder);
            _customerName = CustomerName;
            _numberOfPizzasInOrder = NumberOfPizzasInOrder;
            _invoice = Invoice;
            _menuCatalog = new MenuCatalog();
        }
        #endregion

        #region Properties
       public Order Order 
        {
            get { return _order; }
        }
        public Customer CustomerName
        { 
            get { return _customerName; } 
        }
        public Pizza Pizza
        {
            get { return _pizzaName; }
        }
        public int NumberOfPizzasInOrder 
        {
            get { return _numberOfPizzasInOrder; }
        }
        public string OrderID
        { 
            get { return _orderID; } 
        }
        public Invoice Invoice
        {
            get { return _invoice; }
        }
        public MenuCatalog MenuCatalog 
        { 
            get { return _menuCatalog; } 
        }
        #endregion

        #region Methods
        public void Start()
        {
            Customer customer1 = new Customer("Miki");
            Pizza pizza1 = new Pizza("Vichinga", 80,12);
            MenuCatalog.CreateAPizza(pizza1);
            Order order1 = new Order(customer1, pizza1, 1);
            order1.CalculateTotalPrice();
            Invoice invoice1 = new Invoice(order1);
            Console.WriteLine(order1);
            Console.WriteLine(invoice1);
            Console.WriteLine();

            Customer customer2 = new Customer("Lucas");
            Pizza pizza2 = new Pizza("Calzone", 80,4);
            MenuCatalog.CreateAPizza(pizza2);
            Order order2 = new Order(customer2, pizza2, 3);
            order2.CalculateTotalPrice();
            Invoice invoice2 = new Invoice(order2);
            Console.WriteLine(order2);
            Console.WriteLine(invoice2);
            Console.WriteLine();

            Customer customer3 = new Customer("Nikolaj");
            Pizza pizza3 = new Pizza("Romana", 78,17);
            MenuCatalog.CreateAPizza(pizza3);
            Order order3 = new Order(customer3, pizza3, 1);
            order3.CalculateTotalPrice();
            Invoice invoice3 = new Invoice(order3);
            Console.WriteLine(order3);
            Console.WriteLine(invoice3);

            Console.WriteLine();
        }
        public void Test()
        {
            Pizza pizza1 = new Pizza("Margherita", 69, 1);
            MenuCatalog.CreateAPizza(pizza1);
            Pizza pizza2 = new Pizza("Calzone", 80, 4);
            MenuCatalog.CreateAPizza(pizza2);
            Pizza pizza3 = new Pizza("Italiana", 75, 8);
            MenuCatalog.CreateAPizza(pizza3);

            new UserDialog(MenuCatalog).MainMenu();
        }
        public override string ToString()
        {
            return $"";
        }
        #endregion
    }
}
