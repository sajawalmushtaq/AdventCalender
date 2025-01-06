using System.IO;
using System.Linq;

//create source for output tfs, and read all lines
List<bool> tfs = new List<bool>();
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
    tfs.Add(valid(row));
}
//recheck false with removals

for (int i = 0; i < tfs.Count; i++)
{
    if (!tfs[i])
    {
        List<int> temp = new(rows[i]);
        int length = temp.Count;
        for (int j = 0; j < length; j++)
        {
            temp = new(rows[i]);
            temp.RemoveAt(j);
            if (valid(temp))
            {
                tfs[i] = true;
            }
        }
    }
}
//tally up and print
int result = tfs.Count(tf => tf); 
Console.Write(result);
bool valid(List<int> row1)
{
    //id is initial increasing/decreasing
    bool? id = null;
    for (int i = 0; i < row1.Count - 1; i++)
    {
        //assign initial increasing/decreasing value
        if (row1[i] - row1[i + 1] > 0)
        {
            id = true;
            break;
        }
        else if (row1[i] - row1[i + 1] < 0)
        {
            id = false;
            break;
        }
    }

    if (id == null)
    {
        return false;
    }

    for (int i = 0; i < row1.Count - 1; i++)
    {
        //check whether it flips increasing/decreasing direction, or drops to 0
        if (row1[i] - row1[i + 1] < 0 && id == false || row1[i] - row1[i + 1] > 0 && id == true) { }
        else
        {
            return false;
        }
        //check whether it increases or decreases too much
        if (Math.Abs((row1[i] - row1[i + 1])) < 4) { }
        else
        {
            return false;
        }
    }

    return true;
}