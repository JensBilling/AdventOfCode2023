namespace AdventOfCode2023.Day6;

public class Day6Star1
{
    public static void Run()
    {
        var inputs = ReadInput();

        var races = GetRaces(inputs);

        int total = 1;
        foreach (var race in races)
        {
            int NumberOfRecords = CalculateNumberOfRecords(race.Item1, race.Item2);
            total *= NumberOfRecords;
        }
        
        Console.WriteLine("D6S1: " + total);
    }

    private static int CalculateNumberOfRecords(int time, int distance)
    {
        int CURRENT_RECORD = distance;
        int numberOfWins = 0;
        
        for (int i = 0; i <= time; i++)
        {
            Console.WriteLine(i + "/" + time);
            int speed = i;
            int timeLeft = time - i;

            int myDistance = timeLeft * speed;

            if (myDistance > CURRENT_RECORD)
            {
                numberOfWins++;
            }

        }

        return numberOfWins;
    }

    private static List<Tuple<int, int>> GetRaces(string[] inputs)
    {
        var times = inputs[0];
        times = times.Substring(times.IndexOf(":") + 1).Trim();
        var timesArray = times.Split(" ");
        timesArray = timesArray.Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
        
        var distances = inputs[1];
        distances = distances.Substring(distances.IndexOf(":") + 1).Trim();
        var distancesArray = distances.Split(" ");
        distancesArray = distancesArray.Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();

        List<Tuple<int, int>> races = new List<Tuple<int, int>>();
        for (int i = 0; i < timesArray.Length; i++)
        {
            races.Add(new Tuple<int, int>(int.Parse(timesArray[i]), int.Parse(distancesArray[i])));
        }

        return races;
    }

    private static string[] ReadInput()
    {
        return File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "inputs/day6/input1.txt"));
    }
}