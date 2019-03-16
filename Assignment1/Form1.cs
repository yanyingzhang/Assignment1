using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 * Yanying Zhang - 300926213
 * COMP212 - Programming 3 - Assignment 1 - Create Calculator with Delegate
 * 2018-05-15
 */

namespace Assignment1
{
    public partial class Calculator : Form
    {
        double result = 0;
        string operation = "";
        double a = 0;
        Boolean decClicked = false;

        // delegate that has one argument and return to string
        public delegate double CalulateDelegate(double a);

        // initiate delegate
        CalulateDelegate calculateDelegateObj = null;
        

        // Constructor
        public Calculator()
        {
            InitializeComponent();
        }

        public CalulateDelegate operationDelegate(string operation)
        {
            switch (operation)
            {
                case "+":
                    calculateDelegateObj = Add;
                    break;
                case "-":
                    calculateDelegateObj = Sub;
                    break;
                case "*":
                    calculateDelegateObj = Mul;
                    break;
                case "/":
                    calculateDelegateObj = Div;
                    break;
                case "x²":
                    calculateDelegateObj = SquareCal;
                    break;
                case "√":
                    calculateDelegateObj = SqrootCal;
                    break;
                case "1/x":
                    calculateDelegateObj = ReverseCal;
                    break;
                case "log":
                    calculateDelegateObj = LogCal;
                    break;
                case "±":
                    calculateDelegateObj = NegCal;
                    break;
                default:
                    break;
            }
            return calculateDelegateObj;
        }

        private double Add(double a) {
            result = a + result;
            return result;
        }
        private double Sub(double a ){
            result = a - result;
            return result;
        }
        private double Mul(double a)
        {
            result = a * result;
            return result;
        }
        private double Div(double a)
        {
            result = a / result;
            return result;
        }
        private double SquareCal(double a)
        {
            result = a * a;
            return result;
        }
        private double SqrootCal(double a)
        {
            result = Math.Sqrt(a);
            return result;
        }
        
        private double ReverseCal(double a)
        {
            result = 1 / a;
            return result;
        }
        private double LogCal(double a)
        {
            result = Math.Log10(a);
            return result;
        }
        private double NegCal(double a)
        {
            result = 0 - a;
            return result;
        }

        // calculate with function button: Square, Sqroot, ReverseCal, LogCal, NegCal
        private void fuctionButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text;
            a = Convert.ToDouble(result);
            calWithOperation();
        }

        // calculate with operation button: Add, Sub, Mul, Div
        private void operationButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text;
            a = Convert.ToDouble(result);            
            result = 0; // reset input to accept new value
            decClicked = false;
        }
        
        // equal sign button click
        private void equalBtn_Click(object sender, EventArgs e)
        {
            calWithOperation();

            if (valueLbl.Text.Contains(".")){
                decClicked = true;
            }
            else
            {
                decClicked = false;
            }
        }
        
        // method invoke delegate
        private void calWithOperation()
        {
            if (operation != "")
            {
                result = operationDelegate(operation).Invoke(a);
            }
            valueLbl.Text = result.ToString();
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            valueLbl.Text = result.ToString();
        }

        // number button click
        private void numberButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if ((result == 0) && (decClicked == false))
            {
                valueLbl.Text = null;
            }
            valueLbl.Text += button.Text;
            result = Convert.ToDouble(valueLbl.Text);            
        }

        // decimal button click
        private void decBtn_Click(object sender, EventArgs e)
        {
            if (decClicked == false)
            {
                if (result == 0)
                {
                    valueLbl.Text = "0.";
                }
                else
                {
                    valueLbl.Text += ".";
                }
            }
            decClicked = true;
        }

        // delete button click event
        private void delBtn_Click(object sender, EventArgs e)
        {
            if (valueLbl.Text.Length == 1)
            {
                result = 0;                
            }
            else
            {
                result = Convert.ToDouble(result.ToString().Substring(0, result.ToString().Length - 1));                
            }
            valueLbl.Text = result.ToString();

            if (valueLbl.Text.Contains("."))
            {
                decClicked = true;
            }
            else
            {
                decClicked = false;
            }
        }

        // clean button click event
        private void cleanBtn_Click(object sender, EventArgs e)
        {
            result = 0;
            operation = "";
            a = 0;
            valueLbl.Text = result.ToString();
            decClicked = false;
        }
    }
}
