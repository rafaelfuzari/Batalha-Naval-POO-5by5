Board MyBoard = new Board();
Board EnemyBoard = new Board();

MyShip AllyCarrier = new MyShip(MyBoard, 5);
MyShip AllyBattleship = new MyShip(MyBoard, 4);
MyShip AllyCruiser = new MyShip(MyBoard, 3);
MyShip AllySubmarine = new MyShip(MyBoard, 3);
MyShip AllyDestroyer = new MyShip(MyBoard, 2);

EnemyShip EnemyCarrier = new EnemyShip(EnemyBoard, 5);
EnemyShip EnemyBattleship = new EnemyShip(EnemyBoard, 4);
EnemyShip EnemyCruiser = new EnemyShip(EnemyBoard, 3);
EnemyShip EnemySubmarine = new EnemyShip(EnemyBoard, 3);
EnemyShip EnemyDestroyer = new EnemyShip(EnemyBoard, 2);


while (true)
{
menu:
    int escolha = 100;

    Console.Clear();

    Console.WriteLine("\t------------Bem vindo à Batalha Naval------------\n\n");
    Console.Write("\t\tDigite o numero da opção desejada:\n\t\t" +
        "1 - Jogar\n\t\t" +
        "2 - Como jogar\n\t\t" +
        "0 - Sair\n\t\t");

    escolha = int.Parse(Console.ReadLine());

    switch (escolha)
    {
        case 1:
            int shipCount = 0;
            Console.Write("\t\tEsse é o seu tabuleiro: \n\n");
            MyBoard.ShowBoard();
            Console.WriteLine("Qual Linha deseja por o barco?");

            Console.ReadLine();
            break;
        case 2:
            Console.Clear();
            //tutorial do jogo
            Console.WriteLine("\t-------------------------------------------------");
            Console.WriteLine("\n\t\tO jogo segue as regras padrões\n\t\t" +
                "\n\t\t-Cada jogador possui 5 navios de tamanhos diferentes;" +
                "\n\t\t-O objetivo é destruir os navios do adversário antes que ele faça o mesmo com os seus;" +
                "\n\t\t-Para destruir os navios basta escolher a ação de atirar e escolher as coordenadas;" +
                "\n\t\t-Se não acertar nada, a casa será marcada com um '2', e será a vez do seu adversário atirar;" +
                "\n\t\t-Se acertar uma parte de navio, a casa será marcada com um '3' e você podera atirar novamente;" +
                "\n\t\t-Ao destruir todos os navios do adversário, você ganha o jogo!" +
                "\n\n\t\t Dê ENTER para voltar ao menu principal");
            Console.ReadLine();
            Console.Clear();
            goto menu;
            
        case 0:
            Console.WriteLine("\n\t\t Obrigado por Jogar!");
            break;

    }
}

