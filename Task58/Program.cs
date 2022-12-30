/*  Задача 58: 
Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18  */

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
            matrix[i, j] = rnd.Next(1, 10);
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

int[,] MultiplicationOfTwoMatrix(int rowsA, int columnsB, int[,] matrixA, int[,] matrixB)
{    
    int[,] result = new int[rowsA, columnsB];
    
    for (int i = 0; i < result.GetLength(0); i++)
    {
        for (int j = 0; j < result.GetLength(1); j++)
        {
            for (int k = 0; k < matrixB.GetLength(0); k++)
            {
                result[i, j] = result[i, j] + matrixA[i, k] * matrixB[k, j];
            }
        }
    }
    return result;
}

int rowsA = GetNumber("Enter the number of rows of the first matrix (A):");
int columnsA = GetNumber("Enter the number of columns of the first matrix (A):");

int rowsB = GetNumber("Enter the number of rows of the second matrix (B):");
int columnsB = GetNumber("Enter the number of columns of the second matrix (B):");

if (columnsA != rowsB)
{
    Console.WriteLine("Number of columns of matrix A is not equal to number of rows of matrix B, multiplication is impossible.");
}
else
{
    int[,] matrixA = InitRandomMatrix(rowsA, columnsA);

    int[,] matrixB = InitRandomMatrix(rowsB, columnsB);

    PrintArray("Origin random matrix A:", matrixA);
    PrintArray("Origin random matrix B:", matrixB);

    int[,] multiplicatedMatrixC = MultiplicationOfTwoMatrix(rowsA, columnsB, matrixA, matrixB);
    PrintArray("Result of multiplication A*B is a matrix C:", multiplicatedMatrixC);
}