using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string memory = File.ReadAllText("C:\\Users\\sajaw\\Documents\\Github\\Adventofcode2024\\AdventCalender\\Adventofcode2024\\advent3_1\\Data3.txt");
        int total = 0;

        for (int i = 0; i < memory.Length; i++)
        {
            if (memory.Substring(i).StartsWith("mul("))
            {
                int startIndex = i + 4; // Skip "mul("
                int commaIndex = memory.IndexOf(',', startIndex);
                int closeParenIndex = memory.IndexOf(')', commaIndex);

                if (commaIndex > 0 && closeParenIndex > 0)
                {
                    string num1Str = memory.Substring(startIndex, commaIndex - startIndex).Trim();
                    string num2Str = memory.Substring(commaIndex + 1, closeParenIndex - commaIndex - 1).Trim();

                    if (int.TryParse(num1Str, out int num1) && int.TryParse(num2Str, out int num2))
                    {
                        total += num1 * num2;
                    }
                }
            }
        }

        Console.WriteLine("Total sum of multiplications: " + total);
    }
}