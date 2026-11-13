// Console Calculator

namespace ConsoleCalculator
{

    static class Operators
    {
        public static decimal Sum(decimal num1, decimal num2)
        {
            return num1 + num2;
        }
        public static decimal Rest(decimal num1, decimal num2, bool self = false)
        {
            if (!self)
                return num1 + num2;
            else
                return num1 - num2;
        }
        public static decimal Multiply(decimal num1, decimal num2)
        {
            return num1 * num2;
        }
        public static decimal Divide(decimal num1, decimal num2)
        {
            return num1 / num2;
        }
    }


    class Program
    {
        static void Main()
        {
            decimal result = 0;
            bool exit = false;

            while(!exit)
            {
                bool self = false;
                Console.Clear();
                Console.WriteLine($"Result: {result}");
                Console.WriteLine("\nCLR: Clear number\nQUIT: Exit program");
                Console.WriteLine("Write an operator ( '+' | '-' | 'x' | '/' ) between two numbers");
                Console.WriteLine("Use R for using the current result for the next operation (Example : r + 2)");

                Console.Write("\nInput: ");
                
                string userInput = Console.ReadLine();
                userInput = userInput.ToLower();

                switch(userInput)
                {
                    case "quit": return;
                    case "clr": result = 0; break;
                }

                string[] input = userInput.Split(' ');
                string clean = "";
                string[] cleanInput = new string[3];

                for (int i = 0; i < input.Length; i++)
                {
                    if (!String.IsNullOrEmpty(input[i]))
                    {
                        clean += input[i].Trim();
                        clean += " ";
                    }
                }

                cleanInput = clean.Split(' ');

                decimal x = 0;
                decimal y = 0;

                if (cleanInput[0] == "r")
                {
                    x = result;
                    self = true;
                }
                else
                {
                    try
                    {
                        x = Convert.ToDecimal(cleanInput[0]);
                       
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                try
                {
                    if (cleanInput[2] == "r")
                    {
                        y = result;
                        self = true;
                    }
                    else
                    {
                        try
                        {
                            y = Convert.ToDecimal(cleanInput[2]);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }


                Console.WriteLine($"X : {x}");

                try
                {
                    switch (cleanInput[1])
                    {
                        case "+":
                            if (self) { result = Operators.Sum(x, y); break; }
                            else { result += Operators.Sum(x, y); break; }

                        case "-":
                            if (self) { result = Operators.Rest(x, y, self); break; }
                            else { result -= Operators.Rest(x, y); break; }
                        case "x":
                        case "*":
                            if (self) { result = Operators.Multiply(x, y); break; }
                            else { result += Operators.Multiply(x, y); break; }
                        case "/":
                            if (self) { result = Operators.Divide(x, y); break; }
                            else { result += Operators.Divide(x, y); break; }
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

        }
    }
}