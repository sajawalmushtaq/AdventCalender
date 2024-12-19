using System.IO;
using System.Linq;

List<int> column1 = new List<int>();
List<int> column2 = new List<int>();

string[] lines = File.ReadAllLines("C:\\Users\\sajaw\\Documents\\Github\\Adventofcode2024\\AdventCalender\\Adventofcode2024\\advent1_1\\Data1.csv");

foreach (string line in lines)
{
    string[] columns = line.Split(new string[] { "   " }, StringSplitOptions.None);
    column1.Add(int.Parse(columns[0]));
    column2.Add(int.Parse(columns[1]));
}
column1.Sort();
column2.Sort();
int similar = 0;
foreach(int num in column1)
{
    foreach (int num1 in column2)
    {
        if (num == num1)
            similar += num;
    }
}
Console.WriteLine(similar);