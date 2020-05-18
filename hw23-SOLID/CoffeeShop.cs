using System;
using System.Collections.Generic;
using System.Text;

namespace hw23_SOLID
{
    class Drink
    {
        string Name { get; set; }
        decimal Price { get; set; }
    }
    class CoffeeShop
    {
        List<Drink> Menu = new List<Drink>();
        public void SurviveClient() //обслужить клиента
        {
        }
    }
    interface ITakeAnOrder //принять заказ
    {
        List<Drink> GetAnOrderList();
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
