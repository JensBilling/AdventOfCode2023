namespace AdventOfCode2023.Day3;

public static class Day3Star1
{
    public static void Run()
    {
        var input = ReadInput();
        var partNumbers = GetPartNumbers(input);

        int sum = 0;

        foreach (var partNumber in partNumbers)
        {
            if (partNumber.IsAdjacentToSymbol)
            {
                sum += partNumber.Value;
            }
        }

        Console.WriteLine("D3S1: " + sum);
    }


    private static string[] ReadInput()
    {
        return File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "inputs/day3/input1.txt"));
    }

    private static List<PartNumber> GetPartNumbers(string[] input)
    {
        List<PartNumber> partNumbers = new List<PartNumber>();

        string[,] dataMatrix = ExtractDataMatrix(input);


        for (int row = 0; row < dataMatrix.GetLength(0); row++)
        {
            var rowAsArray = Enumerable.Range(0, dataMatrix.GetLength(1))
                .Select(val => dataMatrix[row, val])
                .ToArray();

            int startIndex = -1;
            int endIndex = -1;

            for (int i = 0; i < rowAsArray.Length; i++)
            {
                if (int.TryParse(rowAsArray[i], out _))
                {
                    if (startIndex != -1)
                    {
                        endIndex++;
                    }

                    if (startIndex == -1)
                    {
                        startIndex = i;
                        endIndex = startIndex + 1;
                    }
                }
                else if (endIndex >= 0)
                {
                    PartNumber partNumber = new PartNumber(dataMatrix, row, startIndex, endIndex);
                    partNumbers.Add(partNumber);
                    startIndex = -1;
                    endIndex = -1;
                }
            }
        }
        
        return partNumbers;
    }

    private static string[,] ExtractDataMatrix(string[] input)
    {
        string[,] dataMatrix = new string[input.Length + 2, input[0].Length + 2];

        dataMatrix = FrameDataMatrix(dataMatrix);
        
        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < input[i].Length; j++)
            {
                dataMatrix[i + 1, j + 1] = input[i][j].ToString();
                if (int.TryParse(dataMatrix[i + 1, j + 1], out _))
                {
                    continue;
                }

                if (dataMatrix[i + 1, j + 1].Equals("."))
                {
                    continue;
                }

                dataMatrix[i +1, j +1] = "*";
            }
        }

        return dataMatrix;
    }

    private static string[,] FrameDataMatrix(string[,] dataMatrix)
    {
        for (int i = 0; i < dataMatrix.GetLength(1); i++)
        {
            dataMatrix[0, i] = ".";
        }
        
        for (int i = 0; i < dataMatrix.GetLength(1); i++)
        {
            dataMatrix[dataMatrix.GetLength(0) -1, i] = ".";
        }

        for (int i = 0; i < dataMatrix.GetLength(0); i++)
        {
            dataMatrix[i, 0] = ".";
            dataMatrix[i, dataMatrix.GetLength(1) -1] = ".";
        }
        
        return dataMatrix;
    }
}

class PartNumber
{
    private string[,] DataMatrix { get; set; }
    public int Value { get; set; }
    private int _row;
    private int _startIndex;
    private int _endIndex;
    public bool IsAdjacentToSymbol { get; set; }

    public PartNumber(string[,] dataMatrix, int row, int startIndex, int endIndex)
    {
        DataMatrix = dataMatrix;
        _row = row;
        _startIndex = startIndex;
        _endIndex = endIndex;

        HandlePartNumber();
    }

    private void HandlePartNumber()
    {
        string valueAsString = "";

        for (int i = _startIndex; i < _endIndex; i++)
        {
            valueAsString += DataMatrix[_row, i];
            DataMatrix[_row, i] = ".";
        }

        if (int.TryParse(valueAsString, out _))
        {
            Value = int.Parse(valueAsString);

            for (int i = 0; i < valueAsString.Length; i++)
            {
                CheckSurroundingCellsForStar(_row, _startIndex + i);
            }
        }
    }

    private void CheckSurroundingCellsForStar(int row, int col)
    {
        if (DataMatrix[row - 1, col - 1].Equals("*"))
        {
            IsAdjacentToSymbol = true;
        }

        if (DataMatrix[row - 1, col].Equals("*"))
        {
            IsAdjacentToSymbol = true;
        }

        if (DataMatrix[row - 1, col + 1].Equals("*"))
        {
            IsAdjacentToSymbol = true;
        }

        if (DataMatrix[row, col - 1].Equals("*"))
        {
            IsAdjacentToSymbol = true;
        }

        if (DataMatrix[row, col + 1].Equals("*"))
        {
            IsAdjacentToSymbol = true;
        }

        if (DataMatrix[row + 1, col - 1].Equals("*"))
        {
            IsAdjacentToSymbol = true;
        }

        if (DataMatrix[row + 1, col].Equals("*"))
        {
            IsAdjacentToSymbol = true;
        }

        if (DataMatrix[row + 1, col + 1].Equals("*"))
        {
            IsAdjacentToSymbol = true;
        }
    }
}