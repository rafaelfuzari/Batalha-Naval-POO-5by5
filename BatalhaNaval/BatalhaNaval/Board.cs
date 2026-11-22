public class Board
{
    public static int Size { get; set; } = 10;
    public int[,] Positions { get; set; } = new int[Size, Size];

    public Board()
    {
        for (int line = 0; line < Size; line++)
        {
            for (int column = 0; column < Size; column++)
            {
                this.Positions[line, column] = 0;
            }
        }
    }

    public void ShowBoard()
    {
        Console.WriteLine("\t  | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |");
        Console.WriteLine("\t-------------------------------------------");
        Console.WriteLine();

        string[] fillOptions = new string[] { " O |", " 1 |", " 2 |", " 3 |" };
        int coordinateStatus;

        for (int line = 0; line < 10; line++)
        {
            Console.Write($"\t{line} |");
            for (int column = 0; column < 10; column++)
            {
                coordinateStatus = this.Positions[line, column];

                Console.Write(fillOptions[coordinateStatus]);

            }

            Console.WriteLine("-------------------------------------------");
        }

    }
}