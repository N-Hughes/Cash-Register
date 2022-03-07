using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Cash_Register
{
    public partial class Form1 : Form
    {
        //Global Variables
        double subTotal = 0;
        double art1Price = 7.5;
        double art2Price = 10;
        double art3Price = 5;
        double totalAmount = 0;
        double art1Amount = 0;
        double art2Amount = 0;
        double art3Amount = 0;
        double taxRate = 0.13;
        double taxTotal = 0;
        double change = 0;
        double tendered = 0;




        public Form1()
        {
            InitializeComponent();
        }

        //Global Sounds
        SoundPlayer printing = new SoundPlayer(Properties.Resources.printingWorks);
        SoundPlayer button = new SoundPlayer(Properties.Resources.button);

        private void calButton_Click(object sender, EventArgs e)
        {



            //Stop Letters From Crashing Program
            try
            {  
                
                //Button 
                button.Play();


                //Adding Amounts Together
                art1Amount = Convert.ToDouble(art1Text.Text) * art1Price;
                art2Amount = Convert.ToDouble(art2Text.Text) * art2Price;
                art3Amount = Convert.ToDouble(art3Text.Text) * art3Price;

                subTotal = art1Amount + art2Amount + art3Amount;
                taxTotal = subTotal * taxRate;
                totalAmount = subTotal + taxTotal;

                subLabel.Text = $"{subTotal.ToString("C")} ";
                taxLabel.Text = $"{taxTotal.ToString("C")} ";
                totalLabel.Text = $"{totalAmount.ToString("C")} ";

                //Display Amounts
                subLabel.Text = $"Sub Total: {subTotal.ToString("C")}";
                taxLabel.Text = $"Tax: {taxTotal.ToString("C")}";
                totalLabel.Text = $"Total: {totalAmount.ToString("C")}";

                changeButton.Enabled = true;
            }
            catch
            {
                art1Text.Text = "0";
                art2Text.Text = "0";
                art3Text.Text = "0";

                subLabel.Text = "Sub Total: ERROR";
                taxLabel.Text = "Tax: ERROR";
                totalLabel.Text = "Total: ERROR";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void changeButton_Click(object sender, EventArgs e)
        {



            try
            {
                //Button Click Noise
                button.Play();

                //Subtracting Money from Price
                tendered = Convert.ToDouble(tenderedText.Text);
                change = tendered - totalAmount;

                //Display Change
                changeLabel.Text = $"Change Due: {change.ToString("C")}";

                receiptButton.Enabled = true;
            }
            catch
            {
                tenderedText.Text = "0";
            }
        }

        private void receiptButton_Click(object sender, EventArgs e)
        {
            //Play sounds 
            printing.Play();

            Refresh();
            Thread.Sleep(2500);

            //Display Receipt (reciept Printing)
            storeLabel.Visible = true;
            storeLabel.Text = "      The Art Shop";

            //Line
            Refresh();
            Thread.Sleep(500);
            line1Label.Visible = true;
            line1Label.Text = "_____________________";

            //Text
            Refresh();
            Thread.Sleep(500);
            line2Label.Visible = true;
            line2Label.Text = $"Garfiel Art:                        {art1Amount.ToString("C")}\nIsaiah Portrait:                  {art2Amount.ToString("C")}\nDino Art:                           {art3Amount.ToString("C")}";

            //Line
            Refresh();
            Thread.Sleep(500);
            line3Label.Visible = true;
            line3Label.Text = "_______________________";

            //Text
            Refresh();
            Thread.Sleep(500);
            line4Label.Visible = true;
            line4Label.Text = $"Sub Total:                         {subTotal.ToString("C")}\nTax:                                  {taxTotal.ToString("C")}\nTotal:                                {totalAmount.ToString("C")}";

            //Line
            Refresh();
            Thread.Sleep(500);
            line5Label.Visible = true;
            line5Label.Text = "_______________________";

            //Text
            Refresh();
            Thread.Sleep(500);
            line6Label.Visible = true;
            line6Label.Text = $"Tendered                         {tendered.ToString("C")}\nChange:                           {change.ToString("C")}";

            //Text
            Refresh();
            Thread.Sleep(500);
            line7Label.Visible = true;
            line7Label.Text = $"Thank you for coming to the art store!";

            //Stops Sounds 
            printing.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Reset Program
            art1Text.Text = "0";
            art2Text.Text = "0";
            art3Text.Text = "0";

            subLabel.Text = "Sub Total:";
            taxLabel.Text = "Tax:";
            totalLabel.Text = "Total:";

            tenderedLabel.Text = "0";

            changeLabel.Text = "Change:";

            line1Label.Visible = false;
            line2Label.Visible = false;
            line3Label.Visible = false;
            line4Label.Visible = false;
            line5Label.Visible = false;
            line6Label.Visible = false;
            line7Label.Visible = false;
        }
    }
}
