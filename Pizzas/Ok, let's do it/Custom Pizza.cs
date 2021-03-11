using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ok__let_s_do_it
{
    class Custom_Pizza
    {
        static public string Name { get; set; } = "Your pizza";
        static public float Price { get; set; } = 0;

        static public string Crust { get; set; }
        static public string Sauce { get; set; }

        static public string Ketchup { get; set; }


        static public void ResetCustom()
        {
            Name = "Your pizza";
            Price = 0f;
            Crust = null;
            Sauce = null;
            Ketchup = null;
        }
    }
}
