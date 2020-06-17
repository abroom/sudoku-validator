# README

A simple C# console application for sudoku validation.

The app takes a CLI input parameter for a text file. The contents of the file has the values of the sudoku grid where each row is seperated by a newline and each column is seperated by a space.

The app will asynchronous check whether the sudoku grid is valid. Once all validations have completed, it will output `Yes, valid` or `No, invalid` obviously depending on whether the sudoku solution is valid or invalid.

## Usage

From source:
`dotnet run <inputFileName>`

From publish:
`sudoku-validator <inputFileName>`
