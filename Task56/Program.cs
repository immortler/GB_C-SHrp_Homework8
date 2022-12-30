/* Задача 56: 
Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7

Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка  */

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

void ShowStringWithMinSum(int rows, int[,] matrix)
{
    int[] arrayOfSums = new int[rows];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        arrayOfSums[i] = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            arrayOfSums[i] = arrayOfSums[i] + matrix[i, j];
        }
    }
    int minSum = arrayOfSums[0];
    int indexOfMinSum = 0;
    for (int i = 0; i < arrayOfSums.Length; i++)
    {
        if (arrayOfSums[i]<minSum)
        {
            minSum = arrayOfSums[i];
            indexOfMinSum = i+1;
        }
    }
    Console.WriteLine ($"A row with a minimum sum of elements: {indexOfMinSum}.\n");
    return;
}

int rows = GetNumber("Enter the number of rows:");
int columns = GetNumber("Enter the number of columns:");

int[,] matrix = InitRandomMatrix(rows, columns);

PrintArray("Origin random matrix:", matrix);
ShowStringWithMinSum(rows, matrix);
