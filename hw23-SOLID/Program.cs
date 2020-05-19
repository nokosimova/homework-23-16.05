using System;

using System.Collections.Generic;

namespace hw23_SOLID
{
    class Program
    {
        public static int idCounter = 0;
        static void Main(string[] args)
        {
            /*в данной программе реализован класс СoffeeShop, 
              который состоит из меню напитков. */
            bool act = true;
            CoffeeShop StarBucks = new CoffeeShop();

            while (act)
            {
                Console.Clear();
                Console.WriteLine("Choose actions:\n1 - Change menu \n2 - Survive client\n3 - Exit");
                int command = int.Parse(Console.ReadLine());
                switch (command)
                {
                    case 1:
                        StarBucks.ChangeMenuList();
                        break;
                    case 2:
                        StarBucks.SurviveClient();
                        break;
                    case 3:
                        act = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect command!");
                        break;
                }
            }            
        }
    }
}