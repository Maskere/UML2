using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class MenuCatalog
    {
        List<Pizza> _pizzas;
        int _id;
        public MenuCatalog()
        {
            _pizzas = new List<Pizza>(new Pizza[10]);
        }
        public int Count
        {
            get { return _pizzas.Count; }
        }
        public void CreateAPizza(Pizza pizza)
        {
            _pizzas.Insert(pizza.PizzaId, pizza);
            if (pizza.PizzaId > _pizzas.Count) { _pizzas = new List<Pizza>(new Pizza[pizza.PizzaId]); }
        }
        public void DeleteAPizza(int pizzaId)
        {
            _pizzas.Insert(pizzaId,new Pizza("",0,0));
            _pizzas.RemoveAt(pizzaId+1);
        }
        public Pizza SearchPizza(int pizzaId)
        {
            Pizza findPizza = _pizzas[pizzaId];
            return findPizza;
        }
        public void Clear()
        {
            _pizzas.Clear();
            _pizzas = new List<Pizza>(new Pizza[10]);
        }
        public void RemoveAt(int removeAt)
        {
            if (removeAt > _pizzas.Count) { _pizzas = new List<Pizza>(new Pizza[removeAt]); }
            _pizzas.RemoveAt(removeAt);
        }
        public void PrintMenu()
        {
            Console.WriteLine($"There are {_pizzas.Count} items on the list");
            foreach (Pizza pizza in _pizzas) 
            {
                if (pizza != null)
                {
                    Console.WriteLine($"| {pizza} |");
                }
                else 
                { 
                    Console.WriteLine("   ...");
                }
            }
        }
    }
}
