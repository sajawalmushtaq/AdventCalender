﻿using System.IO;
using System.Linq;

List<int> column1 = new List<int>();
List<int> column2 = new List<int>();

string[] lines = File.ReadAllLines("Data1_1.csv");

foreach (string line in lines)
{
    string[] columns = line.Split(new string[] { "   " }, StringSplitOptions.None);
    column1.Add(int.Parse(columns[0]));
    column2.Add(int.Parse(columns[1]));
}

int result = 0;
column1.Sort();
column2.Sort();
for(int i =0; i < 1000; i++)
{
    result += Math.Abs(column2[i] - column1[i]);
}
Console.Write(result);