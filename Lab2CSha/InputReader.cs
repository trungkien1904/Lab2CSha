using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2CSha
{
    public class InputReader
    {

        // Чтение входных данных от пользователя с помощью клавиатуры
        public double ReadNumber()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (double.TryParse(input, out double number))
                {
                    // Если строку можно успешно преобразовать в двойное число, возвращается числовое значение
                    return number;
                }
                else
                {
                    // Если его невозможно преобразовать в двойное, сообщить об ошибке и попросить пользователя повторить ввод
                    Console.WriteLine("Invalid input. Please enter a valid number:");
                }
            }
        }


        //метод гарантирует, что пользователь вводит действительный оператор.
        public char ReadOperator()
        {
            while (true)
            {
                char @operator = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (IsValidOperator(@operator))
                {
                    return @operator;
                }
                else
                {
                    Console.WriteLine("Invalid operator. Please enter a valid operator (+, -, *, /), '# to retrieve stored result, or 'q' to quit:");

                }

            }
        }

        public bool IsValidOperator(char @operator)
        {
            return (@operator == '+' || @operator == '-' || @operator == '*' || @operator == '/' || @operator == 'q' || @operator == '#');
        }


        //Метод гарантирует, что индекс, введенный пользователем, является допустимым положительным целым числом.
        public int ReadIndex()
        {
            while (true)
            {
                string input = Console.ReadLine();

                try
                {
                    int index = int.Parse(input);

                    if (index >= 1)
                    {
                        return index;
                    }
                    else
                    {
                        Console.WriteLine("Invalid index. Please enter a valid positive integer:");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid format. Please enter a valid positive integer:");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Number is too large. Please enter a valid positive integer:");
                }
            }
        }
    }
}
