using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace hw23_SOLID
{
    
    public class Drink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Drink(int id, string name, decimal price)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
        }
    }
    public class CoffeeShop
    {
        public static List<Drink> menu = new List<Drink>();
        public IShowMenu show { get; set; }
        public ITakeAnOrder take { get; set; }
        public ITakePayment getpay { get; set; }
        public ICookDrink cook { get; set; }
        public IChangeMenu change { get; set; }

        public void ChangeMenuList()
        {
            Console.Write("Choose actions:\n1 - Add new drink \n2 - Change price");
            int command = int.Parse(Console.ReadLine());
            switch(command)
            {
                case 1:
                    change.AddNewDrink();
                    break;
                case 2:
                    change.ChangePrice();
                    break;
            }
        }

        public void SurviveClient() //обслужить клиента
        {
            show.ShowMenu();

        }
    }
    public interface IChangeMenu
    {
        void AddNewDrink();
        void ChangePrice();
    }
    class ExpandMenu: MenuForm, IChangeMenu
    {
        public void AddNewDrink()
        {
            Console.Write ("Name: ");
            string name = Console.ReadLine();
            Console.Write("Price (x.yy): ");
            decimal price = decimal.Parse(Console.ReadLine());
            CoffeeShop.menu.Add(new Drink(++Program.idCounter, name, price));
        }
        public void ChangePrice()
        {
            ShowMenu();
            Console.Write("Choose drink id: ");
            int id = int.Parse(Console.ReadLine());
            var index = CoffeeShop.menu.FindIndex(i => i.Id == id);

            Console.Write("New price: ");
            decimal newPrice = decimal.Parse(Console.ReadLine()); 
            CoffeeShop.menu[index].Price = newPrice;

            Console.WriteLine($"{CoffeeShop.menu[index].Name} price was changed!");
        }

    }
    public interface IShowMenu
    {
        void ShowMenu();
    }
    
    public interface ITakeAnOrder //принять заказ
    {
        
        List<Drink> GetAnOrderList();
    }
    class MenuForm: IShowMenu
    {
        public void ShowMenu()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ResetColor();
            Console.WriteLine("        MENU       ");
            Console.WriteLine("----------------------");
            foreach (var i in CoffeeShop.menu)
                Console.WriteLine($"{i.Id}. {i.Name} - {i.Price} somoni");
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
                ShowMenu();
                Console.WriteLine("Choose one drink id");
                Console.Write("Answer: ");
                int id = int.Parse(Console.ReadLine());
                var newDrink = CoffeeShop.menu.Where(i => i.Id == id).Last();
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
    public interface ICookDrink //Приготовить напитки
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
    public interface ITakePayment //принять оплату
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
