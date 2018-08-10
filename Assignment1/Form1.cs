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
        string result = "0";
        string operation = "";
        double a = 0;

        // delegate that has one argument and return to string
        public delegate string CalulateDelegate(double a);

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
                default:
                    break;
            }
            return calculateDelegateObj;
        }

        private string Add(double a) {
            result =  (a + Convert.ToDouble(result)).ToString();
            return result;
        }
        private string Sub(double a ){
            result = (a - Convert.ToDouble(result)).ToString();
            return result;
        }
        private string Mul(double a)
        {
            result = (a * Convert.ToDouble(result)).ToString();
            return result;
        }
        private string Div(double a)
        {
            result = (a / Convert.ToDouble(result)).ToString();
            return result;
        }
        private string SquareCal(double a)
        {
            result = ((Convert.ToDouble(a)) * (Convert.ToDouble(a))).ToString();
            return result;
        }
        private string SqrootCal(double a)
        { 
            result = Math.Sqrt(Convert.ToDouble(a)).ToString();
            return result;
        }
        
        private string ReverseCal(double a)
        {
            result = ( 1 / Convert.ToDouble(a)).ToString();
            return result;
        }
        private string LogCal(double a)
        {
            result = (Math.Log10(a)).ToString();
            return result;
        }

        // calculate with function button: Square, Sqroot, ReverseCal, LogCal
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
            calWithOperation();
            result = "0"; // reset input to accept new value
            
        }
        
        // equal sign button click
        private void equalBtn_Click(object sender, EventArgs e)
        {
            calWithOperation();
        }

        // negative button click
        private void negativeBtn_Click(object sender, EventArgs e)
        {
            result = (0 - Convert.ToDouble(valueLbl.Text)).ToString();
            valueLbl.Text = result;
        }

        // method invoke delegate
        private void calWithOperation()
        {
            if (operation != "")
            {
                result = operationDelegate(operation).Invoke(a);
            }
            valueLbl.Text = result;
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            valueLbl.Text = result;
        }

        // number button click
        private void numberButton_Click(object sender, EventArgs e)
        {
            if (result == "0")
            {
                result = null;
            }
            Button button = (Button)sender;
            result += button.Text;
            valueLbl.Text = result;
        }

        // decimal button click
        private void decBtn_Click(object sender, EventArgs e)
        {
            if (!result.Contains("."))
            {
                result += ".";
                valueLbl.Text = result;
            }
        }

        // delete button click event
        private void delBtn_Click(object sender, EventArgs e)
        {
            if(result.Length == 1)
            {
                result = "0";
                valueLbl.Text = result;
            }
            else
            {
                result = result.Substring(0, result.Length-1);
                valueLbl.Text = result;
            }
        }

        // clean button click event
        private void cleanBtn_Click(object sender, EventArgs e)
        {
            result = "0";
            operation = "";
            a = 0;
            valueLbl.Text = result;
        }
    }
}
