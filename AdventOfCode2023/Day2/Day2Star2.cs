namespace AdventOfCode2023.Day2;

public static class Day2Star2
{
    public static void Run()
    {
        int sumOfCubeSetsPower = 0;

        var inputs = ReadInput();
        foreach (var gameInput in inputs)
        {
            sumOfCubeSetsPower += Game(gameInput);
        }

        Console.WriteLine("D2S2: " + sumOfCubeSetsPower);
    }

    private static string[] ReadInput()
    {
        return File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "inputs/day2/input1.txt"));
    }

    private static int Game(string gameInput)
    {
        int requiredRedCubes = 0;
        int requiredGreenCubes = 0;
        int requiredBlueCubes = 0;

        var splitGame = gameInput.Split(":");
        int gameId = int.Parse(splitGame[0].Substring(5));
        var splitGames = splitGame[1].Trim().Replace(" ", "").Split(";");
        
        foreach (var currentGame in splitGames)
        {
            var cubes = currentGame.Split(",");
            foreach (var cube in cubes)
            {
                if (cube.Contains("red"))
                {
                    var numberOfCubes = cube.Replace("red", "");
                    var value = int.Parse(numberOfCubes);
                    if (value > requiredRedCubes)
                    {
                        requiredRedCubes = value;
                    }
                }
                else if (cube.Contains("green"))
                {
                    var numberOfCubes = cube.Replace("green", "");
                    var value = int.Parse(numberOfCubes);
                    if (value > requiredGreenCubes)
                    {
                        requiredGreenCubes = value;
                    }
                }
                else if (cube.Contains("blue"))
                {
                    var numberOfCubes = cube.Replace("blue", "");
                    var value = int.Parse(numberOfCubes);
                    if (value > requiredBlueCubes)
                    {
                        requiredBlueCubes = value;
                    }
                }
            }
        }

        return requiredRedCubes * requiredGreenCubes *requiredBlueCubes;
    }
}