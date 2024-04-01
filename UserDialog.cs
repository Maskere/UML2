using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class UserDialog
    {
        private MenuCatalog _menuCatalog;
        private EmptyName _emptyName;
        private NameCannotContainNumbers _nameCannotContainNumbers;
        private PriceTooLow _priceTooLow;

        public UserDialog(MenuCatalog menuCatalog) 
        {
            _menuCatalog = menuCatalog;
        }
        Pizza GetNewPizza()
        {
            Console.WriteLine("Enter the pizza name: ");
            string pizzaName = Console.ReadLine();

            Pizza pizza = new Pizza(pizzaName, 0, 0);
            string input = "";
            Console.WriteLine("Enter a price: ");
            try 
            {
                input = Console.ReadLine();
                pizza.Price = Int32.Parse(input);
                if (pizza.Price < 70) 
                {
                    throw new PriceTooLow($"Price too low. Minimum 70 kr.");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Unable to parse '{input}' - Message: {e.Message}"); throw ;
            }
            Console.WriteLine("Enter the pizza number: ");
            string idInput = "";
            try 
            {
                idInput = Console.ReadLine();
                pizza.PizzaId = Int32.Parse(idInput);
            }
            catch (FormatException e)
            { 
                Console.WriteLine($"Please enter a number. {e.Message}"); throw;
            }
            return pizza;
        }
        Pizza UpdatePizza(int pizzaId) 
        {
            Console.WriteLine("Enter the pizza name: ");
            string pizzaName = Console.ReadLine();
            Pizza pizza = new Pizza(pizzaName,0,pizzaId);
            string input = "";
            Console.WriteLine("Enter a price(min. 70): ");
            try 
            {
                input = Console.ReadLine();
                pizza.Price = Int32.Parse(input);
                if (pizza.Price < 70)
                {
                    PriceTooLow e = new PriceTooLow("Price too low");
                    throw e;
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Unable to parse '{input}' - Message: {e.Message}");
                throw;
            }
            return pizza;
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
                        Pizza pizzaCreate = GetNewPizza();
                        _menuCatalog.RemoveAt(pizzaCreate.PizzaId);
                        _menuCatalog.CreateAPizza(pizzaCreate);
                        Console.WriteLine($"You created {pizzaCreate.Name} with id: {pizzaCreate.PizzaId} and price: {pizzaCreate.Price}");

                        Console.WriteLine("Press any key to go back to the pizza settings");
                        Console.ReadKey(); Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("Which pizza would you like to delete from the list?");
                        _menuCatalog.PrintMenu();
                        string pizzaDelete = Console.ReadLine();
                        int deleteResult = int.Parse(pizzaDelete);
                        Console.WriteLine($"Are you sure you want to delete pizza {deleteResult} from the list?\ny/n");
                        string deleteAnswer = Console.ReadLine();
                        if (deleteAnswer == "y")
                        {
                            _menuCatalog.DeleteAPizza(deleteResult);
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
                        Console.WriteLine("Which pizza would you like to update from the list?");
                        _menuCatalog.PrintMenu();
                        string updatePizza = Console.ReadLine();
                        int updateResult = int.Parse(updatePizza);
                        Pizza pizzaUpdate = UpdatePizza(updateResult);
                        _menuCatalog.RemoveAt(updateResult);
                        _menuCatalog.CreateAPizza(pizzaUpdate);
                        Console.WriteLine();
                        Console.WriteLine($"You updated pizza {updatePizza}.\n Pizza {updatePizza} is now {pizzaUpdate}");
                        break;
                    case 4:
                        Console.WriteLine("Find a pizza by its pizzaID: ");
                        string pizzaId= Console.ReadLine();
                        int resultPizzaId = int.Parse(pizzaId);
                        Console.WriteLine(_menuCatalog.SearchPizza(resultPizzaId));
                        break;
                    case 5:
                        Console.WriteLine("Are you sure you want to clear the list?\ny/n");
                        string answer = Console.ReadLine();
                        if (answer == "y")
                        {
                            _menuCatalog.Clear();
                            Console.WriteLine("You cleared the list\n");
                        }
                        else 
                        {
                            Console.WriteLine("You did not clear the list");
                        }
                        break;
                    case 6:
                        if (_menuCatalog.Count > 1)
                        {
                            _menuCatalog.PrintMenu();
                        }
                        else
                        {
                            Console.WriteLine("The pizza list is empty");
                        }
                        Console.WriteLine("\nPress any key to go back to the pizza settings");
                        Console.ReadKey();Console.Clear();
                        break;
                }
            }

        }
    }
}
