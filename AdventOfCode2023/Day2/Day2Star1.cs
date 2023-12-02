namespace AdventOfCode2023.Day2;

public class Day2Star1
{
    public static void Run()
    {
        int sumOfGameIDs = 0;

        var inputs = ReadInput();
        foreach (var gameInput in inputs)
        {
            sumOfGameIDs += Game(gameInput);
        }
        
        Console.WriteLine("D2S1: " + sumOfGameIDs);

    }
    
    private static string[] ReadInput()
    {
        return File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "inputs/day2/input1.txt"));
    }

    private static int Game(string gameInput)
    {        
        const int LOADED_RED_CUBES = 12;
        const int LOADED_GREEN_CUBES = 13;
        const int LOADED_BLUE_CUBES = 14;
        
        var splitGame = gameInput.Split(":");
        int gameId = int.Parse(splitGame[0].Substring(5));
        var splitGames = splitGame[1].Trim().Replace(" ", "").Split(";");

        bool isRedPossible = true;
        bool isBluePossible = true;
        bool isGreenPossible = true;
        foreach (var currentGame in splitGames)
        {
            var cubes = currentGame.Split(",");
            foreach (var cube in cubes)
            {
                if (cube.Contains("red"))
                {
                    var numberOfCubes = cube.Replace("red", "");
                    var value = int.Parse(numberOfCubes);
                    if (value > LOADED_RED_CUBES)
                    {
                        isRedPossible = false;
                    }
                }
                else if (cube.Contains("green"))
                {
                    var numberOfCubes = cube.Replace("green", "");
                    var value = int.Parse(numberOfCubes);
                    if (value > LOADED_GREEN_CUBES)
                    {
                        isGreenPossible = false;
                    }
                }
                else if (cube.Contains("blue"))
                {
                    var numberOfCubes = cube.Replace("blue", "");
                    var value = int.Parse(numberOfCubes);
                    if (value > LOADED_BLUE_CUBES)
                    {
                        isBluePossible = false;
                    }
                }
            }
        }
        
        if (isRedPossible && isGreenPossible && isBluePossible)
        {
            return gameId;
        }
        return 0;
    }
}