using System;
using System.IO;

namespace AlexBroom.SudokuValidator
{
    class GridLoader
    {
        public static int[,] FromFile(string filename)
        {
            int[,] grid = new int[9, 9];
            
            string[] rows = File.ReadAllLines(@filename);
            if (rows.Length != 9)
            {
                throw new Exception("Invalid number of grid rows. The number of rows should be 9.");
            }

            for (int i = 0; i < rows.Length; i++)
            {
                string[] cols = rows[i].Split(' ');
                if (cols.Length != 9)
                {
                    throw new Exception("Invalid number of grid columns. The number of columns should be 9.");
                }

                for (int j = 0; j < cols.Length; j++)
                {
                    grid[i, j] = int.Parse(cols[j]);
                    if (grid[i, j] < 1 || grid[i, j] > 9)
                    {
                        throw new Exception("Invalid integer. Integers must be between 1 and 9 inclusive.");
                    } 
                }
            }

            return grid;
        }
    }
}

