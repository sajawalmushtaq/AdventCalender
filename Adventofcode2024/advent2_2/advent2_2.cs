using System.IO;
using System.Linq;

//create output result, and source for output tfs, and read all lines
List<bool> tfs = new List<bool>();
int result = 0;
string[] lines = File.ReadAllLines("C:\\Users\\sajaw\\Documents\\Github\\Adventofcode2024\\AdventCalender\\Adventofcode2024\\advent2_1\\Data2.csv");
List<List<int>> rows = new();
//checking each line's validity
foreach (string line in lines)
{
    //add line of string integers to row int list
    string[] nums = line.Split(new string[] { " " }, StringSplitOptions.None);
    List<int> row = new List<int>();
    for (int i = 0; i < nums.Length; i++)
        row.Add(int.Parse(nums[i]));
    rows.Add(row);
    //id is initial increasing/decreasing
    bool? id = null;
    //tf is final answer to whether the row is valid
    bool tf = true;
    for (int i = 0; i < row.Count - 1; i++)
    {
        //assign initial increasing/decreasing value
        if (row[i] - row[i + 1] > 0)
        {
            id = true;
            break;
        }
        else if (row[i] - row[i + 1] < 0)
        {
            id = false;
            break;
        }
    }

    if (id == null)
    {
        tf = false;
        continue;
    }

    for (int i = 0; i < row.Count - 1; i++)
    {
        //check whether it flips increasing/decreasing direction, or drops to 0
        if (row[i] - row[i + 1] < 0 && id == false || row[i] - row[i + 1] > 0 && id == true) { }
        else
        {
            tf = false;
            break;
        }
        //check whether it increases or decreases too much
        if (Math.Abs((row[i] - row[i + 1])) < 4) { }
        else
        {
            tf = false;
            break;
        }
    }
    tfs.Add(tf);
}
//recheck false with removals
List<int> temp = new();
for (int i = 0; i < tfs.Count; i++)
{
    if (!tfs[i])
    {
        temp = rows[i];
        bool tf = false;
        for (int j = 0; j < temp.Count; j++)
        {
            temp.Remove(j)
        }
        tfs[i] = tf;
    }
}
//tally up and print
foreach (bool tf in tfs)
{
    if (tf)
        result++;
}
Console.Write(result);


bool valid(int)
{
    //id is initial increasing/decreasing
    bool? id = null;
    //tf is final answer to whether the row is valid
    bool tf = true;
    for (int i = 0; i < row.Count - 1; i++)
    {
        //assign initial increasing/decreasing value
        if (row[i] - row[i + 1] > 0)
        {
            id = true;
            break;
        }
        else if (row[i] - row[i + 1] < 0)
        {
            id = false;
            break;
        }
    }

    if (id == null)
    {
        tf = false;
        continue;
    }

    for (int i = 0; i < row.Count - 1; i++)
    {
        //check whether it flips increasing/decreasing direction, or drops to 0
        if (row[i] - row[i + 1] < 0 && id == false || row[i] - row[i + 1] > 0 && id == true) { }
        else
        {
            tf = false;
            break;
        }
        //check whether it increases or decreases too much
        if (Math.Abs((row[i] - row[i + 1])) < 4) { }
        else
        {
            tf = false;
            break;
        }
    }
}