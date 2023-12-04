namespace AdventOfCode2023.Day3;

public static class Day3Star2
{
    public static void Run()
    {
        var input = ReadInput();
        var starCells = GetDataMatrixAndStarCells(input);

        int sum = 0;
        foreach (var starCell in starCells)
        {
            sum += starCell.ProductOfNumbers;
        }

        Console.WriteLine("D3S2: " + sum);
    }
    
    private static string[] ReadInput()
    {
        return File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "inputs/day3/input1.txt"));
    }

    private static List<StarCell> GetDataMatrixAndStarCells(string[] input)
    {
        string[,] dataMatrix = ExtractDataMatrix(input);

        List<StarCell> starCells = ExtractStarCells(dataMatrix);


        return starCells;
    }

    private static List<StarCell> ExtractStarCells(string[,] dataMatrix)
    {
        List<StarCell> starCells = new List<StarCell>();
        for (int i = 0; i < dataMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < dataMatrix.GetLength(1); j++)
            {
                if (dataMatrix[i, j].Equals("*"))
                {
                    StarCell starCell = new StarCell(dataMatrix, i, j);
                    if (starCell.ProductOfNumbers != -1)
                    {
                        starCells.Add(starCell);
                    }
                }
            }
        }

        return starCells;
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
            dataMatrix[dataMatrix.GetLength(0) - 1, i] = ".";
        }

        for (int i = 0; i < dataMatrix.GetLength(0); i++)
        {
            dataMatrix[i, 0] = ".";
            dataMatrix[i, dataMatrix.GetLength(1) - 1] = ".";
        }

        return dataMatrix;
    }
}

class StarCell
{
    public string[,] DataMatrix { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }
    private bool[] rowAbove = new bool[3];
    private bool[] rowSame = new bool[3];
    private bool[] rowBelow = new bool[3];
    public int ProductOfNumbers { get; set; } = -1;

    public StarCell(string[,] dataMatrix, int row, int column)
    {
        DataMatrix = dataMatrix;
        Row = row;
        Column = column;

        CheckSurroundingCellsForNumericCharacters();
        GetCompleteNumberStrings();
    }

    private void CheckSurroundingCellsForNumericCharacters()
    {
        rowSame[1] = false;
        if (int.TryParse(DataMatrix[Row - 1, Column - 1], out _))
        {
            rowAbove[0] = true;
        }

        if (int.TryParse(DataMatrix[Row - 1, Column], out _))
        {
            rowAbove[1] = true;
        }

        if (int.TryParse(DataMatrix[Row - 1, Column + 1], out _))
        {
            rowAbove[2] = true;
        }

        if (int.TryParse(DataMatrix[Row, Column - 1], out _))
        {
            rowSame[0] = true;
        }

        if (int.TryParse(DataMatrix[Row, Column + 1], out _))
        {
            rowSame[2] = true;
        }

        if (int.TryParse(DataMatrix[Row + 1, Column - 1], out _))
        {
            rowBelow[0] = true;
        }

        if (int.TryParse(DataMatrix[Row + 1, Column], out _))
        {
            rowBelow[1] = true;
        }

        if (int.TryParse(DataMatrix[Row + 1, Column + 1], out _))
        {
            rowBelow[2] = true;
        }
    }

    private void GetCompleteNumberStrings()
    {
        int separateNumbersAbove = 0;
        int numberToLeft = 0;
        int numberToRight = 0;
        int separateNumbersBelow = 0;
        if (!rowAbove[1])
        {
            if (rowAbove[0])
            {
                separateNumbersAbove++;
            }

            if (rowAbove[2])
            {
                separateNumbersAbove++;
            }
        }
        else if (rowAbove[0] || rowAbove[1] || rowAbove[2])
        {
            separateNumbersAbove++;
        }


        if (rowSame[0])
        {
            numberToLeft++;
        }

        if (rowSame[2])
        {
            numberToRight++;
        }

        if (!rowBelow[1])
        {
            if (rowBelow[0])
            {
                separateNumbersBelow++;
            }

            if (rowBelow[2])
            {
                separateNumbersBelow++;
            }
        }
        else if (rowBelow[0] || rowBelow[1] || rowBelow[2])
        {
            separateNumbersBelow++;
        }

        if (separateNumbersAbove + numberToLeft + numberToRight + separateNumbersBelow != 2)
        {
            return;
        }

        var bothNumbers =FindBothNumbers(separateNumbersAbove, numberToLeft, numberToRight, separateNumbersBelow);
        ProductOfNumbers = int.Parse(bothNumbers[0]) * int.Parse(bothNumbers[1]);
    }

