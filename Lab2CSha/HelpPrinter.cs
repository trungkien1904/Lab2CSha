using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2CSha
{
    public class HelpPrinter
    {
        public void PrintInstructions()
        {

            Console.WriteLine("Calculator Instructions:");
            Console.WriteLine("When a first symbol on line is ‘>’ – enter operand (number)");
            Console.WriteLine("When a first symbol on line is ‘@’ – enter operation");
            Console.WriteLine("Operation is one of ‘+’, ‘-‘, ‘/’, ‘*’ or");
            Console.WriteLine("‘#’ followed with number of evaluation step");
            Console.WriteLine("‘q’ to exit");
            Console.WriteLine();
        }
    }
}
