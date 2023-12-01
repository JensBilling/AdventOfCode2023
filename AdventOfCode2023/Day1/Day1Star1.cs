namespace AdventOfCode2023.Day1;

public static class Day1Star1
{
    public static void Run()
    {
        var inputs = ReadInput();
        var values = ExtractValues(inputs);
        var sum = SumOfAllValues(values);
        Console.WriteLine("D1S1: " + sum);
    }

    private static string[] ReadInput()
    {
        return File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "inputs/day1/input1.txt"));
    }
    
    private static List<int> ExtractValues(string[] inputs)
    {
        List<int> values = new List<int>(); 
        foreach (var input in inputs)
        {
            string num1 = FindFirstNumberInString(input);
            var reversedString = input.Reverse().ToArray();
            string num2 = FindFirstNumberInString(new string(reversedString));
            values.Add(int.Parse(string.Concat(num1, num2)));
        }

        return values;
    }

    private static string FindFirstNumberInString(string str)
    {
        for (int i = 0; i < str.Length; i++)
        {
            if (int.TryParse(str[i].ToString(), out int _))
            {
                return str[i].ToString();
            }
        }

        return int.MinValue.ToString();
    }
    
    private static int SumOfAllValues(List<int> values)
    {
        int sum = 0;
        foreach (var value in values)
        {
            sum += value;
        }

        return sum;
    }
}