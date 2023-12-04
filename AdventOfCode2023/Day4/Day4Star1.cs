namespace AdventOfCode2023.Day4;

public static class Day4Star1
{
    public static void Run()
    {
        var input = ReadInput();
        int sum = 0;
        foreach (string game in input)
        {
            string[] splitGame = game.Split("|");
            string winningNumbers = splitGame[0];
            string myNumbers = splitGame[1].Trim();
            winningNumbers = winningNumbers.Substring(winningNumbers.IndexOf(":") + 1).Trim();
            string[] winningNumbersArray = winningNumbers.Replace("  ", " ").Split(" ");
            string[] myNumbersArray = myNumbers.Split(" ");

            int points = CalculateWinnings(winningNumbersArray, myNumbersArray);
            sum += points;
        }

        Console.WriteLine("D4S1: " + sum);
    }
    
    private static string[] ReadInput()
    {
        return File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "inputs/day4/input1.txt"));
    }
    
    private static int CalculateWinnings(string[] winningNumbersArray, string[] myNumbersArray)
    {
        int amountOfCorrectNumbers = 0;

        foreach (var winNum in winningNumbersArray)
        {
            foreach (var myNum in myNumbersArray)
            {
                if (winNum.Equals(myNum))
                {
                    amountOfCorrectNumbers++;
                }
            }
        }

        return (int)Math.Pow(2, amountOfCorrectNumbers-1);
    }
}