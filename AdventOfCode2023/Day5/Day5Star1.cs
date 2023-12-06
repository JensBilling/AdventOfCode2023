namespace AdventOfCode2023.Day5;

public static class Day5Star1
{
    public static void Run()
    {
        var input = ReadInput().ToList();
        input = input.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
        var seeds = GetSeeds(input);

        long lowestLocation = long.MaxValue;
        foreach (var seed in seeds)
        {
            input = ReadInput().ToList().Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            input.RemoveAt(0);

            var soil = GetValue(input, seed);
            var fert = GetValue(input, soil);
            var water = GetValue(input, fert);
            var light = GetValue(input, water);
            var temp = GetValue(input, light);
            var hum = GetValue(input, temp);
            var loc = GetValue(input, hum);
            if (loc < lowestLocation)
            {
                lowestLocation = loc;
            }
        }

        Console.WriteLine("D5S2: " + lowestLocation);
    }

    private static long GetValue(List<string> input, long sourceValue)
    {
        if (!long.TryParse(input[0].Substring(0, 1), out _))
        {
            input.RemoveAt(0);
        }

        long value = long.MinValue;
        for (int i = 0; i < input.Count; i++)
        {
            if (!long.TryParse(input[0].Substring(0, 1), out _))
            {
                input.RemoveAt(0);
                break;
            }

            var values = input[0].Split(" ");

            var sourceRange = long.Parse(values[1]);
            var destinationRange = long.Parse(values[0]);
            var rangeLength = long.Parse(values[2]);

            if (sourceValue >= sourceRange && sourceValue < sourceRange + rangeLength)
            {
                if (destinationRange < sourceRange)
                {
                    value = sourceValue - (sourceRange - destinationRange);
                }
                else
                {
                    value = sourceValue + (destinationRange - sourceRange);
                }

                break;
            }

            input.RemoveAt(0);

            if (!long.TryParse(input[0].Substring(0, 1), out _))
            {
                break;
            }
        }

        if (value < 0)
        {
            value = sourceValue;
        }

        int counter = 0;
        foreach (var x in input)
        {
            if (long.TryParse(x.Substring(0, 1), out _))
            {
                counter++;
            }
            else
            {
                break;
            }
        }

        for (int i = 0; i < counter; i++)
        {
            input.RemoveAt(0);
        }
        
        return value;
    }

    private static string[] ReadInput()
    {
        return File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "inputs/day5/input1.txt"));
    }

    private static long[] GetSeeds(List<string> input)
    {
        string[] seedsAsStrings = input[0].Split(":")[1].Trim().Split();
        input.RemoveAt(0);

        long[] seeds = new long[seedsAsStrings.Length];

        for (int i = 0; i < seeds.Length; i++)
        {
            seeds[i] = long.Parse(seedsAsStrings[i]);
        }

        return seeds;
    }
}