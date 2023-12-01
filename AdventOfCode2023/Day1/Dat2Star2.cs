namespace AdventOfCode2023.Day1;

public static class Day1Star2
{
    public static void Run()
    {
        var inputs = ReadInput();
        var updatedInputs = CalibrateInput(inputs);
        var values = ExtractValues(updatedInputs);
        var sum = SumOfAllValues(values);
        Console.WriteLine("D1S2: " + sum);
    }

    private static string[] ReadInput()
    {
        return File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "inputs/day1/input1.txt"));
    }

    private static List<string> CalibrateInput(string[] inputs)
    {
        List<string> calibratedInput = new List<string>();
        foreach (var input in inputs)
        {
            string str = input;
            str = str.Replace("one", "one1one");
            str = str.Replace("two", "two2two");
            str = str.Replace("three", "three3three");
            str = str.Replace("four", "four4four");
            str = str.Replace("five", "five5five");
            str = str.Replace("six", "six6six");
            str = str.Replace("seven", "seven7seven");
            str = str.Replace("eight", "eight8eight");
            str = str.Replace("nine", "nine9nine");
            str = str.Replace("zero", "zero0zero");
            calibratedInput.Add(str);
        }

        return calibratedInput;
    }

    private static List<int> ExtractValues(List<string> inputs)
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