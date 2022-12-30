/* Задача 60. 
...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2:
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)  */

int GetNumber(string message, bool isNatural)
{
    bool isCorrect = false;
    int result = 0;

    while (!isCorrect)
    {
        Console.WriteLine(message);
        if (isNatural == true)
        {
            if (int.TryParse(Console.ReadLine(), out result) && result > 0)
            {
                isCorrect = true;
            }
            else
            {
                Console.WriteLine("Error: wrong entry.");
            }
        }
        else
        {
            if (int.TryParse(Console.ReadLine(), out result))
            {
                isCorrect = true;
            }
            else
            {
                Console.WriteLine("Error: wrong entry.");
            }
        }
    }
    return result;
}

int[,,] InitRandomArray(int rows, int columns, int depth, int minRandom, int maxRandom)
{
    string check = "";
    int tmp = 0;
    string tempString = "";
    int[,,] threeDimensionalArray = new int[rows, columns, depth];
    Random rnd = new Random();

    for (int i = 0; i < threeDimensionalArray.GetLength(0); i++)
    {
        for (int j = 0; j < threeDimensionalArray.GetLength(1); j++)
        {
            for (int k = 0; k < threeDimensionalArray.GetLength(2); k++)
            {
                tmp = rnd.Next(minRandom, maxRandom+1);
                tempString = Convert.ToString(tmp);
                if (check.Contains(tempString))
                {
                    k--;
                }
                else
                {
                    threeDimensionalArray[i, j, k] = tmp;
                    check = check + threeDimensionalArray[i, j, k];
                }
            }
        }
    }

    return threeDimensionalArray;
}

void PrintArray(string printMessage, int[,,] threeDimensionalArray)
{
    Console.WriteLine(printMessage);
    for (int i = 0; i < threeDimensionalArray.GetLength(0); i++)
    {
        for (int j = 0; j < threeDimensionalArray.GetLength(1); j++)
        {
            for (int k = 0; k < threeDimensionalArray.GetLength(2); k++)
            {
            Console.Write($"{threeDimensionalArray[i, j, k]}({i},{j},{k}) ");
            }
        }
        Console.WriteLine();
    }
    Console.WriteLine("\n");
}

int rows = GetNumber("Enter the number of rows:", true);
int columns = GetNumber("Enter the number of columns:", true);
int depth = GetNumber("Enter the depth of the array:", true);
Console.WriteLine($"The range of random numbers must be greater than the product of rows, columns and depth (>{rows * columns * depth}).");
int minRandom = GetNumber("Enter the minimum random element:", false);
int maxRandom = GetNumber("Enter the maximum random element:", false);

if (maxRandom - minRandom < rows * columns * depth)
{
    Console.WriteLine("The range of random numbers is less than the product of rows, columns and depth; fatal error.");
}
else
{
    int[,,] threeDimensionalArray = InitRandomArray(rows, columns, depth, minRandom, maxRandom);

    PrintArray("\nYour random three-dimensional array:", threeDimensionalArray);
}