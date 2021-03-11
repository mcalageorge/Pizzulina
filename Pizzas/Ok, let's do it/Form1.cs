using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ok__let_s_do_it
{
    public partial class Form1 : Form
    {

        private void SetPrices()
        {
            this.PriceAlohaChicken.Text = PizzaPrice.PriceAlohaChicken;
            this.PriceBeefPepperoni.Text = PizzaPrice.PriceBeefPepperoni;
            this.PriceBlazingSeafood.Text = PizzaPrice.PriceBlazingSeafood;
            this.PriceChickenSupreme.Text = PizzaPrice.PriceChickenSupreme;
            this.PriceTripleChicken.Text = PizzaPrice.PriceTripleChicken;
            this.PriceSuperSupreme.Text = PizzaPrice.PriceSuperSupreme;
            this.PriceChickenSensation.Text = PizzaPrice.PriceChickenSensation;
            this.PriceChickenDelight.Text = PizzaPrice.PriceChickenDelight;
            this.PriceAlohaChicken.Text = PizzaPrice.PriceAlohaChicken;
            this.PriceBeefPepperoni.Text = PizzaPrice.PriceBeefPepperoni;
            this.PriceIslandSupreme.Text = PizzaPrice.PriceIslandSupreme;
        }

        static int previous_indexpage = 0;

        System.Media.SoundPlayer Hover = new System.Media.SoundPlayer("hover2.wav");
        System.Media.SoundPlayer Hover2 = new System.Media.SoundPlayer("button-7.wav");
        System.Media.SoundPlayer Hover3 = new System.Media.SoundPlayer("bt3.wav");
        System.Media.SoundPlayer Hover4 = new System.Media.SoundPlayer("bt2.wav");

        public Form1()
        {
            InitializeComponent();



        }

        private void ButtonDarkenOnHover(object sender, EventArgs e)
        {
            CreateAccButton.BackgroundImage = Properties.Resources.topbardark;
        }

        private void ButtonLIghtenOnLeave(object sender, EventArgs e)
        {
            CreateAccButton.BackgroundImage = Properties.Resources.topbar;
        }

        private void Button1DarkenOnHover(object sender, EventArgs e)
        {
            LoginAccButton.BackgroundImage = Properties.Resources.topbardark;
        }

        private void LoginAccButton_MouseLeave(object sender, EventArgs e)
        {
            LoginAccButton.BackgroundImage = Properties.Resources.topbar;
        }

        private void CreateAccButton_Click(object sender, EventArgs e)
        {
            previous_indexpage = 0;
            Hover.Play();

            Account.Name = CreateNameBox.Text;
            Account.Surname = CreateSurnameBox.Text;
            Account.Email = CreateEmailBox.Text;
            Account.Password = CreatePasswordBox.Text;

            if (CreateNameBox.Text != null && CreateSurnameBox.Text != null && CreateEmailBox.Text != null && CreatePasswordBox.Text != null && TermsAndServices_Check.Checked)
            {
                StreamReader demoRead = new StreamReader("demo.txt", true);
                if (AlreadyCreated(demoRead, Account.Email) == true)
                {

                    MessageBox.Show("There is already an account created using this email address.\n\nPlease try another or login using it.");
                    demoRead.Close();
                }
                else
                {
                    //write to file user credentials
                    demoRead.Close();
                    StreamWriter demoWrite = new StreamWriter("demo.txt", true);
                    demoWrite.WriteLine(CreateEmailBox.Text);
                    demoWrite.WriteLine(CreatePasswordBox.Text);
                    demoWrite.WriteLine(CreateNameBox.Text);
                    demoWrite.WriteLine(CreateSurnameBox.Text);

                    demoWrite.Close();
                    MessageBox.Show("Account created, " + Account.Name + ".\nPlease login in order to proceed.");
                }
            }
        }


        public bool AlreadyCreated(StreamReader q, string email)
        {
            string line;
            while ((line = q.ReadLine()) != null)
            {
                if (line == email)
                {

                    return true;

                }

            }

            return false;

        }

        private void LoginAccButton_Click(object sender, EventArgs e)
        {
            previous_indexpage = 0;
            Hover.Play();
            Account.Email = EmailLoginBox.Text;
            Account.Password = PasswordLoginBox.Text;


            StreamReader demoRead = new StreamReader("demo.txt", true);

            if (AlreadyCreated(demoRead, Account.Email) == true && Account.Password == demoRead.ReadLine())
            {
                Account.Name = demoRead.ReadLine();
                Account.Surname = demoRead.ReadLine();
                demoRead.Close();
                //fade in black
                this.WelcomeMessage.Text = ("Welcome to Pizzulina, " + Account.Name + "..");
                App.SelectTab(1);
                quote.Text = ReturnQuote();
            }
            else
            {
                demoRead.Close();

                MessageBox.Show("There is no account created under this email address or the password is incorrect.\n\nPlease retry or create a new account.");

            }


        }

        public string ReturnQuote()
        {
            string[] quotes = new string[] { "\"Thats because Tod never brings anything\nbut death and bad advice\", I snapped. \nThats not true. Tod tried to grin,\n\"Sometimes I bring pizza.\"\n― Rachel Vincent, If I Die",
                "\"My love is pizza shaped. Won’t you have\n a slice? It’s circular, so there’s enough\nto go around.\"\n―Dora J. Arod, Love quotes for the ages.\nAnd the ageless sages.",
                 "\"Those pizzas I ate were for medicinal \npurposes.\"\n― Amy Neftzger",
                 "\"Christmas was definitely the best thing \never, even better than pizza.\n But instead of all her favorite toppings,\nAmitola was surrounded by all her\nfavorite people.\""
            };
            Random rnd = new Random();
            int z = rnd.Next(0, 3);
            return quotes[3];
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            SetPrices();

        }



        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        int timer = 100;
        int timer2 = 100;
        int number_of_dots = 1;
        int number_of_dots2 = 1;
        private void CheckTab_Tick(object sender, EventArgs e)
        {

            if (App.SelectedTab == Welcome)
            {
                timer -= 5;
                if (number_of_dots == 1) { this.WelcomeMessage.Text = ("Welcome to Pizzulina, " + Account.Name + "."); number_of_dots++; }
                else if (number_of_dots == 2) { this.WelcomeMessage.Text = ("Welcome to Pizzulina, " + Account.Name + ".."); number_of_dots++; }
                else { this.WelcomeMessage.Text = ("Welcome to Pizzulina, " + Account.Name + "..."); number_of_dots = 1; }
            }
            if (timer == 0 && previous_indexpage == 0)
            {
                App.SelectTab(2);
                timer = 300;

            }
            if (App.SelectedTab == MainMenu && float.Parse(this.TotalPriceLabel.Text) > 0) OrderButton.Enabled = true;



            if (App.SelectedTab == Loading)
            {
                timer2 -= 5;
                if (number_of_dots2 == 1) { this.Processing.Text = "Processing order" + "."; number_of_dots2++; }
                else if (number_of_dots2 == 2) { this.Processing.Text = "Processing order" + ".."; number_of_dots2++; }
                else { this.Processing.Text = "Processing order" + "..."; number_of_dots2 = 1; }

            }
            if (timer2 == 0)
            {
                App.SelectTab(6);
                timer = 300;


            }







        }



        private void StopAnimation(object sender, EventArgs e)
        {



            //do something
        }

        public void Promotion() {


        }

        private void DarkenOnHover(object sender, EventArgs e)
        {
            PizzaButton.BackgroundImage = Properties.Resources.topbardark;

        }

        private void LightenOnHover(object sender, EventArgs e)
        {
            PizzaButton.BackgroundImage = Properties.Resources.topbar;

        }

        private void OnhHoverOrder(object sender, EventArgs e)
        {
            if (OrderButton.Enabled == true)
            {
                OrderButton.BackgroundImage = Properties.Resources.topbardark;

            }
        }

        private void OnLeaveOrder(object sender, EventArgs e)
        {
            OrderButton.BackgroundImage = Properties.Resources.topbar;
        }

        private void PromotionsButton_Click(object sender, EventArgs e)
        {
            Hover.Play();
            if (PromotionsPanel.Enabled == false)
            {
                PizzaMenu.Enabled = false;
                PizzaMenu.Visible = false;


            }

            if (PromotionsPanel.Enabled == false)
            {
                PromotionsPanel.Enabled = true;
                PromotionsPanel.Visible = true;
                PromotionsPanel.Left = 313;// 211, 41
                PromotionsPanel.Top = 65; //46 //87

               



            }
            else if (PromotionsPanel.Enabled == true)
            {
                PromotionsPanel.Enabled = false;
                PromotionsPanel.Visible = false;

                PromotionsPanel.Left = 215;// 211, 41
                PromotionsPanel.Top = 643;

            }
        }

        private void PizzaButton_Click(object sender, EventArgs e)
        {
            Hover.Play();
            if (PromotionsPanel.Enabled == true && PizzaMenu.Enabled == false)
            {
                PromotionsPanel.Enabled = false;
                PromotionsPanel.Visible = false;

                

            }
            DisableEnablePizzaButton();
        }
        private void DisableEnablePizzaButton()
        {
            if (PizzaMenu.Enabled == false)
            {
                BringToFront();
                PizzaMenu.Enabled = true;
                PizzaMenu.Visible = true;
                CustomMenu.Enabled = false;
                CustomMenu.Visible = false;
                PizzaMenu.Left = 313;// 312, 46
                PizzaMenu.Top = 65;
               
            }
            else if (PizzaMenu.Enabled == true)
            {

                PizzaMenu.Enabled = false;
                PizzaMenu.Visible = false;
                PizzaMenu.Left = 686;
                PizzaMenu.Top = 643;
            }
        }

        private void StopSoundCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (StopSoundCheck.Checked == true)
            {
                Hover = new System.Media.SoundPlayer("hover2.wav");
                Hover2 = new System.Media.SoundPlayer("button-7.wav");
                Hover3 = new System.Media.SoundPlayer("bt3.wav");
                Hover4 = new System.Media.SoundPlayer("bt2.wav");
                
            }
            else 
            { 
                Hover = new System.Media.SoundPlayer("NOT.wav");
                Hover2 = new System.Media.SoundPlayer("NOT.wav");
                Hover3 = new System.Media.SoundPlayer("NOT.wav");
                Hover4 = new System.Media.SoundPlayer("NOT.wav");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hover.Play();
            previous_indexpage = 0;
            App.SelectTab(3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            previous_indexpage = 1;
            App.SelectTab(3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hover.Play();
            previous_indexpage = 2;
            App.SelectTab(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hover.Play();
            App.SelectTab(previous_indexpage);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void MainMenu_Click(object sender, EventArgs e)
        {
            if (CustomPizzaName.Text == "")
                CustomPizzaName.Text = "Click to change pizza's name...";
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Basket.previous_index = PizzaPrice.PriceBlazingSeafoodDisplay;


            Hover.Play();
            Basket.AddtoBasketBlazingSeafood();
            Basket.UpdateBasket(PriceView);
            this.TotalPriceLabel.Text = Basket.TotalPrice.ToString();
            Promotion();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Basket.previous_index = PizzaPrice.PriceChickenSupremeDisplay;
            Hover.Play();
            Basket.AddtoBasketChickenSupreme();
            Basket.UpdateBasket(PriceView);
            this.TotalPriceLabel.Text = Basket.TotalPrice.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Basket.previous_index = PizzaPrice.PriceTripleChickenDisplay;
            Hover.Play();
            Basket.AddtoBasketTripleChicken();
            Basket.UpdateBasket(PriceView);
            this.TotalPriceLabel.Text = Basket.TotalPrice.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Basket.previous_index = PizzaPrice.PriceSuperSupremeDisplay;
            Hover.Play();
            Basket.AddtoBasketSuperSupreme();
            Basket.UpdateBasket(PriceView);
            this.TotalPriceLabel.Text = Basket.TotalPrice.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Basket.previous_index = PizzaPrice.PriceChickenSensationDisplay;
            Hover.Play();
            Basket.AddtoBasketChickenSensation();
            Basket.UpdateBasket(PriceView);
            this.TotalPriceLabel.Text = Basket.TotalPrice.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Basket.previous_index = PizzaPrice.PriceChickenDelightDisplay;
            Hover.Play();
            Basket.AddtoBasketChickenDelight();
            Basket.UpdateBasket(PriceView);
            this.TotalPriceLabel.Text = Basket.TotalPrice.ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Basket.previous_index = PizzaPrice.PriceAlohaChickenDisplay;
            Hover.Play();
            Basket.AddtoBasketAlohaChicken();
            Basket.UpdateBasket(PriceView);
            this.TotalPriceLabel.Text = Basket.TotalPrice.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Basket.previous_index = PizzaPrice.PriceBeefPepperoniDisplay;
            Hover.Play();
            Basket.AddtoBasketBeefPepperoni();
            Basket.UpdateBasket(PriceView);
            this.TotalPriceLabel.Text = Basket.TotalPrice.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Basket.previous_index = PizzaPrice.PriceIslandSupremeDisplay;
            Hover.Play();
            Basket.AddtoBasketIslandSupreme();
            Basket.UpdateBasket(PriceView);
            this.TotalPriceLabel.Text = Basket.TotalPrice.ToString();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Hover2.Play();
            Basket.get2get1free = false;

            Basket.free_count = 0;

            Basket.initial = 0;




            Basket.previous_index = 0;
            Basket.TotalPrice = 0;
            this.TotalPriceLabel.Text = 0.ToString();
            PriceView.Items.Clear();
            OrderButton.Enabled = false;

            Basket.get2get1free = false;

            Basket.nrPriceChickenSupremeDisplay = 0;
            Basket.nrPriceTripleChickenDisplay = 0;
            Basket.nrPriceSuperSupremeDisplay = 0;
            Basket.nrPriceChickenSensationDisplay = 0;
            Basket.nrPriceChickenDelightDisplay = 0;
            Basket.nrPriceAlohaChickenDisplay = 0;
            Basket.nrPriceBeefPepperoniDisplay = 0;
            Basket.nrPriceIslandSupremeDisplay = 0;
            Basket.nrPriceBlazingSeafoodDisplay = 0;
            Basket.nrPriceCustomDisplay = 0;

            Basket.TotalPriceChickenSupremeDisplay = 0;
            Basket.TotalPriceTripleChickenDisplay = 0;
            Basket.TotalPriceSuperSupremeDisplay = 0;
            Basket.TotalPriceChickenSensationDisplay = 0;
            Basket.TotalPriceChickenDelightDisplay = 0;
            Basket.TotalPriceAlohaChickenDisplay = 0;
            Basket.TotalPriceBeefPepperoniDisplay = 0;
            Basket.TotalPriceIslandSupremeDisplay = 0;
            Basket.TotalPriceBlazingSeafoodDisplay = 0;
            Basket.TotalPriceCustomDisplay = 0;
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {

            if (Basket.get2get1free == true)
            {
                pictureBox4.Visible = true; pictureBox30.Visible = false;

            }
            else
            {
                pictureBox4.Visible = false; pictureBox30.Visible = true;
                

            }
            Hover.Play();
            App.SelectTab(5);
            ShowName.Text = Account.Name + " " + Account.Surname;
            ShowPrice.Text = TotalPriceLabel.Text;
            GoodChoice.Text = "!You made a good choice, " + Account.Name;
            PromotionsPanel.Visible = false;
            PizzaMenu.Visible = false;
            CustomMenu.Visible = false;

            int x = 3 - Basket.ReturnNrPizza();
            string pizza;
            if (x == 1) pizza = "Pizza";
            else pizza = "Pizzas";
            if (Basket.ReturnNrPizza() < 3)
                BUY2GET1FREE.SetToolTip(label23, "You lack " + x.ToString() + " " + pizza + ". Go buy some more!");
            else if (Basket.ReturnNrPizza() >= 3 && Basket.ReturnNrPizza() < 6)
                BUY2GET1FREE.SetToolTip(label23, "OK, you will get 1 free Pizza!");
            else
                BUY2GET1FREE.SetToolTip(label23, "YES, YOU WILL GET " + Basket.free_count + " FREE PIZZAS!!!");

            if (Basket.ReturnNrPizza() > 0)
                BUY2GET1FREE.SetToolTip(label24, "You will get " + Basket.ReturnNrPizza() + " free Coca~Cola bottles!");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }

        private void PizzaMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            Hover.Play();
            previous_indexpage = 5;
            App.SelectTab(3);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Hover.Play();
            previous_indexpage = 4;
            App.SelectTab(3);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if ((ccYear.Text != "" && ccMonth.Text != null && ccName.Text != "" && ccNumber.Text != "") || ramburs.Checked)
            {
                previous_indexpage = 4;
                Hover.Play();
                App.SelectTab(Loading);
            }
            else MessageBox.Show("Complete all the fields first");
        }

        private void button20_MouseMove(object sender, MouseEventArgs e)
        {

        }



        private void button19_MouseHover(object sender, EventArgs e)
        {
            button19.BackgroundImage = Properties.Resources.topbardark;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button19_MouseLeave(object sender, EventArgs e)
        {
            button19.BackgroundImage = Properties.Resources.topbar;
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://facebook.com");

        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://twitter.com");
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://instagram.com");
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://discord.com");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Hover.Play();
            App.SelectTab(2);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Hover.Play();
            App.SelectTab(2);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Hover.Play();
            if (textBox4.Text != null && textBox4.Text != "")
            {
                App.SelectTab(4);
                label14.Text = ShowPrice.Text + " RON";
            }
            else
            {
                MessageBox.Show("Please input a valid address");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            timer2 = 100;
            PriceView.Clear();
            TotalPriceLabel.Text = 0.ToString();
            Basket.TotalPrice = 0;
            Hover.Play();
            App.SelectTab(2);
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void CreditCardCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CreditCardCheckBox.Checked)
            {
                panel16.Visible = true; panel16.Enabled = true;
                label25.Visible = false; label25.Enabled = false;
            }
            else
            {
                panel16.Visible = false; panel16.Enabled = false;
                label25.Visible = true; label25.Enabled = true;
            }
        }
        bool alreadycreated = false;
        private void button11_Click(object sender, EventArgs e)
        {
            if (alreadycreated == false)
            {
                alreadycreated = true;

            }
            if (CustomMenu.Visible == false || PromotionsPanel.Enabled == true)
            {
                CustomMenu.BringToFront();
                CustomMenu.Visible = true; CustomMenu.Enabled = true;
                PizzaMenu.Visible = false; PizzaMenu.Enabled = false;
                PromotionsPanel.Visible = false; PromotionsPanel.Enabled = false;
            }
            else
            {
                CustomMenu.Visible = false; CustomMenu.Enabled = false;
            }
        }
       
        private void CustomPizzaName_TextChanged(object sender, EventArgs e)
        {
            Custom_Pizza.Name = CustomPizzaName.Text;
            createdName.Text = CustomPizzaName.Text;

        }
        bool zero = false;
        private void button24_Click(object sender, EventArgs e)
        {
            AddtoCustomPrice(IngredientPrices.salamiPrice);
            IngredientPrices.salamiAmount++;
            int x = IngredientPrices.salamiAmount;
            salamiCount.Text = x.ToString();
            if (zero == false) textBox1.Text += IngredientPrices.salamiName + ", ";
            zero = true;
        }
        private void AddtoCustomPrice(float x)
        {
            Custom_Pizza.Price += x;
            label33.Text = "Price: " + Custom_Pizza.Price;
        }
        bool one = false;
        private void button20_Click_1(object sender, EventArgs e)
        {
            Hover4.Play();
            AddtoCustomPrice(IngredientPrices.olivePrice);
            IngredientPrices.oliveAmount++;
            int x = IngredientPrices.oliveAmount;
            oliveCount.Text = x.ToString();
            if (one == false) textBox1.Text += IngredientPrices.oliveName + ", ";
            one = true;
        }
        bool two = false;
        private void button23_Click(object sender, EventArgs e)
        {
            Hover4.Play();
            AddtoCustomPrice(IngredientPrices.hamPrice);
          
            IngredientPrices.hamAmount++;
            int x = IngredientPrices.hamAmount;
            hamCount.Text = x.ToString();
            if (two == false) textBox1.Text += IngredientPrices.hamName + ", ";
            two = true;
        }
        bool three = false;
        private void button25_Click(object sender, EventArgs e)
        {
            Hover4.Play();
            AddtoCustomPrice(IngredientPrices.mozzarellaPrice);
            IngredientPrices.mozzarellaAmount++;
            int x = IngredientPrices.mozzarellaAmount;
            mozzarellaCount.Text = x.ToString();
            if (three == false) textBox1.Text += IngredientPrices.mozzarellaName + ", ";
            three = true;
        }
        bool four = false;
        private void button26_Click(object sender, EventArgs e)
        {
            Hover4.Play();
            AddtoCustomPrice(IngredientPrices.sausagePrice);
            IngredientPrices.sausageAmount++;
            int x = IngredientPrices.sausageAmount;
            sausageCount.Text = x.ToString();
            if (four == false) textBox1.Text += IngredientPrices.sausageName + ", ";
            four = true;
        }
        bool five = false;
        private void button27_Click(object sender, EventArgs e)
        {
            Hover4.Play();
            AddtoCustomPrice(IngredientPrices.pepperPrice);
            IngredientPrices.pepperAmount++;
            int x = IngredientPrices.pepperAmount;
            pepperCount.Text = x.ToString();
            if (five == false) textBox1.Text += IngredientPrices.pepperName + ", ";
            five = true;

        }
        bool six = false;
        private void button28_Click(object sender, EventArgs e)
        {
            Hover4.Play();
            AddtoCustomPrice(IngredientPrices.mushroomsPrice);
            IngredientPrices.mushroomsAmount++;
            int x = IngredientPrices.mushroomsAmount;
            mushroomCount.Text = x.ToString();
            if (six == false) textBox1.Text += IngredientPrices.mushroomsName + ", ";
            six = true;

        }
        bool seven = false;
        private void button29_Click(object sender, EventArgs e)
        {
            Hover4.Play();
            AddtoCustomPrice(IngredientPrices.baconPrice);
            IngredientPrices.baconAmount++;
            int x = IngredientPrices.baconAmount;
            baconCount.Text = x.ToString();
            if (seven == false) textBox1.Text += IngredientPrices.baconName + ", ";
            seven = true;
        }
       
        private void CustomPizzaName_Click(object sender, EventArgs e)
        {
            CustomPizzaName.Text = "";
        }

        private void CustomPizzaName_Leave(object sender, EventArgs e)
        {
        }

        private void CustomPriceDisplay_Click(object sender, EventArgs e)
        {
            
        }

        private void Sweet_CheckedChanged(object sender, EventArgs e)
        {
            if (Sweet.Checked == true) { Spicy.Checked = false; Custom_Pizza.Ketchup = "Sweet"; }
            
        }

        private void Spicy_CheckedChanged(object sender, EventArgs e)
        {
            if (Spicy.Checked == true) { Sweet.Checked = false; Custom_Pizza.Ketchup = "Spicy";
        }
    }

        private void CustomView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void PriceView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Medium_CheckedChanged(object sender, EventArgs e)
        {
            Custom_Pizza.Crust = "Medium";
        }

        private void Puffy_CheckedChanged(object sender, EventArgs e)
        {
            Custom_Pizza.Crust = "Puffy";
        }

        private void Thin_CheckedChanged(object sender, EventArgs e)
        {
            Custom_Pizza.Crust = "Thin";
        }

        private void button33_Click(object sender, EventArgs e)
        {
            Hover3.Play();
            DialogResult result = openFileDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                picture.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            Hover.Play();
            if (Custom_Pizza.Price >= 30 && Custom_Pizza.Crust != null && Custom_Pizza.Sauce != null)
            {
                Basket.customName = CustomPizzaName.Text;
                PizzaMenu.Controls.Add(CustomIteration);
                label28.Text = Custom_Pizza.Price.ToString() + " RON";
                PizzaPrice.PriceCustomDisplay = Custom_Pizza.Price;
            }
            else { MessageBox.Show("Your pizza must have a crust, a sauce and 30 RON worth of value"); }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            Basket.previous_index = PizzaPrice.PriceCustomDisplay;


            Hover.Play();
            Basket.AddtoBasketCustom();
            Basket.UpdateBasket(PriceView);
            this.TotalPriceLabel.Text = Basket.TotalPrice.ToString();
            Promotion();
        }

        private void Tomato_CheckedChanged(object sender, EventArgs e)
        {
            Custom_Pizza.Sauce = "Tomato";
        }

        private void Alfredo_CheckedChanged(object sender, EventArgs e)
        {
            Custom_Pizza.Sauce = "Alfredo";
        }

        private void CustomPriceDisplay_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void button31_Click(object sender, EventArgs e)
        {
            
        }

        private void button31_Click_1(object sender, EventArgs e)
        {
            Basket.previous_index = PizzaPrice.PriceChickenSupremeDisplay;
            Hover.Play();
            Basket.AddtoBasketChickenSupreme();
            Basket.UpdateBasket(PriceView);
            this.TotalPriceLabel.Text = Basket.TotalPrice.ToString();
            Promotion();
        }
        Point lastPoint;
        private void panel30_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel30_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://policies.google.com/terms?hl=en");

        }

        private void button11_MouseHover(object sender, EventArgs e)
        {
            button11.BackgroundImage = Properties.Resources.topbardark;

        }

        private void button11_MouseLeave(object sender, EventArgs e)
        {
            button11.BackgroundImage = Properties.Resources.topbar;

        }
    }
    }

