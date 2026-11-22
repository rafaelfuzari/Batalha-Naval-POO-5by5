public class GameManager
{
    public int PlayerShots { get; private set; } = 0;
    public int PlayerHits { get; private set; } = 0;
    public int ComputerShots { get; private set; } = 0;
    public int ComputerHits { get; private set; } = 0;

    public void ResetStats()
    {
        PlayerShots = 0;
        PlayerHits = 0;
        ComputerShots = 0;
        ComputerHits = 0;
    }

    public bool CheckLose(Board board)
    {
        int count = 0;
        for (int l = 0; l < Board.Size; l++)
        {
            for (int c = 0; c < Board.Size; c++)
            {
                if (board.Positions[l, c] == 1) count++;
            }
        }

        return count == 0;
    }

    // Retorna 1 para atirar de novo e 0 para passar a vez
    public int Shoot(Board board, int line, int column)
    {
        if (line < 0 || line >= Board.Size || column < 0 || column >= Board.Size)
        {
            Console.WriteLine("\tCoordenada fora do tabuleiro! Tente novamente.");
            Thread.Sleep(1500);
            return 1;
        }

        if (board.Positions[line, column] == 2 || board.Positions[line, column] == 3)
        {
            Console.WriteLine($"\tVocê já atirou aqui em [{line}, {column}]! Atire de novo! (aguarde)");
            Thread.Sleep(1500);
            return 1;
        }

        PlayerShots++;

        if (board.Positions[line, column] == 1)
        {
            PlayerHits++;
            Console.WriteLine($"\tTiro certeiro em [{line}, {column}]! Irá atirar novamente! (aguarde)");
            board.Positions[line, column] = 2;
            Thread.Sleep(1500);
            return 1;
        }
        else
        {
            Console.WriteLine($"\tTiro errado em [{line}, {column}]! Passando a vez (aguarde)");
            board.Positions[line, column] = 3;
            Thread.Sleep(1500);
            return 0;
        }
    }

    public void ComputerShoot(Board board)
    {
        bool keepShooting = true;

        while (keepShooting && !CheckLose(board))
        {
            int lineAim = Random.Shared.Next(0, Board.Size);
            int columnAim = Random.Shared.Next(0, Board.Size);

            while (board.Positions[lineAim, columnAim] != 0 && board.Positions[lineAim, columnAim] != 1)
            {
                lineAim = Random.Shared.Next(0, Board.Size);
                columnAim = Random.Shared.Next(0, Board.Size);
            }

            ComputerShots++;

            if (board.Positions[lineAim, columnAim] == 0)
            {
                Console.WriteLine($"\n\tO computador errou o tiro em [{lineAim}, {columnAim}]! Sua vez! (aguarde)");
                board.Positions[lineAim, columnAim] = 3;
                Thread.Sleep(1500);
                keepShooting = false;
            }
            else if (board.Positions[lineAim, columnAim] == 1)
            {
                ComputerHits++;
                Console.WriteLine($"\n\tO computador te acertou em [{lineAim}, {columnAim}]! E irá atirar de novo!");
                board.Positions[lineAim, columnAim] = 2;
                Thread.Sleep(1000);
            }
        }
    }
}
