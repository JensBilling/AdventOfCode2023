namespace AdventOfCode2023.Day6;

public class Day6Star2
{
    public static void Run()
    {
        var inputs = ReadInput();

        var races = GetRaces(inputs);

        int total = 1;
        foreach (var race in races)
        {
            int numberOfRecords = CalculateNumberOfRecords(race.Item1, race.Item2);
            total *= numberOfRecords;
        }

        Console.WriteLine("D6S2: " + total);
    }

    private static int CalculateNumberOfRecords(long time, long distance)
    {
        long CURRENT_RECORD = distance;
        int numberOfWins = 0;
        for (int i = 0; i <= time; i++)
        {
            long speed = i;
            long timeLeft = time - i;

            long myDistance = timeLeft * speed;

            if (myDistance > CURRENT_RECORD)
            {
                numberOfWins++;
            }
        }

        return numberOfWins;
    }

    private static List<Tuple<long, long>> GetRaces(string[] inputs)
    {
        var times = inputs[0].Replace(" ", "");
        times = times.Substring(times.IndexOf(":") + 1).Trim();
        var timesArray = times.Split(" ");
        timesArray = timesArray.Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();

        var distances = inputs[1].Replace(" ", "");
        distances = distances.Substring(distances.IndexOf(":") + 1).Trim();
        var distancesArray = distances.Split(" ");
        distancesArray = distancesArray.Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();

        List<Tuple<long, long>> races = new List<Tuple<long, long>>();
        for (int i = 0; i < timesArray.Length; i++)
        {
            races.Add(new Tuple<long, long>(long.Parse(timesArray[i]), long.Parse(distancesArray[i])));
        }

        return races;
    }

    private static string[] ReadInput()
    {
        return File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "inputs/day6/input1.txt"));
    }
}