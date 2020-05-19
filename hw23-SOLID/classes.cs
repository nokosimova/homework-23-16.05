using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace hw23_SOLID
{
    
    public class Drink
    {
        public int id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    public class CoffeeShop
    {
        public static List<Drink> menu = new List<Drink>();
        public void SurviveClient() //обслужить клиента
        {
        }
    }
    interface IShowMenu
    {
        void ShowMenu(List<Drink> menu);
    }
    
    interface ITakeAnOrder //принять заказ
    {
        
        List<Drink> GetAnOrderList();
    }
    class MenuForm: IShowMenu
    {
        public void ShowMenu(List<Drink> menu)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ResetColor();
            Console.WriteLine("        MENU       ");
            Console.WriteLine("----------------------");
            foreach (var i in menu)
                Console.WriteLine($"{i.id}. {i.Name} - {i.Price} somoni");
        }
    }
    class TakeAnOrder : MenuForm, ITakeAnOrder
    {
        public List<Drink> GetAnOrderList()
        {
            bool act = true;
            List<Drink> orderedDrinks = new List<Drink>();
            while(act)
            {
                Console.WriteLine("Choose one drink id");
                ShowMenu(CoffeeShop.menu);
                Console.Write("Answer: ");
                int id = int.Parse(Console.ReadLine());
                var newDrink = CoffeeShop.menu.Where(i => i.id == id).Last();
                orderedDrinks.Add(newDrink);
                Console.WriteLine("Any other drinks ?Y(yes)/N(no)");
                string ans = Console.ReadLine();
                if (ans == "Y")
                {
                    act = false;
                    Console.WriteLine("Thank you, your order was accepted!");
                }
            }
            return orderedDrinks;
        }
                         
    }
    interface ICookDrink //Приготовить напитки
    {
        void CookAll(List<Drink> drinks);
    }
    class CookDrinks : ICookDrink
    {
        public void CookAll(List<Drink> drinks)
        {
            foreach (var i in drinks)
            {
                Console.Write($"{i.Name} is cooking  ... ");
                Thread.Sleep(900);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ResetColor();
                Console.WriteLine($"  {i.Name} is ready!");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ResetColor();
            }
            Console.WriteLine("--------------------");
            Console.WriteLine("All drinks are ready!");
        }
    }
    interface ITakePayment //принять оплату
    {
        void CalculateCheck(List<Drink> drinks);             
    }
    class Payment: ITakePayment
    {
        public void CalculateCheck(List<Drink> drinks)
        {
            decimal sum = 0;
            string time = DateTime.Now.ToString();
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ResetColor();
            Console.WriteLine("--------------------------");
            Console.WriteLine($"-----{time}-------");
            foreach (var i in drinks)
            {
                sum = sum + i.Price;
                Console.WriteLine($"{i.Name}----------{i.Price}");
            }
            Console.WriteLine($"SUM :  {sum} somoni");
        }
    }
}
