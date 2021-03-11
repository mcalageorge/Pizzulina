using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ok__let_s_do_it
{
    class Basket
    {


        static public int nrPriceChickenSupremeDisplay = 0;
        static public int nrPriceTripleChickenDisplay = 0;
        static public int nrPriceSuperSupremeDisplay = 0;
        static public int nrPriceChickenSensationDisplay = 0;
        static public int nrPriceChickenDelightDisplay = 0;
        static public int nrPriceAlohaChickenDisplay = 0;
        static public int nrPriceBeefPepperoniDisplay = 0;
        static public int nrPriceIslandSupremeDisplay = 0;
        static public int nrPriceBlazingSeafoodDisplay = 0;
        public static int nrPriceCustomDisplay = 0;


        static public float TotalPriceChickenSupremeDisplay = 0;
        static public float TotalPriceTripleChickenDisplay = 0;
        static public float TotalPriceSuperSupremeDisplay = 0;
        static public float TotalPriceChickenSensationDisplay = 0;
        static public float TotalPriceChickenDelightDisplay = 0;
        static public float TotalPriceAlohaChickenDisplay = 0;
        static public float TotalPriceBeefPepperoniDisplay = 0;
        static public float TotalPriceIslandSupremeDisplay = 0;
        static public float TotalPriceBlazingSeafoodDisplay = 0;
        public static float TotalPriceCustomDisplay = 0;

        public static float TotalPrice = 0;

        public static string customName = "";


        static public void UpdateBasket(ListView q)
        {
            q.Items.Clear();
            //////
            string[] BlazingSeafood = { "Blazing Seafood", nrPriceBlazingSeafoodDisplay.ToString(), TotalPriceBlazingSeafoodDisplay.ToString() };
            var p1 = new ListViewItem(BlazingSeafood);
            if (nrPriceBlazingSeafoodDisplay > 0)
            {
                q.Items.Add(p1);
                TotalPrice += PizzaPrice.PriceBlazingSeafoodDisplay;
                TotalPrice = UpdatePrice();

            }
            /////
            string[] ChickenSupreme = { "Chicken Supreme", nrPriceChickenSupremeDisplay.ToString(), TotalPriceChickenSupremeDisplay.ToString() };
            var p2 = new ListViewItem(ChickenSupreme);
            if (nrPriceChickenSupremeDisplay > 0)
            {
                q.Items.Add(p2);
                TotalPrice += PizzaPrice.PriceChickenSupremeDisplay;
                TotalPrice = UpdatePrice();
            }
            /////
            string[] TripleChicken = { "Triple Chicken", nrPriceTripleChickenDisplay.ToString(), TotalPriceTripleChickenDisplay.ToString() };
            var p3 = new ListViewItem(TripleChicken);
            if (nrPriceTripleChickenDisplay > 0)
            {
                q.Items.Add(p3);
                TotalPrice += PizzaPrice.PriceTripleChickenDisplay;
                TotalPrice = UpdatePrice();
            }
            /////
            string[] SuperSupreme = { "Super Supreme", nrPriceSuperSupremeDisplay.ToString(), TotalPriceSuperSupremeDisplay.ToString() };
            var p4 = new ListViewItem(SuperSupreme);
            if (nrPriceSuperSupremeDisplay > 0)
            {
                q.Items.Add(p4);
                TotalPrice += PizzaPrice.PriceSuperSupremeDisplay;
                TotalPrice = UpdatePrice();
            }
            /////
            string[] ChickenSensation = { "Chicken Sensation", nrPriceChickenSensationDisplay.ToString(), TotalPriceChickenSensationDisplay.ToString() };
            var p5 = new ListViewItem(ChickenSensation);
            if (nrPriceChickenSensationDisplay > 0)
            {
                q.Items.Add(p5);
                TotalPrice += PizzaPrice.PriceChickenSensationDisplay;
                TotalPrice = UpdatePrice();
            }
            /////
            string[] AlohaChicken = { "Aloha Chicken", nrPriceAlohaChickenDisplay.ToString(), TotalPriceAlohaChickenDisplay.ToString() };
            var p6 = new ListViewItem(AlohaChicken);
            if (nrPriceAlohaChickenDisplay > 0)
            {
                q.Items.Add(p6);
                TotalPrice += PizzaPrice.PriceAlohaChickenDisplay;
                TotalPrice = UpdatePrice();
            }
            /////
            string[] ChickenDelight = { "Chicken Delight", nrPriceChickenDelightDisplay.ToString(), TotalPriceChickenDelightDisplay.ToString() };
            var p7 = new ListViewItem(ChickenDelight);
            if (nrPriceChickenDelightDisplay > 0)
            {
                q.Items.Add(p7);
                TotalPrice += PizzaPrice.PriceChickenDelightDisplay;
                TotalPrice = UpdatePrice();
            }
            /////
            string[] BeefPepperoni = { "Beef Pepperoni", nrPriceBeefPepperoniDisplay.ToString(), TotalPriceBeefPepperoniDisplay.ToString() };
            var p8 = new ListViewItem(BeefPepperoni);
            if (nrPriceBeefPepperoniDisplay > 0)
            {
                q.Items.Add(p8);
                TotalPrice += PizzaPrice.PriceBeefPepperoniDisplay;
                TotalPrice = UpdatePrice();
            }
            /////
            string[] IslandSupreme = { "Island Supreme", nrPriceIslandSupremeDisplay.ToString(), TotalPriceIslandSupremeDisplay.ToString() };
            var p9 = new ListViewItem(IslandSupreme);
            if (nrPriceIslandSupremeDisplay > 0)
            {
                q.Items.Add(p9);
                TotalPrice += PizzaPrice.PriceIslandSupremeDisplay;
                TotalPrice = UpdatePrice();
            }
            /////
            ///
   string[] Custom = { customName, nrPriceCustomDisplay.ToString(), TotalPriceCustomDisplay.ToString() };
var p10 = new ListViewItem(Custom);
           if(nrPriceCustomDisplay > 0)
            {
                q.Items.Add(p10);
                TotalPrice += PizzaPrice.PriceCustomDisplay;
                TotalPrice = UpdatePrice();
            }
            
        }

        static public void AddtoBasketBlazingSeafood()
        {
            nrPriceBlazingSeafoodDisplay++;
            TotalPriceBlazingSeafoodDisplay += PizzaPrice.PriceBlazingSeafoodDisplay;
            
        }
        static public void AddtoBasketChickenSupreme()
        {
            nrPriceChickenSupremeDisplay++;
            TotalPriceChickenSupremeDisplay += PizzaPrice.PriceChickenSupremeDisplay;
            
        }
        static public void AddtoBasketTripleChicken()
        {
            nrPriceTripleChickenDisplay++;
            TotalPriceTripleChickenDisplay += PizzaPrice.PriceTripleChickenDisplay;
           
        }
        static public void AddtoBasketSuperSupreme()
        {
            nrPriceSuperSupremeDisplay++;
            TotalPriceSuperSupremeDisplay += PizzaPrice.PriceSuperSupremeDisplay;
            
        }
        static public void AddtoBasketChickenSensation()
        {
            nrPriceChickenSensationDisplay++;
            TotalPriceChickenSensationDisplay += PizzaPrice.PriceChickenSensationDisplay;
     
        }
        static public void AddtoBasketChickenDelight()
        {
            nrPriceChickenDelightDisplay++;
            TotalPriceChickenDelightDisplay += PizzaPrice.PriceChickenDelightDisplay;
          
        }
        static public void AddtoBasketAlohaChicken()
        {
            nrPriceAlohaChickenDisplay++;
            TotalPriceAlohaChickenDisplay += PizzaPrice.PriceAlohaChickenDisplay;
    
        }
        static public void AddtoBasketBeefPepperoni()
        {
            nrPriceBeefPepperoniDisplay++;
            TotalPriceBeefPepperoniDisplay += PizzaPrice.PriceBeefPepperoniDisplay;
           
        }
        static public void AddtoBasketIslandSupreme()
        {
            nrPriceIslandSupremeDisplay++;
            TotalPriceIslandSupremeDisplay += PizzaPrice.PriceIslandSupremeDisplay;
    
        }
        static public void AddtoBasketCustom()
        {
            nrPriceCustomDisplay++;
            TotalPriceCustomDisplay += PizzaPrice.PriceCustomDisplay;

        }



        static public bool get2get1free = false;

        static public int free_count = 0;

        public static float initial = 0;

        public static float[] help = new float[50];

        public static float previous_index = 0;

        static public float UpdatePrice()
        {
            float TotalPriceBlazingSeafood = nrPriceBlazingSeafoodDisplay * PizzaPrice.PriceBlazingSeafoodDisplay;
            float TotalPriceChickenSupreme = nrPriceChickenSupremeDisplay * PizzaPrice.PriceChickenSupremeDisplay;
            float TotalPriceTripleChicken = nrPriceTripleChickenDisplay * PizzaPrice.PriceTripleChickenDisplay;
            float TotalPriceSuperSupreme = nrPriceSuperSupremeDisplay * PizzaPrice.PriceSuperSupremeDisplay;
            float TotalPriceChickenSensation = nrPriceChickenSensationDisplay * PizzaPrice.PriceChickenSensationDisplay;
            float TotalPriceAlohaChicken = nrPriceAlohaChickenDisplay * PizzaPrice.PriceAlohaChickenDisplay;
            float TotalPriceBeefPepperoni = nrPriceBeefPepperoniDisplay * PizzaPrice.PriceBeefPepperoniDisplay;
            float TotalPriceChickenDelight = nrPriceChickenDelightDisplay * PizzaPrice.PriceChickenDelightDisplay;
            float TotalPriceIslandSupreme = nrPriceIslandSupremeDisplay * PizzaPrice.PriceIslandSupremeDisplay;
            float TotalPriceCustom = nrPriceCustomDisplay * PizzaPrice.PriceCustomDisplay;

            float TotalPrice = TotalPriceBlazingSeafood + TotalPriceChickenSupreme + TotalPriceTripleChicken +
                  TotalPriceSuperSupreme + TotalPriceChickenSensation + TotalPriceAlohaChicken + TotalPriceBeefPepperoni +
                  TotalPriceChickenDelight + TotalPriceIslandSupreme + TotalPriceCustom;

            

            if (initial <= previous_index)
            {
                initial = previous_index;
                
                if (ReturnNrPizza() >= 3)
                {
                    free_count = ReturnNrPizza() / 3;
                    Array.Sort(help);
                    for (int i = 0; i < free_count; i++)
                    {
                        get2get1free = true;
                        
                            help[i] = initial; 
                        
                        TotalPrice -= help[i];
                        }
                }
                else initial = 0;
            }
            initial = 0;

           

            return TotalPrice;
        }

        static public int ReturnNrPizza()
        {
            int nrPizza = nrPriceChickenSupremeDisplay +
                         nrPriceTripleChickenDisplay +
                         nrPriceSuperSupremeDisplay +
                         nrPriceChickenSensationDisplay +
                         nrPriceChickenDelightDisplay +
                         nrPriceAlohaChickenDisplay +
                         nrPriceBeefPepperoniDisplay +
                         nrPriceIslandSupremeDisplay +
                         nrPriceBlazingSeafoodDisplay +
                         nrPriceCustomDisplay;
           
            return nrPizza;
        }
        
    }
}

