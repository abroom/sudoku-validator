using System;
using System.IO;

namespace AlexBroom.SudokuValidator
{
    class Validator
    {
        private const int SUDOKU_SIZE = 9;
        private const int SUDOKU_MIN = 1;
        private const int SUDOKU_MAX = 9;
        private int[,] grid;

        public Validator(string filename)
        {
            grid = new int[SUDOKU_SIZE, SUDOKU_SIZE];
            
            string[] rows = File.ReadAllLines(@filename);
            if (rows.Length != SUDOKU_SIZE)
            {
                throw new Exception("Invalid number of grid rows. The number of rows should be 9.");
            }

            for (int i = 0; i < rows.Length; i++)
            {
                string[] cols = rows[i].Split(' ');
                if (cols.Length != SUDOKU_SIZE)
                {
                    throw new Exception("Invalid number of grid columns. The number of columns should be 9.");
                }

                for (int j = 0; j < cols.Length; j++)
                {
                    grid[i, j] = int.Parse(cols[j]);
                    if (grid[i, j] < SUDOKU_MIN || grid[i, j] > SUDOKU_MAX)
                    {
                        throw new Exception("Invalid integer. Integers must be between 1 and 9 inclusive.");
                    } 
                }
            }
        }

        public bool Validate()
        {
            for (int i = 0; i < SUDOKU_SIZE; i++)
            {
                if (!ValidateRow(i) || !ValidateCol(i) || !ValidateSubGrid(i))
                {
                    return false;
                }
            }
            return true;
        }

        // Helpers
        private bool ValidateRow(int rowIndex)
        {
            int[] row = new int[SUDOKU_SIZE];
            for (int i = 0; i < SUDOKU_SIZE; i++)
            {
                row[i] = grid[rowIndex, i];
            }
            return ValidateAllDidgits(row);
        }

        private bool ValidateCol(int colIndex)
        {
            int[] col = new int[SUDOKU_SIZE];
            for (int i = 0; i < SUDOKU_SIZE; i++)
            {
                col[i] = grid[i, colIndex];
            }
            return ValidateAllDidgits(col);
        }

        private bool ValidateSubGrid(int subGridIndex)
        {
            int[] subGrid = new int[SUDOKU_SIZE];

            int rowIndex = subGridIndex / 3 * 3;
            int colIndex = subGridIndex % 3 * 3;
            
            int index = 0;
            for (int i = rowIndex; i < rowIndex + 3; i++)
            {
                for (int j = colIndex; j < colIndex + 3; j++)
                {
                    subGrid[index++] = grid[i, j];
                }
            }

            return ValidateAllDidgits(subGrid);
        }

        private bool ValidateAllDidgits(int[] didgits)
        {
            for (int i = SUDOKU_MIN; i <= SUDOKU_MAX; i++)
            {
                if (!Array.Exists(didgits, didgit => didgit == i))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
