using System;

namespace DelegateDemoMastek
{

    //Step1: Declare delegate
    delegate int CalculatorDelegate(int first, int second);
    
    class Program
    {
        //Step2: Declare a method
        static int AddNumbers (int number1, int number2)
        {
            return number1 + number2;
        }

        static void Main(string[] args)
        {
            //Step3: Delegate instance - points to a method
            //CalculatorDelegate demo1 = new CalculatorDelegate(AddNumbers);
            CalculatorDelegate demo1 = AddNumbers;

            //Step4: Invoke delegate
            int result = demo1(4, 6);
            Console.WriteLine("Addition : " + result);

            Console.WriteLine("----------------");

            //.net fw 3.5 - 2008 Lambda expression
            //merge step 2 + 3

            // (input param) => expression

            CalculatorDelegate demo2 = (a, b) => a + b;
            result = demo2(2, 4);
            Console.WriteLine("Addition = " + result);

            Console.WriteLine("----------------");

            //Subtraction

            CalculatorDelegate demo3 = (a, b) => a - b;
            result = demo3(8, 3);
            Console.WriteLine("Subtraction = " + result);

            Console.WriteLine("----------------");

            //Multiplication

            CalculatorDelegate demo4 = (a, b) => a * b;
            result = demo4(5, 6);
            Console.WriteLine("Multiplication = " + result);

            Console.WriteLine("----------------");

            //Division

            CalculatorDelegate demo5 = (a, b) => a / b;
            result = demo5(21, 3);
            Console.WriteLine("Division = " + result);

            Console.WriteLine("----------------");

            // Action / Action<T>
        }
    }
}
