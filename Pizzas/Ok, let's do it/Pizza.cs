using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ok__let_s_do_it
{
    class Pizza : Ingredients
    {
       public static string nume_Pizza;
       public static float pret_Pizza;
       public static string descriere_Pizza;


    }

    class Ingredients
    {


        string Crust { get; set; } = "Regular";
        string Topping { get; set; } = "Ketchup";
        string Sauce { get; set; } = "Tomato";
        string Assortments1 { get; set; } = "Corn";
        string Assortments2 { get; set; } = "Salami";
        string Assortments3 { get; set; } = "Mozzarella";

    }
}
