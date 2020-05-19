using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
        void CookDrinks(List<Drink> drinks);
    }
    interface ITakePayment //принять оплату
    {
        void CalculateCheck(List<Drink> drinks);
    }
}
