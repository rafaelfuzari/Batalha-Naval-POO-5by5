public class GameManager()
{

    public bool CheckLose(Board board)
    {
        int count = 0;
        for(int l = 0; l < 10 ; l++)
        {
            for (int c = 0; c < 10; c++)
            {
                if (board.Positions[l, c] == 1) count++;
            }
        }

        if (count == 0) return true;
        return false;
    }
    
    //função de tiro, ela retorna um int porque preciso saber se vai atirar de novo, 1 vai atirar de novo e 0 não vai
    public int Shoot(Board board, int line, int column)
    {
        
        if (board.Positions[line, column] == 1) //checa se na posição alvo tem um barco
        {
            Console.WriteLine($"Tiro certeiro em [{line}, {column}]! Irá atirar novamente!(aguarde)");
            board.Positions[line, column] = 2;
            Thread.Sleep(2000);
            return 1;
        } if (board.Positions[line, column] == 0)//checar se é vazio(agua)
        {
            Console.WriteLine($"Tiro errado em [{line}, {column}]! Passando a vez(aguarde)");
            Thread.Sleep(2000);
            board.Positions[line, column] = 3;
            return 0;
        }
        if (board.Positions[line, column] == 2 || board.Positions[line, column] == 3) //checa se já atirou nessa posição, e atira de novo
        {
            Console.WriteLine($"Você já atirou aqui em [{line}, {column}]! Atire de novo!(aguarde)");
            Thread.Sleep(2000);
            return 1;   
        }
        return 0;
    }

    public void ComputerShoot(Board board) 
    {

        int lineAim = Random.Shared.Next(0, 10);
        int colunmAim = Random.Shared.Next(0, 10);

        //reiniciando a posição até que mire em um espaço vazio ou com um navio
        while (board.Positions[lineAim, colunmAim] != 0 && board.Positions[lineAim, colunmAim] != 1)
        {
            lineAim = Random.Shared.Next(0, 10);
            colunmAim = Random.Shared.Next(0, 10);
        }

        if (board.Positions[lineAim, colunmAim] == 0) //checando se a posição é vazia
        {
            Console.WriteLine($"\n\t O computador errou o tiro em [{lineAim}, {colunmAim}]! Sua vez!(aguarde)");
            board.Positions[lineAim, colunmAim] = 3;
            Thread.Sleep(2000);
        }

        if (board.Positions[lineAim, colunmAim] == 1)//checando se tem um barco na posição
        {
            Console.WriteLine($"\n\t O computador te acertou em [{lineAim}, {colunmAim}]! E irá atirar de novo!");
            board.Positions[lineAim, colunmAim] = 2;
            Thread.Sleep(1000);
            ComputerShoot(board);
        }
    }
}