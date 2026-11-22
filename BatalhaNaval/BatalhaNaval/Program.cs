Board MyBoard = new Board();
Board EnemyBoard = new Board();
GameManager GM = new GameManager();

bool DebugMode = false; // Altere para true para enxergar o tabuleiro inimigo durante testes

int ReadValidInt(string message, int min, int max)
{
    int value;
    while (true)
    {
        Console.Write(message);
        if (int.TryParse(Console.ReadLine(), out value) && value >= min && value <= max)
        {
            return value;
        }
        Console.WriteLine($"\tVocê digitou uma opção inválida (digite entre {min} e {max}), vamos de novo!");
    }
}

void PlacePlayerShip(MyShip ship, string shipName)
{
    while (true)
    {
        Console.Clear();
        Console.Write("\t\tEsse é o seu tabuleiro: \n\n");
        MyBoard.ShowBoard();
        Console.WriteLine($"\n\tVocê vai posicionar o {shipName}, ele tem {ship.Size} espaços de tamanho!");

        ship.Direction = ReadValidInt("\tPrimeiro digite a direção que deseja posicioná-lo, 1 para vertical e 2 para horizontal: ", 1, 2);
        ship.Line = ReadValidInt("\tDigite a linha que deseja posicioná-lo, entre 0 e 9: ", 0, 9);
        ship.Column = ReadValidInt("\tDigite a coluna que deseja posicioná-lo, entre 0 e 9: ", 0, 9);

        Console.Clear();
        if (ship.PlaceShip()) break;
    }
}

bool running = true;

while (running)
{
    Console.Clear();
    Console.WriteLine("\t------------Bem vindo à Batalha Naval------------\n\n");
    Console.WriteLine("\t\tDigite o numero da opção desejada:");
    Console.WriteLine("\t\t1 - Jogar");
    Console.WriteLine("\t\t2 - Como jogar");
    Console.WriteLine("\t\t0 - Sair\n");

    int escolha = ReadValidInt("\t\tOpção: ", 0, 2);

    switch (escolha)
    {
        case 1:
            MyBoard.ResetBoard();
            EnemyBoard.ResetBoard();
            GM.ResetStats();

            PlacePlayerShip(new MyShip(MyBoard, 5), "porta-aviões");
            PlacePlayerShip(new MyShip(MyBoard, 4), "encouraçado");
            PlacePlayerShip(new MyShip(MyBoard, 3), "cruzador");
            PlacePlayerShip(new MyShip(MyBoard, 3), "submarino");
            PlacePlayerShip(new MyShip(MyBoard, 2), "contratorpedeiro");

            Console.Clear();

            new EnemyShip(EnemyBoard, 5).PlaceShip();
            new EnemyShip(EnemyBoard, 4).PlaceShip();
            new EnemyShip(EnemyBoard, 3).PlaceShip();
            new EnemyShip(EnemyBoard, 3).PlaceShip();
            new EnemyShip(EnemyBoard, 2).PlaceShip();

            bool matchOver = false;

            while (!matchOver)
            {
                bool playerTurn = true;

                while (playerTurn && !matchOver)
                {
                    Console.Clear();
                    Console.WriteLine($"\t[Tiros] Você: {GM.PlayerShots} (Acertos: {GM.PlayerHits}) | Computador: {GM.ComputerShots} (Acertos: {GM.ComputerHits})\n");
                    Console.WriteLine("\t\t\t--Jogador--");
                    MyBoard.ShowBoard(false);
                    Console.WriteLine("\n\t\t\t--Computador--");
                    EnemyBoard.ShowBoard(!DebugMode);

                    Console.WriteLine("\n\tSua vez!");
                    int LineAim = ReadValidInt("\tEscolha a linha para atirar (0 a 9): ", 0, 9);
                    int ColumnAim = ReadValidInt("\tEscolha a coluna para atirar (0 a 9): ", 0, 9);

                    int shotResult = GM.Shoot(EnemyBoard, LineAim, ColumnAim);

                    if (GM.CheckLose(EnemyBoard))
                    {
                        Console.Clear();
                        Console.WriteLine("\t\tPARABÉNS!!!!\n\tVocê ganhou! E é só isso mesmo :)");
                        Console.WriteLine($"\tResumo da partida: {GM.PlayerShots} tiros dados | {GM.PlayerHits} acertos.");
                        Console.Write("\n\tPressione ENTER para voltar ao menu principal!");
                        Console.ReadLine();
                        matchOver = true;
                    }
                    else if (shotResult == 0)
                    {
                        playerTurn = false;
                    }
                }

                if (!matchOver)
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\t--Jogador--");
                    MyBoard.ShowBoard(false);
                    Console.WriteLine("\n\t\t\t--Computador--");
                    EnemyBoard.ShowBoard(!DebugMode);
                    Console.WriteLine("\n\tO computador irá atirar, cuidado!");
                    Thread.Sleep(1000);

                    GM.ComputerShoot(MyBoard);

                    if (GM.CheckLose(MyBoard))
                    {
                        Console.Clear();
                        Console.WriteLine("\n\tQue pena, você perdeu!");
                        Console.WriteLine($"\tResumo da partida: {GM.PlayerShots} tiros dados | {GM.PlayerHits} acertos.");
                        Console.Write("\n\tPressione ENTER para voltar ao menu principal!");
                        Console.ReadLine();
                        matchOver = true;
                    }
                }
            }
            break;

        case 2:
            Console.Clear();
            Console.WriteLine("\t-------------------------------------------------");
            Console.WriteLine("\n\t\tO jogo segue as regras padrões\n\t\t" +
                "\n\t\t-Cada jogador possui 5 navios de tamanhos diferentes;" +
                "\n\t\t-O objetivo é destruir os navios do adversário antes que ele faça o mesmo com os seus;" +
                "\n\t\t-Para destruir os navios basta escolher a ação de atirar e escolher as coordenadas;" +
                "\n\t\t-Se não acertar nada, a casa será marcada com um '3', e será a vez do seu adversário atirar;" +
                "\n\t\t-Se acertar uma parte de navio, a casa será marcada com um '2' e você podera atirar novamente;" +
                "\n\t\t-Ao destruir todos os navios do adversário, você ganha o jogo!" +
                "\n\n\t\t Dê ENTER para voltar ao menu principal");
            Console.ReadLine();
            break;

        case 0:
            Console.WriteLine("\n\t\t Obrigado por Jogar!");
            running = false;
            break;
    }
}
