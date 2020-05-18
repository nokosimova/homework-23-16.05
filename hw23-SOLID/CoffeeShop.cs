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

    }
}
