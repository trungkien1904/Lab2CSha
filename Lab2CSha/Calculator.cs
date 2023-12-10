using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2CSha
{
    public class Calculator
    {
        public double Result { get; set; } // Результат текущей операции
        private List<CalculatorResult> storedResults; // Список для хранения результатов и математической информации
        public IReadOnlyList<CalculatorResult> StoredResults => storedResults;
        public int OperationCount { get; set; }// Количество выполненных операций

        public Calculator()
        {
            Result = 0; // Инициализируем первоначальный результат равным 0
            storedResults = new List<CalculatorResult>(); // Инициализируем список для хранения результатов и информации об операциях
            OperationCount = 0; // Инициализируем количество выполняемых операций равным 0
        }
        InputReader inputReader = new InputReader();


        public void Run()
        {
            HelpPrinter helpPrinter = new HelpPrinter();
            helpPrinter.PrintInstructions(); // Показ инструкций при запуске

            bool quit = false;

            while (!quit)
            {
                FirstInput(); // Отображение текущего результата или запрос числа, если текущий результат равен 0

                Console.Write("@: ");
                char @operator = inputReader.ReadOperator();  // Читаем операторы от пользователя

                if (@operator == 'q')
                {
                    quit = true; // Выход из цикла, если пользователь вводит «q»
                    continue;
                }
                else if (@operator == '#')
                {
                    Result = RetrieveStoredResult(); // Получаем результаты из списка сохраненных результатов
                    continue;
                }

                Console.Write("> ");
                double number = inputReader.ReadNumber();// Читаем номер от пользователя

                PerformOperation(@operator, number);// Выполняем математические операции

                OperationCount++;
                DisplayOperationResult();// Отображение результатов после каждого расчета
            }

            Console.WriteLine("Goodbye!");
        }


        //Метод позволяет пользователю выбрать индекс из списка сохраненных результатов и возвращает соответствующее значение.
        public double RetrieveStoredResult()
        {
            while (true)
            {
                Console.Write("Enter index for stored Result: ");
                int index = inputReader.ReadIndex(); // Считаем индекс пользователя, чтобы получить сохраненные результаты

                return Retrive(index);

            }
        }

        public double Retrive(int index)
        {
            if (index < storedResults.Count)
            {
                OperationCount += 1;
                Console.WriteLine($"[#{OperationCount}] = {storedResults[index].Result}");
                return storedResults[index].Result;  // Возвращает результат, соответствующий введенному индексу

            }
            else
            {
                throw new ArgumentException($"Invalid index. The maximum available index is #{OperationCount - 1}. Please enter a valid index.");
            }
        }

        //показать результаты
        public void FirstInput()
        {
            if (Result == 0)
            {
                Console.Write("> ");
                Result = inputReader.ReadNumber(); // Если текущий результат равен 0, попросите пользователя ввести число
            }

        }


        //Отображает результат операции вместе с номером операции.
        public void DisplayOperationResult()
        {
            Console.WriteLine($"[#{OperationCount}] = {Result}");
        }

        public void PerformOperation(char @operator, double number)
        {
            CalculatorResult OperationResult = new CalculatorResult { Result = Result, OperationCount = OperationCount };

            switch (@operator)
            {
                case '+':
                    Result += number;
                    break;
                case '-':
                    Result -= number;
                    break;
                case '*':
                    Result *= number;
                    break;
                case '/':
                    if (number != 0)
                    {
                        Result /= number;
                    }
                    else
                    {
                        Console.WriteLine("Division by zero is not allowed.");
                    }
                    break;
            }

            storedResults.Add(OperationResult); // Сохраняем результаты и информацию о расчетах в список
        }
    }
}