    private List<string> FindBothNumbers(int separateNumbersAbove, int numberToLeft, int numberToRight,
        int separateNumbersBelow)
    {
        List<String> separateNumbers = new List<string>();

        if (separateNumbersAbove == 2)
        {
            string currentString = "";
            for (int i = Column - 1; i >= 0; i--)
            {
                if (int.TryParse(DataMatrix[Row - 1, i], out _))
                {
                    currentString = DataMatrix[Row - 1, i] + currentString;
                }
                else
                {
                    separateNumbers.Add(currentString);
                    currentString = "";
                    break;
                }
            }

            for (int i = Column + 1; i < DataMatrix.GetLength(1); i++)
            {
                if (int.TryParse(DataMatrix[Row - 1, i], out _))
                {
                    currentString += DataMatrix[Row - 1, i];
                }
                else
                {
                    separateNumbers.Add(currentString);
                    return separateNumbers;
                }
            }
        }
        else if (separateNumbersAbove == 1)
        {
            string foundNumber = "";
            if (int.TryParse(DataMatrix[Row - 1, Column - 1], out _))
            {
                foundNumber = FindNumber(Row - 1, Column - 1);
            }
            else if (int.TryParse(DataMatrix[Row - 1, Column], out _))
            {
                foundNumber = FindNumber(Row - 1, Column);

            }
            else
            {
                foundNumber = FindNumber(Row - 1, Column + 1);
            }
            separateNumbers.Add(foundNumber);
        }

        if (numberToLeft == 1)
        {
            string foundNumber = FindNumber(Row, Column - 1);
            
            separateNumbers.Add(foundNumber);
        }
        
        if (numberToRight == 1)
        {
            string foundNumber = FindNumber(Row, Column + 1);
            
           
            separateNumbers.Add(foundNumber);
        }
        
        if (separateNumbersBelow == 2)
        {
            string currentString = "";
            for (int i = Column - 1; i >= 0; i--)
            {
                if (int.TryParse(DataMatrix[Row + 1, i], out _))
                {
                    currentString = DataMatrix[Row + 1, i] + currentString;
                }
                else
                {
                    separateNumbers.Add(currentString);
                    currentString = "";
                    break;
                }
            }

            for (int i = Column + 1; i < DataMatrix.GetLength(1); i++)
            {
                if (int.TryParse(DataMatrix[Row + 1, i], out _))
                {
                    currentString += DataMatrix[Row + 1, i];
                }
                else
                {
                    separateNumbers.Add(currentString);
                    return separateNumbers;
                }
            }
        }
        else if (separateNumbersBelow == 1)
        {
            string foundNumber = "";
            if (int.TryParse(DataMatrix[Row + 1, Column - 1], out _))
            {
                foundNumber = FindNumber(Row + 1, Column - 1);
            }
            else if (int.TryParse(DataMatrix[Row + 1, Column], out _))
            {
                foundNumber = FindNumber(Row + 1, Column);

            }
            else
            {
                foundNumber = FindNumber(Row + 1, Column + 1);
            }
            separateNumbers.Add(foundNumber);
        }
        
        

        if (separateNumbers.Count == 2)
        {
            return separateNumbers;
        }

        return null;
    }

    private string FindNumber(int row, int column)
    {
        int startIndex = column;
        for (int i = column; i > 0; i--)
        {
            if (int.TryParse(DataMatrix[row, i], out _))
            {
                startIndex = i;
            }
            else
            {
                break;
            }
        }

        string str = "";

        for (int i = startIndex; i < DataMatrix.GetLength(1); i++)
        {
            if (int.TryParse(DataMatrix[row, i], out _))
            {
                str += DataMatrix[row, i];
            }
            else
            {
                break;
            }
        }

        return str;
    }
}