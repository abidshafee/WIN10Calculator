using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WIN10Calculator
{
    public partial class Form1 : Form
    {
        Double finalResult = 0;
        String operations = "";
        bool isoperations = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void zeroBtn_Click(object sender, EventArgs e)
        {
            if ((resultTextBox.Text == "0") || isoperations)
            {
                resultTextBox.Clear();
            }
            isoperations = false;
            Button button = (Button)sender;

            if(button.Text == ".")
            {
                if (!resultTextBox.Text.Contains("."))
                {
                    resultTextBox.Text = resultTextBox.Text + button.Text;
                }

            }else
            resultTextBox.Text = resultTextBox.Text + button.Text;
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            
            if (finalResult != 0)
            {
                // if previous result already exists
                eqBtn.PerformClick();
                operations = button.Text;
                finalResult = Double.Parse(resultTextBox.Text);
                tempLabel.Text = finalResult + " " + operations;
                isoperations = true;
            }
            else
            {
                operations = button.Text;
                finalResult = Double.Parse(resultTextBox.Text);
                tempLabel.Text = finalResult + " " + operations;
                isoperations = true;
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            resultTextBox.Text = "0";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            resultTextBox.Text = "0";
            finalResult = 0;
        }

        private void clrBtn_Click(object sender, EventArgs e)
        {
            try
            {
                resultTextBox.Text = resultTextBox.Text.
                    Substring(0, resultTextBox.Text.Length - 1);
            }catch(Exception)
            {
                resultTextBox.Text = "0";
            }
        }

        private void eqBtn_Click(object sender, EventArgs e)
        {
            if (operations == "+")
            {
                resultTextBox.Text = (finalResult + Double.Parse(resultTextBox.Text)).ToString();

            }
            if (operations == "-")
            {
                resultTextBox.Text = (finalResult - Double.Parse(resultTextBox.Text)).ToString();

            }
            if (operations == "×")
            {
                resultTextBox.Text = (finalResult * Double.Parse(resultTextBox.Text)).ToString();

            }
            if (operations == "÷")
            {
                resultTextBox.Text = (finalResult / Double.Parse(resultTextBox.Text)).ToString();

            }
            //this will reset final result to current valaue
            //and set the current value into temp label
            finalResult = Double.Parse(resultTextBox.Text);
            tempLabel.Text = "";


            // tempLabel.Text = tempLabel.Text + resultTextBox.Text + "=";
        }

      

        private void percentOp_click(object sender, EventArgs e)
        {
            resultTextBox.Text = ((Double.Parse(resultTextBox.Text))/100).ToString();
        }

        private void rootBtn_Click(object sender, EventArgs e)
        {
            finalResult = Double.Parse(resultTextBox.Text);
            resultTextBox.Text = (Math.Pow(finalResult, 0.5)).ToString();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            finalResult = Double.Parse(resultTextBox.Text);
            resultTextBox.Text = (finalResult * finalResult).ToString();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            finalResult = Double.Parse(resultTextBox.Text);
            resultTextBox.Text = (1/ finalResult).ToString();
        }
    }
}