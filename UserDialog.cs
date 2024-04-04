using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class UserDialog
    {
        PizzaCatalog PizzaCatalog;
        CustomerCatalog CustomerCatalog;
        OrderCatalog OrderCatalog;

        public UserDialog(PizzaCatalog menuCatalog, CustomerCatalog customerCatalog, OrderCatalog orderCatalog)
        {
            PizzaCatalog = menuCatalog;
            CustomerCatalog = customerCatalog;
            OrderCatalog = orderCatalog;
        }
        public int MainMenuChoiceMethod(List<string> menuItems)
        {
            foreach (string mainMenuChoice in menuItems)
            {
                Console.WriteLine(mainMenuChoice);
            }

            Console.WriteLine("Enter option#: ");
            string mainMenuInput = Console.ReadKey().KeyChar.ToString();

            try
            {
                int mainMenuResult = Int32.Parse(mainMenuInput);
                return mainMenuResult;
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{mainMenuInput}'");
            }
            return -1;
        }
        public int PizzaSettingChoiceMethod(List<string> pizzaSettingItems)
        {
            Console.WriteLine();
            foreach (string pizzaSettingChoice in pizzaSettingItems)
            {
                Console.WriteLine(pizzaSettingChoice);
            }
            Console.WriteLine("Enter option#: ");
            string pizzaSettingInput = Console.ReadKey().KeyChar.ToString();
            try
            {
                int mainMenuResult = Int32.Parse(pizzaSettingInput);
                return mainMenuResult;
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{pizzaSettingInput}'");
            }
            return -1;
        }
        public int CustomerSettingChoiceMethod(List<string> CustomerSettingItems)
        {
            Console.WriteLine();
            foreach (string CustomerSettingChoice in CustomerSettingItems)
            {
                Console.WriteLine(CustomerSettingChoice);
            }
            Console.WriteLine("Enter option#: ");
            string CustomerSettingInput = Console.ReadKey().KeyChar.ToString();
            try
            {
                int CustomerSettingResult = Int32.Parse(CustomerSettingInput);
                return CustomerSettingResult;
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{CustomerSettingInput}'");
            }
            return -1;
        }
        public int OrderSettingChoiceMethod(List<string> OrderSettingItems)
        {
            Console.WriteLine();
            foreach (string OrderSettingChoice in OrderSettingItems)
            {
                Console.WriteLine(OrderSettingChoice);
            }
            Console.WriteLine("Enter option#: ");
            string OrderSettingInput = Console.ReadKey().KeyChar.ToString();
            try
            {
                int OrderSettingResult = Int32.Parse(OrderSettingInput);
                return OrderSettingResult;
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{OrderSettingInput}'");
            }
            return -1;
        }
        public void MainMenu()
        {
            bool MainMenuProceed = true;
            List<string> mainMenuList = new List<string>()
            {
                "0. Quit",
                "1. Pizza settings",
                "2. Customer settings",
                "3. Order settings"
            };
            while (MainMenuProceed)
            {
                Console.WriteLine("Main menu");
                int MainMenuChoice = MainMenuChoiceMethod(mainMenuList);
                Console.Clear();
                switch (MainMenuChoice)
                {
                    case 0:
                        MainMenuProceed = false;
                        Console.WriteLine("Quitting...");
                        break;
                    case 1:
                        PizzaSetting();
                        break;
                    case 2:
                        CustomerSetting();
                        break;
                    case 3:
                        OrderSetting();
                        break;
                }
            }
        }
        public void PizzaSetting()
        {
            bool PizzaSettingProceed = true;
            List<string> pizzaSettingList = new List<string>()
            {
                "0. Back to the main menu",
                "1. Create a Pizza",
                "2. Delete a pizza",
                "3. Update a pizza",
                "4. Search for a pizza",
                "5. Clear the list of pizzas",
                "6. Print the list of pizzas",
            };
            while (PizzaSettingProceed)
            {
                Console.WriteLine("Pizza settings");
                int PizzaSettingChoice = PizzaSettingChoiceMethod(pizzaSettingList);
                Console.Clear();
                switch (PizzaSettingChoice)
                {
                    case 0:
                        PizzaSettingProceed = false;
                        break;
                    case 1:
                        Console.WriteLine("Enter a name: ");
                        string pizzaNameCreateString = Console.ReadLine();
                        Console.WriteLine("Enter a price: ");
                        string pizzaPriceString = "";
                        int pizzaPrice = 0;
                        try
                        {
                            do
                            {
                                pizzaPriceString = Console.ReadLine();
                                pizzaPrice = int.Parse(pizzaPriceString);
                                if (pizzaPrice < 70) 
                                {
                                    Console.WriteLine("Price too low. Minimum 70kr.");
                                }
                            }
                            while (pizzaPrice < 70);
                        } catch (FormatException e) 
                        {
                            Console.WriteLine($"Unable to parse '{pizzaPrice}' - Message: {e.Message}"); throw;
                        }
                        
                        Console.WriteLine("Enter an ID: ");
                        string pizzaIdString = "";
                        int pizzaId = 0;
                        try 
                        {
                            do
                            {
                                pizzaIdString = Console.ReadLine();
                                pizzaId = int.Parse(pizzaIdString);
                            }
                            while (pizzaId == null);
                        } 
                        catch (FormatException e) 
                        {
                            Console.WriteLine($"Unable to parse '{pizzaId}' - Message: {e.Message}"); throw;
                        }
                        Pizza pizzaCreate = PizzaCatalog.GetNewPizza(pizzaNameCreateString,pizzaPrice,pizzaId);
                            if (pizzaCreate == null)
                            {
                                Console.WriteLine("A pizza with that id already exists");
                            }
                            else
                            {
                                PizzaCatalog.RemoveAt(pizzaCreate.PizzaId);
                                PizzaCatalog.CreateAPizza(pizzaCreate);
                                Console.WriteLine($"You created {pizzaCreate.Name} with id: {pizzaCreate.PizzaId} and price: {pizzaCreate.Price}");

                                Console.WriteLine("Press any key to go back to the pizza settings");
                                Console.ReadKey(); Console.Clear();
                            }
                        break;
                    case 2:
                        Console.WriteLine("Which pizza would you like to delete from the list?");
                        PizzaCatalog.PrintMenu();
                        string pizzaDelete = Console.ReadLine();
                        int deleteResult = int.Parse(pizzaDelete);
                        Console.WriteLine($"Are you sure you want to delete pizza {deleteResult} from the list?\ny/n");
                        string deleteAnswer = Console.ReadLine();
                        if (deleteAnswer == "y")
                        {
                            PizzaCatalog.DeleteAPizza(deleteResult);
                            Console.WriteLine($"You deleted pizza {deleteResult} from the list");
                        }
                        else
                        {
                            Console.WriteLine($"You did not delete {deleteResult} from the list");
                        }
                        Console.WriteLine("Press any key to go back to the pizza settings");
                        Console.ReadKey(); Console.Clear();
                        break;
                    case 3:
                        PizzaCatalog.PrintMenu();
                        Console.WriteLine("Which pizza would you like to update?\nEnter number: ");
                        string choosePizzaString = Console.ReadLine();
                        int choosePizza = int.Parse(choosePizzaString);
                        if (PizzaCatalog.SearchForPizzaById(choosePizza) != null)
                        {
                            Console.Clear();
                            Console.WriteLine("Enter the new pizza name: ");
                            string pizzaName = Console.ReadLine();
                            Pizza updatePizza = new Pizza(pizzaName, PizzaCatalog.SearchForPizzaById(choosePizza).Price, choosePizza);
                            PizzaCatalog.UpdatePizza(updatePizza);
                            Console.WriteLine($"Pizza {choosePizza} is now updated to {pizzaName}");
                            Console.WriteLine("Would you like to update the price too?\ny/n");
                            string updatePizzaAnswer = Console.ReadLine();
                            if (updatePizzaAnswer == "y")
                            {
                                Console.WriteLine("Enter a new price");
                                string newPriceString = Console.ReadLine();
                                try
                                {
                                    int newPrice = int.Parse(newPriceString);
                                    PizzaCatalog.SearchForPizzaById(choosePizza).Price = newPrice;
                                    Console.WriteLine($"Price for {pizzaName} is now {newPrice} kr.");
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine($"Unable to parse {newPriceString}\nPrice is unchanged.");
                                }

                            }
                            else
                            {
                                Console.WriteLine($"Pizza {choosePizza} updated to {pizzaName} with unchanged price");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Pizza does not exist");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Find a pizza by its pizzaID: ");
                        string findPizzaById = Console.ReadLine();
                        int resultPizzaId = int.Parse(findPizzaById);
                        Console.WriteLine(PizzaCatalog.SearchForPizzaById(resultPizzaId));
                        break;
                    case 5:
                        Console.WriteLine("Are you sure you want to clear the list of pizzas?\ny/n");
                        string answer = Console.ReadLine();
                        if (answer == "y")
                        {
                            PizzaCatalog.Clear();
                            Console.WriteLine("You cleared the list of pizzas\n");
                        }
                        else
                        {
                            Console.WriteLine("You did not clear the list of pizzas");
                        }
                        break;
                    case 6:
                        if (PizzaCatalog.Count > 1)
                        {
                            PizzaCatalog.PrintMenu();
                        }
                        else
                        {
                            Console.WriteLine("The pizza list is empty");
                        }
                        Console.WriteLine("\nPress any key to go back to the pizza settings");
                        Console.ReadKey(); Console.Clear();
                        break;
                    case 7:

                        break;
                }
            }

        }
        public void CustomerSetting()
        {
            bool CustomerSettingProceed = true;
            List<string> CustomerSettingList = new List<string>()
            {
                "0. Back to the main menu",
                "1. Create a Customer",
                "2. Delete a Customer",
                "3. Update a Customer",
                "4. Search for a Customer",
                "5. Clear the list of Customers",
                "6. Print the list of Customers",
            };
            while (CustomerSettingProceed)
            {
                Console.WriteLine("Customer settings");
                int CustomerSettingChoice = CustomerSettingChoiceMethod(CustomerSettingList);
                Console.Clear();
                switch (CustomerSettingChoice)
                {
                    case 0:
                        CustomerSettingProceed = false;
                        break;
                    case 1:
                        Console.WriteLine("Enter a name: ");
                        string inputCustomerNameString = Console.ReadLine();
                        Console.WriteLine("Enter an id number: ");
                        string inputCustomerIdString = Console.ReadLine();
                        int inputCustomerId = int.Parse(inputCustomerIdString);
                        Customer customerCreate = CustomerCatalog.GetNewCustomer(inputCustomerNameString,inputCustomerId);
                        if (customerCreate == null)
                        {
                            Console.WriteLine($"Customer with that id already exists");
                        }
                        else
                        {
                            CustomerCatalog.RemoveAt(customerCreate.CustomerId);
                            CustomerCatalog.CreateACustomer(customerCreate);
                            Console.WriteLine($"You created {customerCreate.CustomerName} with id: {customerCreate.CustomerId}");
                            Console.ReadKey(); Console.Clear();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Which customer would you like to delete from the list?");
                        CustomerCatalog.PrintCustomerList();
                        string customerDelete = Console.ReadLine();
                        int deleteResult = int.Parse(customerDelete);
                        Console.WriteLine($"Are you sure you want to delete customer {deleteResult} from the list?\ny/n");
                        string deleteAnswer = Console.ReadLine();
                        if (deleteAnswer == "y")
                        {
                            CustomerCatalog.DeleteACustomer(deleteResult);
                            Console.WriteLine($"You deleted customer {deleteResult} from the list");
                        }
                        else
                        {
                            Console.WriteLine($"You did not delete customer {deleteResult} from the list");
                        }
                        Console.WriteLine("Press any key to go back to the customer settings");
                        Console.ReadKey(); Console.Clear();
                        break;
                    case 3:
                        CustomerCatalog.PrintCustomerList();
                        Console.WriteLine("Which customer would you like to update?\nEnter number: ");
                        string chooseCustomerString = Console.ReadLine();
                        int chooseCustomer = int.Parse(chooseCustomerString);
                        if (CustomerCatalog.SeachForCustomerById(chooseCustomer) != null)
                        {
                            Console.WriteLine("Enter the new customer name: ");
                            string customerName = Console.ReadLine();
                            Customer updateCustomer = new Customer(customerName, chooseCustomer);
                            CustomerCatalog.UpdateCustomer(updateCustomer);
                            Console.WriteLine($"You updated customer {chooseCustomer}. Customer {chooseCustomer} is now {customerName}");
                        }
                        else
                        {
                            Console.WriteLine("Customer does not exist");
                        }
                        break;
                    case 4:
                        //    Console.WriteLine("Find a customer by a name: ");
                        //    string findCustomerString = Console.ReadLine();
                        //    _customerCatalog.SearchCustomerByName(findCustomerString);
                        //    if (_customerCatalog.SearchCustomerByName(findCustomerString).CustomerName == findCustomerString)
                        //    {
                        //        Console.WriteLine($"Found a customer with name: {findCustomerString}");
                        //    }
                        break;
                    case 5:
                        Console.WriteLine("Are you sure you want to clear the list of customers?\ny/n");
                        string answer = Console.ReadLine();
                        if (answer == "y")
                        {
                            CustomerCatalog.Clear();
                            Console.WriteLine("You cleared the list of customers\n");
                        }
                        else
                        {
                            Console.WriteLine("You did not clear the list of customers");
                        }
                        break;
                    case 6:
                        CustomerCatalog.PrintCustomerList();
                        break;
                }
            }
        }
        public void OrderSetting()
        {
            bool OrderSettingProceed = true;
            List<string> OrderSettingList = new List<string>()
            {
                "0. Back to the main menu",
                "1. Create an order from existing customer and pizza",
                "2. Create an order with new customer and pizza",
                "3. Delete an order",
                "4. Update and order",
                "5. Search for an order",
                "6. Clear the list of orders",
                "7. Print the list of orders",
            };
            while (OrderSettingProceed)
            {
                Console.WriteLine("Order settings");
                int OrderSettingChoice = OrderSettingChoiceMethod(OrderSettingList);
                Console.Clear();
                switch (OrderSettingChoice)
                {
                    case 0:
                        OrderSettingProceed = false;
                        break;
                    case 1:
                        CustomerCatalog.PrintCustomerList();
                        Console.WriteLine("Enter customer ID: ");
                        string customerToOrderString = Console.ReadLine();
                        int customerToOrder = int.Parse(customerToOrderString);

                        PizzaCatalog.PrintMenu();
                        Console.WriteLine("Enter pizza ID: ");
                        string pizzaToOrderString = Console.ReadLine();
                        int pizzaToOrder = int.Parse(pizzaToOrderString);

                        Console.WriteLine("Enter number of pizzas: ");
                        string noOfPizzasString = Console.ReadLine();
                        int noOfPizzas = int.Parse(noOfPizzasString);

                        Console.WriteLine("Enter order ID: ");
                        string orderIdString = Console.ReadLine();
                        int orderId = int.Parse(orderIdString);

                        OrderCatalog.SeachForOrderById(orderId);
                        if (OrderCatalog.SeachForOrderById(orderId) != null)
                        {
                            Console.WriteLine($"You are about to overrite an existing order. \nAre you sure you want to overwrite {OrderCatalog.SeachForOrderById(orderId)}?\ny/n");
                            string overrideString = Console.ReadLine();
                            if (overrideString == "y")
                            {
                                OrderCatalog.RemoveAt(orderId);
                                OrderCatalog.AddAnOrderToTheList(OrderCatalog.GetNewOrderFromExisting(CustomerCatalog.SeachForCustomerById(customerToOrder), PizzaCatalog.SearchForPizzaById(pizzaToOrder), noOfPizzas, orderId));
                                Console.WriteLine($"\nThe order was overwritten with {OrderCatalog.SeachForOrderById(orderId)}\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You did not override the existing order");
                        }

                        break;
                    case 2:
                        Console.WriteLine("Enter order ID: ");
                        string newOrderIdString = Console.ReadLine();
                        int newOrderId = int.Parse(newOrderIdString);
                        Console.WriteLine("Enter number of pizzas: ");
                        string noOfNewPizzasString = Console.ReadLine();
                        int noOfNewPizzas = int.Parse(noOfNewPizzasString);
                        OrderCatalog.AddAnOrderToTheList(OrderCatalog.GetNewOrder(CustomerCatalog.GetNewCustomer("",0), PizzaCatalog.GetNewPizza("",0,0), newOrderId, noOfNewPizzas));
                        break;
                    case 3:
                        OrderCatalog.PrintOrderList();
                        Console.WriteLine("Which order would you like to delete?\nEnter a number: ");
                        string deleteOrderString = Console.ReadLine();
                        int deleteOrder = int.Parse(deleteOrderString);
                        OrderCatalog.DeleteAnOrder(deleteOrder);
                        Console.WriteLine($"You deleted order {deleteOrder} from the list");
                        break;
                    case 4:
                        OrderCatalog.PrintOrderList();
                        Console.WriteLine("Which order would you like to order?\nEnter a number: ");
                        string updateOrderString = Console.ReadLine();
                        int updateOrder = int.Parse(updateOrderString);
                        OrderCatalog.UpdateOrder(updateOrder);
                        Console.WriteLine($"You updated order {updateOrder}");
                        break;
                    case 5:
                        //Console.WriteLine("Find a customer by a name: ");
                        //string findCustomer = Console.ReadLine();
                        //_customerCatalog.SearchCustomerByName(findCustomer);
                        //Console.WriteLine();
                        //Console.ReadKey();
                        break;
                    case 6:
                        Console.WriteLine("Are you sure you want to clear the list of customers?\ny/n");
                        string answer = Console.ReadLine();
                        if (answer == "y")
                        {
                            CustomerCatalog.Clear();
                            Console.WriteLine("You cleared the list of customers\n");
                        }
                        else
                        {
                            Console.WriteLine("You did not clear the list of customers");
                        }
                        break;
                    case 7:
                        OrderCatalog.PrintOrderList();
                        break;
                }
            }
        }
    }
}
