/*  Задача 54: 
Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2  */

int GetNumber(string message)
{
    bool isCorrect = false;
    int result = 0;

    while (!isCorrect)
    {
        Console.WriteLine(message);

        if (int.TryParse(Console.ReadLine(), out result) && result > 0)
        {
            isCorrect = true;
        }
        else
        {
            Console.WriteLine("Error: wrong entry.");
        }
    }
    return result;
}

int[,] InitRandomMatrix(int rows, int columns)
{
    int[,] matrix = new int[rows, columns];
    Random rnd = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(1, 100);
        }
    }

    return matrix;
}

void PrintArray(string printMessage, int[,] matrix)
{
    Console.WriteLine(printMessage);
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}

int[,] SortRowsFromMaxToMin(int rows, int columns, int[,] matrix)
{
    int[,] sortedMatrix = matrix.Clone() as int[,];
    int max = sortedMatrix[0, 0];
    int maxIndex = 0;
    int cycle = 0;

    for (int i = 0; i < sortedMatrix.GetLength(0); i++)
    {
        while (cycle <= sortedMatrix.GetLength(1))
        {
            maxIndex = cycle;
            for (int j = cycle; j < sortedMatrix.GetLength(1); j++)
            {
                if (sortedMatrix[i, j] >= max)
                {
                    max = sortedMatrix[i, j];
                    maxIndex = j;                    
                }
            }
            if (cycle < matrix.GetLength(1) - 1)
            {
                max = matrix[i, cycle + 1];
            }
            if (cycle < matrix.GetLength(1))
            {
                if (cycle != maxIndex)
                {                          
                    (sortedMatrix[i, cycle], sortedMatrix[i, maxIndex]) = (sortedMatrix[i, maxIndex], sortedMatrix[i, cycle]);                    
                }
            }
            cycle++;
            
        }
        cycle = 0;
        if (i + 1 < matrix.GetLength(0))
        {
            max = matrix[i + 1, 0];
        }
        // else
        // {
        //     max = matrix[i, 0];
        // }
    }
    return sortedMatrix;
}

int rows = GetNumber("Enter the number of rows:");
int columns = GetNumber("Enter the number of columns:");

int[,] matrix = InitRandomMatrix(rows, columns);

PrintArray("\nOrigin random matrix:", matrix);

int[,] sortedMatrix = SortRowsFromMaxToMin(rows, columns, matrix);

PrintArray("\nSorted matrix:", sortedMatrix);