/* Задача 62. 
Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07 */

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

int[,] InitHelixMatrix(int rows, int columns)
{
    int[,] matrix = new int[rows, columns];
    int counter = 0;
    int round = 0;
    int i = 0;
    int j = 0;
    while (counter <= rows * columns)
    {
        i = round;
        for (j = round; j <= matrix.GetLength(1) - round; j++)
        {
            if (j == matrix.GetLength(1) - 1 - round)
            {
                if (i < matrix.GetLength(0) && matrix[i, j] == 0)
                {
                    counter++;
                    matrix[i, j] = counter;
                    j--;
                    i++;
                }
                else
                {
                    break;
                }
            }
            else
            {
                if (i < 0 || j < 0 || i >= matrix.GetLength(0) || j >= matrix.GetLength(1))
                {
                    break;
                }
                else
                {
                    if (matrix[i, j] == 0)
                    {
                        counter++;
                        matrix[i, j] = counter;
                    }
                }
            }
        }
        round++;
        i = matrix.GetLength(0) - round;
        for (j = matrix.GetLength(1) - 1 - round; j >= 0; j--)
        {
            if (j == 0 + round - 1 && matrix[i, j] == 0)
            {

                if (i >= round && matrix[i, j] == 0)
                {
                    counter++;
                    matrix[i, j] = counter;
                    j++;
                    i--;
                }
                else
                {
                    break;
                }
            }
            else
            {
                if (i < 0 || j < 0 || i >= matrix.GetLength(0) || j >= matrix.GetLength(1))
                {
                    break;
                }
                else
                {
                    if (matrix[i, j] == 0)
                    {
                        counter++;
                        matrix[i, j] = counter;
                    }
                }
            }

        }
        if (round > matrix.GetLength(0) || round > matrix.GetLength(1))
        {
            break;
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
            if (matrix[i, j] < 10)
            {
                Console.Write($"0{matrix[i, j]} ");
            }
            else
            {
                Console.Write($"{matrix[i, j]} ");
            }
        }
        Console.WriteLine();
    }
}
int rows = GetNumber("Enter the number of rows:");
int columns = GetNumber("Enter the number of columns:");

int[,] matrix = InitHelixMatrix(rows, columns);
PrintArray($"Spirally filled matrix {rows}x{columns}:", matrix);