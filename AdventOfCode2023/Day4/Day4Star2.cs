namespace AdventOfCode2023.Day4;

public static class Day4Star2
{
    public static void Run()
    {
        var input = ReadInput();

        var cardPointCollection = GenerateDictionaryOfCardsAndPoints(input);
        var cardAmountCollection = GenerateDictionaryOfCardsAndAmounts(cardPointCollection);
        
        int totalNumberOfCards = 0;
        foreach (var card in cardAmountCollection)
        {
            totalNumberOfCards += card.Value;
        }

        Console.WriteLine("D4S2: " + totalNumberOfCards);
    }

    private static string[] ReadInput()
    {
        return File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "inputs/day4/input1.txt"));
    }

    private static Dictionary<int, int> GenerateDictionaryOfCardsAndPoints(string[] input)
    {
        Dictionary<int, int> cardCollection = new Dictionary<int, int>();
        for (int i = 0; i < input.Length; i++)
        {
            cardCollection.Add(i, 0);
        }

        for (int i = 0; i < input.Length; i++)
        {
            string[] splitGame = input[i].Split("|");
            string winningNumbers = splitGame[0];
            string myNumbers = splitGame[1].Trim();
            winningNumbers = winningNumbers.Substring(winningNumbers.IndexOf(":") + 1).Trim();
            string[] winningNumbersArray = winningNumbers.Replace("  ", " ").Split(" ");
            string[] myNumbersArray = myNumbers.Replace("  ", " ").Split(" ");

            int points = CalculatePoints(winningNumbersArray, myNumbersArray);

            cardCollection[i] = points;
        }

        return cardCollection;
    }
    
    private static int CalculatePoints(string[] winningNumbersArray, string[] myNumbersArray)
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

        return amountOfCorrectNumbers;
    }

    private static Dictionary<int, int> GenerateDictionaryOfCardsAndAmounts(Dictionary<int, int> cardPointCollection)
    {
        Dictionary<int, int> cardAmountCollection = new Dictionary<int, int>();
        for (int i = 0; i < cardPointCollection.Count; i++)
        {
            cardAmountCollection.Add(i, 1);
        }

        for (int i = 0; i < cardAmountCollection.Count; i++)
        {
            int numberOfCardsToCollect = cardPointCollection[i];

            for (int j = 0; j < numberOfCardsToCollect; j++)
            {
                for (int k = 0; k < cardAmountCollection[i]; k++)
                {
                    cardAmountCollection[i + 1 + j]++;
                }
            }
        }

        return cardAmountCollection;
    }
}