namespace AdventOfCode2023.Day7;

public class Day7Star1
{
    static List<Tuple<string, long>> _fiveOfAKinds = new List<Tuple<string, long>>();
    static List<Tuple<string, long>> _fourOfAKinds = new List<Tuple<string, long>>();
    static List<Tuple<string, long>> _fullHouses = new List<Tuple<string, long>>();
    static List<Tuple<string, long>> _threeOfAKinds = new List<Tuple<string, long>>();
    static List<Tuple<string, long>> _twoPairs = new List<Tuple<string, long>>();
    static List<Tuple<string, long>> _pairs = new List<Tuple<string, long>>();
    static List<Tuple<string, long>> _highCards = new List<Tuple<string, long>>();

    public static void Run()
    {
        var inputs = ReadInput();
        SortHands(inputs);

        SortFiveOfAKinds();
        SortFourOfAKinds();
        SortFullHouses();
        SortThreeOfAKinds();
        SortTwoPairs();
        SortPairs();
        SortHighCards();

        var combined = GetCombinedDictionary();
        var sum = CalculateTotal(combined);

        Console.WriteLine("D7S1: " + sum);
    }

    private static string[] ReadInput()
    {
        return File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "inputs/day7/input1.txt"));
    }

    private static void SortHands(string[] inputs)
    {
        foreach (var input in inputs)
        {
            var bet = int.Parse(input.Split(" ")[1]);
            SortHand(input.Split(" ")[0], bet);
        }
    }

    private static void SortFiveOfAKinds()
    {
        SortedDictionary<long, Tuple<string, long>> sorted = new SortedDictionary<long, Tuple<string, long>>();
        foreach (var hand in _fiveOfAKinds)
        {
            var value = GetCardValue(hand.Item1);
            sorted.Add(value, new Tuple<string, long>(hand.Item1, hand.Item2));
        }

        _fiveOfAKinds.Clear();
        for (int i = 0; i < sorted.Count; i++)
        {
            var thisIsStupid = sorted.ElementAt(i);
            _fiveOfAKinds.Add(new Tuple<string, long>(thisIsStupid.Value.Item1, thisIsStupid.Value.Item2));
        }
    }

    private static void SortFourOfAKinds()
    {
        SortedDictionary<long, Tuple<string, long>> sorted = new SortedDictionary<long, Tuple<string, long>>();
        foreach (var hand in _fourOfAKinds)
        {
            var value = GetCardValue(hand.Item1);
            sorted.Add(value, new Tuple<string, long>(hand.Item1, hand.Item2));
        }

        _fourOfAKinds.Clear();
        for (int i = 0; i < sorted.Count; i++)
        {
            var thisIsStupid = sorted.ElementAt(i);
            _fourOfAKinds.Add(new Tuple<string, long>(thisIsStupid.Value.Item1, thisIsStupid.Value.Item2));
        }
    }

    private static void SortFullHouses()
    {
        SortedDictionary<long, Tuple<string, long>> sorted = new SortedDictionary<long, Tuple<string, long>>();
        foreach (var hand in _fullHouses)
        {
            var value = GetCardValue(hand.Item1);
            sorted.Add(value, new Tuple<string, long>(hand.Item1, hand.Item2));
        }

        _fullHouses.Clear();
        for (int i = 0; i < sorted.Count; i++)
        {
            var thisIsStupid = sorted.ElementAt(i);
            _fullHouses.Add(new Tuple<string, long>(thisIsStupid.Value.Item1, thisIsStupid.Value.Item2));
        }
    }

    private static void SortThreeOfAKinds()
    {
        SortedDictionary<long, Tuple<string, long>> sorted = new SortedDictionary<long, Tuple<string, long>>();
        foreach (var hand in _threeOfAKinds)
        {
            var value = GetCardValue(hand.Item1);
            sorted.Add(value, new Tuple<string, long>(hand.Item1, hand.Item2));
        }

        _threeOfAKinds.Clear();
        for (int i = 0; i < sorted.Count; i++)
        {
            var thisIsStupid = sorted.ElementAt(i);
            _threeOfAKinds.Add(new Tuple<string, long>(thisIsStupid.Value.Item1, thisIsStupid.Value.Item2));
        }
    }

    private static void SortTwoPairs()
    {
        SortedDictionary<long, Tuple<string, long>> sorted = new SortedDictionary<long, Tuple<string, long>>();
        foreach (var hand in _twoPairs)
        {
            var value = GetCardValue(hand.Item1);
            sorted.Add(value, new Tuple<string, long>(hand.Item1, hand.Item2));
        }

        _twoPairs.Clear();
        for (int i = 0; i < sorted.Count; i++)
        {
            var thisIsStupid = sorted.ElementAt(i);
            _twoPairs.Add(new Tuple<string, long>(thisIsStupid.Value.Item1, thisIsStupid.Value.Item2));
        }
    }

    private static void SortPairs()
    {
        SortedDictionary<long, Tuple<string, long>> sorted = new SortedDictionary<long, Tuple<string, long>>();
        foreach (var hand in _pairs)
        {
            var value = GetCardValue(hand.Item1);
            sorted.Add(value, new Tuple<string, long>(hand.Item1, hand.Item2));
        }

        _pairs.Clear();
        for (int i = 0; i < sorted.Count; i++)
        {
            var thisIsStupid = sorted.ElementAt(i);
            _pairs.Add(new Tuple<string, long>(thisIsStupid.Value.Item1, thisIsStupid.Value.Item2));
        }
    }

    private static void SortHighCards()
    {
        SortedDictionary<long, Tuple<string, long>> sorted = new SortedDictionary<long, Tuple<string, long>>();
        foreach (var hand in _highCards)
        {
            var value = GetCardValue(hand.Item1);
            sorted.Add(value, new Tuple<string, long>(hand.Item1, hand.Item2));
        }

        _highCards.Clear();
        for (int i = 0; i < sorted.Count; i++)
        {
            var thisIsStupid = sorted.ElementAt(i);
            _highCards.Add(new Tuple<string, long>(thisIsStupid.Value.Item1, thisIsStupid.Value.Item2));
        }
    }

    private static List<long> GetCombinedDictionary()
    {
        List<long> combined = new List<long>();

        _fiveOfAKinds.Reverse();
        _fourOfAKinds.Reverse();
        _fullHouses.Reverse();
        _threeOfAKinds.Reverse();
        _twoPairs.Reverse();
        _pairs.Reverse();
        _highCards.Reverse();


        foreach (var hand in _fiveOfAKinds)
        {
            combined.Add(hand.Item2);
        }

        foreach (var hand in _fourOfAKinds)
        {
            combined.Add(hand.Item2);
        }

        foreach (var hand in _fullHouses)
        {
            combined.Add(hand.Item2);
        }

        foreach (var hand in _threeOfAKinds)
        {
            combined.Add(hand.Item2);
        }

        foreach (var hand in _twoPairs)
        {
            combined.Add(hand.Item2);
        }

        foreach (var hand in _pairs)
        {
            combined.Add(hand.Item2);
        }

        foreach (var hand in _highCards)
        {
            combined.Add(hand.Item2);
        }

        return combined;
    }

    private static long CalculateTotal(List<long> combined)
    {
        combined.Reverse();
        long total = 0;
        for (int i = 0; i < combined.Count; i++)
        {
            long win = combined[i] * (i + 1);
            total += win;
        }

        return total;
    }

    private static long GetCardValue(string hand)
    {
        string valueAsString = "";

        foreach (var card in hand)
        {
            switch (card)
            {
                case '2':
                    valueAsString += 101;
                    break;
                case '3':
                    valueAsString += 102;
                    break;
                case '4':
                    valueAsString += 103;
                    break;
                case '5':
                    valueAsString += 104;
                    break;
                case '6':
                    valueAsString += 105;
                    break;
                case '7':
                    valueAsString += 106;
                    break;
                case '8':
                    valueAsString += 107;
                    break;
                case '9':
                    valueAsString += 108;
                    break;
                case 'T':
                    valueAsString += 109;
                    break;
                case 'J':
                    valueAsString += 110;
                    break;
                case 'Q':
                    valueAsString += 111;
                    break;
                case 'K':
                    valueAsString += 112;
                    break;
                case 'A':
                    valueAsString += 113;
                    break;
            }
        }

        return long.Parse(valueAsString);
    }

    private static void SortHand(string hand, int bet)
    {
        List<char> cards = new List<char>();
        foreach (var card in hand)
        {
            cards.Add(card);
        }

        List<int> calculatedHand = new List<int> { 1, 1, 1, 1, 1 };
        for (int i = 0; i < cards.Count; i++)
        {
            for (int j = i + 1; j < hand.Length; j++)
            {
                if (cards[i].Equals(hand[j]))
                {
                    calculatedHand[i]++;
                    calculatedHand[j] = 0;
                    cards[j] = ' ';
                }
            }
        }

        if (calculatedHand.Contains(5))
        {
            _fiveOfAKinds.Add(new Tuple<string, long>(hand, bet));
            return;
        }

        if (calculatedHand.Contains(4))
        {
            _fourOfAKinds.Add(new Tuple<string, long>(hand, bet));
            return;
        }

        if (calculatedHand.Contains(3) && calculatedHand.Contains(2))
        {
            _fullHouses.Add(new Tuple<string, long>(hand, bet));
            return;
        }

        if (calculatedHand.Contains(3))
        {
            _threeOfAKinds.Add(new Tuple<string, long>(hand, bet));
            return;
        }

        int counter = 0;
        foreach (var ch in calculatedHand)
        {
            if (ch == 2)
            {
                counter += 2;
            }
        }

        if (counter == 4)
        {
            _twoPairs.Add(new Tuple<string, long>(hand, bet));
            return;
        }

        if (calculatedHand[0] == 1 &&
            calculatedHand[1] == 1 &&
            calculatedHand[2] == 1 &&
            calculatedHand[3] == 1 &&
            calculatedHand[4] == 1)
        {
            _highCards.Add(new Tuple<string, long>(hand, bet));
            return;
        }

        _pairs.Add(new Tuple<string, long>(hand, bet));
    }
}