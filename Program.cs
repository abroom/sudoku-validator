using System;

namespace AlexBroom.SudokuValidator
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Missing input filename. Usage: validateSudoku <fileName>");
                return 1;
            }

            int[,] grid;
            try
            {
                grid = GridLoader.FromFile(args[0]);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error occured loading file data.\nInvalid integer. Integers must be between 1 and 9 inclusive.");
                return 2;
            }
            catch (Exception e) {
                Console.WriteLine("Error occurred loading file data.\n{0}", e.Message);
                return 2;
            }

            Console.WriteLine("Hello World!");

            return 0;
        }
    }
}
