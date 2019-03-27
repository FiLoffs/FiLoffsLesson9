using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorGUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculatorFormula calculatorFormula = new CalculatorFormula();

            calculatorFormula.OperationCode = 4;
            calculatorFormula.Number1 = 3;
            calculatorFormula.Number2 = 5;
            calculatorFormula.Calculate();
            Console.WriteLine(calculatorFormula.Result);
        }
    }
}
