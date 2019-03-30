using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorGUI
{
    public partial class Calculator : Form
    {
        CalculatorFormula calculatorFormula;
        bool isSecondNumber;

        public Calculator()
        {
            InitializeComponent();
            calculatorFormula = new CalculatorFormula();
            isSecondNumber = false;
        }

        public void AddDigit(String digit)
        {
            if (display.Text.Equals("0") || isSecondNumber)
                display.Text = digit;
            else
                display.Text += digit;

            isSecondNumber = false;          
            
        }

        public void ChooseOperation(object sender, EventArgs e)
        {

            switch (((Button)sender).Text)
            {
                case "+":
                    calculatorFormula.OperationCode = 1;
                    break;
                case "-":
                    calculatorFormula.OperationCode = 2;
                    break;
                case "*":
                    calculatorFormula.OperationCode = 3;
                    break;
                case "/":
                    calculatorFormula.OperationCode = 4;
                    break;
                case "^":
                    calculatorFormula.OperationCode = 5;
                    break;
                case "%":
                    calculatorFormula.OperationCode = 6;
                    break;
                case "1/x":
                    calculatorFormula.OperationCode = 7;
                    break;

                default:
                    break;
            }

            calculatorFormula.Number1 = Convert.ToDouble(display.Text);
            isSecondNumber = true;
        }

        private void buttonDigit_Click(object sender, EventArgs e)
        {
            AddDigit(((Button)sender).Text);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            double number = Convert.ToDouble(display.Text) * (-1);
            display.Text = number.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!display.Text.Contains(","))
                display.Text += ",";
            //display.Text = display.Text.Replace('.', ','); //- замена точек на запятые при вводе с клавииатуры
        }

        private void button11_Click(object sender, EventArgs e)
        {
            display.Text = "0";
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            calculatorFormula.Number2 = Convert.ToDouble(display.Text);
            calculatorFormula.Calculate();
            display.Text = calculatorFormula.Result;
            isSecondNumber = true; //после нажатия равно - следующее число перезаписывает дисплей
        }

        private void buttonMemoryClear_Click(object sender, EventArgs e)
        {
            calculatorFormula.Memory = 0;
            labelMemory.Visible = false;
        }

        private void buttonMemoryRead_Click(object sender, EventArgs e)
        {
            display.Text = calculatorFormula.Memory.ToString();
            isSecondNumber = true;
        }

        private void buttonMemorySend_Click(object sender, EventArgs e)
        {
            calculatorFormula.Memory = Convert.ToDouble(display.Text);
            isSecondNumber = true;
            if (calculatorFormula.Memory != 0)
                labelMemory.Visible = true;
            else
                labelMemory.Visible = false;
        }

        private void buttonMemoryPlus_Click(object sender, EventArgs e)
        {
            calculatorFormula.Memory += Convert.ToDouble(display.Text);
            isSecondNumber = true;
            if (calculatorFormula.Memory != 0)
                labelMemory.Visible = true;
            else
                labelMemory.Visible = false;
        }

        private void buttonMemoryMinus_Click(object sender, EventArgs e)
        {
            calculatorFormula.Memory -= Convert.ToDouble(display.Text);
            isSecondNumber = true;
            if (calculatorFormula.Memory != 0)
                labelMemory.Visible = true;
            else
                labelMemory.Visible = false;
        }

        //private void Button25_Click(object sender, EventArgs e)
        //{
        //    calculatorFormula.Number1 = Convert.ToDouble(display.Text);
        //    calculatorFormula.Calculate();
        //    display.Text = calculatorFormula.Result;
        //    isSecondNumber = true;
        //}

    }
}
