Board MyBoard = new Board();
Board EnemyBoard = new Board();

GameManager GM = new GameManager();

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

bool DebugMode = true; //altere para false para ocultar o tabuleiro inimigo

while (true)
{
menu:
    int escolha = 0; //variavel pra controlar a escolha do usuário

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
            Console.Clear();
            int aux = 0;
            int shipCount = 0;


            //Essa parte ficou MUITO grande e leva até a linha 225, são muitos textos pois usei um para cada navio
            //é basicamente a construção de cada um deles
            //Colocando o porta aviões
        PlaceCarrier:
            Console.Clear();
            Console.Write("\t\tEsse é o seu tabuleiro: \n\n");
            MyBoard.ShowBoard();
            Console.WriteLine("\tVocê vai posicionar o porta-aviões, ele tem 5 espaços de tamanho!");
            Console.Write("\tPrimeiro digite a direção que deseja posiciona-lo, 1 para vertical e 2 para horizontal: ");
            aux = int.Parse(Console.ReadLine());
            if (aux != 1 && aux != 2)
            {
                Console.WriteLine("\tVocê digitou uma opção inválida, vamos de novo");
                Thread.Sleep(3000);
                goto PlaceCarrier;
            }
            AllyCarrier.Direction = aux;
            Console.Write("\tDigite a linha que deseja posicioná-lo, entre 0 e 9: ");
            aux = int.Parse(Console.ReadLine());
            if (aux < 0 || aux > 9)
            {
                Console.WriteLine("\tVocê digitou uma opção inválida, vamos de novo");
                Thread.Sleep(3000);
                goto PlaceCarrier;
            }
            AllyCarrier.Line = aux;

            Console.Write("\tDigite a coluna que deseja posicioná-lo, entre 0 e 9: ");
            aux = int.Parse(Console.ReadLine());
            if (aux < 0 || aux > 9)
            {
                Console.WriteLine("\tVocê digitou uma opção inválida, vamos de novo");
                Thread.Sleep(3000);
                goto PlaceCarrier;
            }
            AllyCarrier.Column = aux;

            Console.Clear();

            if (!AllyCarrier.PlaceShip()) goto PlaceCarrier;

            
            
            //Colocando o encouraçado
        PlaceBattleship:
            Console.Clear();
            Console.Write("\t\tEsse é o seu tabuleiro: \n\n");
            MyBoard.ShowBoard();
            Console.WriteLine("\tVocê vai posicionar o encouraçado, ele tem 4 espaços de tamanho!");
            Console.Write("\tPrimeiro digite a direção que deseja posiciona-lo, 1 para vertical e 2 para horizontal: ");
            aux = int.Parse(Console.ReadLine());
            if (aux != 1 && aux != 2)
            {
                Console.WriteLine("\tVocê digitou uma opção inválida, vamos de novo");
                Thread.Sleep(3000);
                goto PlaceBattleship;
            }
            AllyBattleship.Direction = aux;
            Console.Write("\tDigite a linha que deseja posicioná-lo, entre 0 e 9: ");
            aux = int.Parse(Console.ReadLine());
            if (aux < 0 || aux > 9)
            {
                Console.WriteLine("\tVocê digitou uma opção inválida, vamos de novo");
                Thread.Sleep(3000);
                goto PlaceBattleship;
            }
            AllyBattleship.Line = aux;

            Console.Write("\tDigite a coluna que deseja posicioná-lo, entre 0 e 9: ");
            aux = int.Parse(Console.ReadLine());
            if (aux < 0 || aux > 9)
            {
                Console.WriteLine("\tVocê digitou uma opção inválida, vamos de novo");
                Thread.Sleep(3000);
                goto PlaceBattleship;
            }
            AllyBattleship.Column = aux;

            Console.Clear();

            if (!AllyBattleship.PlaceShip()) goto PlaceBattleship;
            

            //Colocando o cruzador
        PlaceCruiser:
            Console.Clear();
            Console.Write("\t\tEsse é o seu tabuleiro: \n\n");
            MyBoard.ShowBoard();
            Console.WriteLine("\tVocê vai posicionar o cruzador, ele tem 3 espaços de tamanho!");
            Console.Write("\tPrimeiro digite a direção que deseja posiciona-lo, 1 para vertical e 2 para horizontal: ");
            aux = int.Parse(Console.ReadLine());
            if (aux != 1 && aux != 2)
            {
                Console.WriteLine("\tVocê digitou uma opção inválida, vamos de novo");
                Thread.Sleep(3000);
                goto PlaceCruiser;
            }
            AllyCruiser.Direction = aux;

            Console.Write("\tDigite a linha que deseja posicioná-lo, entre 0 e 9: ");
            aux = int.Parse(Console.ReadLine());
            if (aux < 0 || aux > 9)
            {
                Console.WriteLine("\tVocê digitou uma opção inválida, vamos de novo");
                Thread.Sleep(3000);
                goto PlaceCruiser;
            }
            AllyCruiser.Line = aux;

            Console.Write("\tDigite a coluna que deseja posicioná-lo, entre 0 e 9: ");
            aux = int.Parse(Console.ReadLine());
            if (aux < 0 || aux > 9)
            {
                Console.WriteLine("\tVocê digitou uma opção inválida, vamos de novo");
                Thread.Sleep(3000);
                goto PlaceCruiser;
            }
            AllyCruiser.Column = aux;

            Console.Clear();

            if (!AllyCruiser.PlaceShip()) goto PlaceCruiser;
            
            //colocando o submarino
        PlaceSubmarine:
            Console.Clear();
            Console.Write("\t\tEsse é o seu tabuleiro: \n\n");
            MyBoard.ShowBoard();
            Console.WriteLine("\tVocê vai posicionar o submarino, ele tem 3 espaços de tamanho!");
            Console.Write("\tPrimeiro digite a direção que deseja posiciona-lo, 1 para vertical e 2 para horizontal: ");
            aux = int.Parse(Console.ReadLine());
            if (aux != 1 && aux != 2)
            {
                Console.WriteLine("\tVocê digitou uma opção inválida, vamos de novo");
                Thread.Sleep(3000);
                goto PlaceSubmarine;
            }
            AllySubmarine.Direction = aux;

            Console.Write("\tDigite a linha que deseja posicioná-lo, entre 0 e 9: ");
            aux = int.Parse(Console.ReadLine());
            if (aux < 0 || aux > 9)
            {
                Console.WriteLine("\tVocê digitou uma opção inválida, vamos de novo");
                Thread.Sleep(3000);
                goto PlaceSubmarine;
            }
            AllySubmarine.Line = aux;

            Console.Write("\tDigite a coluna que deseja posicioná-lo, entre 0 e 9: ");
            aux = int.Parse(Console.ReadLine());
            if (aux < 0 || aux > 9)
            {
                Console.WriteLine("\tVocê digitou uma opção inválida, vamos de novo");
                Thread.Sleep(3000);
                goto PlaceSubmarine;
            }
            AllySubmarine.Column = aux;

            Console.Clear();

            if (!AllySubmarine.PlaceShip()) goto PlaceSubmarine;

            //colocando o contratorpedeiro
        PlaceDestroyer:
            Console.Clear();
            Console.Write("\t\tEsse é o seu tabuleiro: \n\n");
            MyBoard.ShowBoard();
            Console.WriteLine("\tVocê vai posicionar o contratorpedeiro, ele tem 2 espaços de tamanho!");
            Console.Write("\tPrimeiro digite a direção que deseja posiciona-lo, 1 para vertical e 2 para horizontal: ");
            aux = int.Parse(Console.ReadLine());
            if (aux != 1 && aux != 2)
            {
                Console.WriteLine("\tVocê digitou uma opção inválida, vamos de novo");
                Thread.Sleep(3000);
                goto PlaceDestroyer;
            }
            AllyDestroyer.Direction = aux;

            Console.Write("\tDigite a linha que deseja posicioná-lo, entre 0 e 9: ");
            aux = int.Parse(Console.ReadLine());
            if (aux < 0 || aux > 9)
            {
                Console.WriteLine("\tVocê digitou uma opção inválida, vamos de novo");
                Thread.Sleep(3000);
                goto PlaceDestroyer;
            }
            AllyDestroyer.Line = aux;

            Console.Write("\tDigite a coluna que deseja posicioná-lo, entre 0 e 9: ");
            aux = int.Parse(Console.ReadLine());
            if (aux < 0 || aux > 9)
            {
                Console.WriteLine("\tVocê digitou uma opção inválida, vamos de novo");
                Thread.Sleep(3000);
                goto PlaceDestroyer;
            }
            AllyDestroyer.Column = aux;

            Console.Clear();

            if (!AllyDestroyer.PlaceShip()) goto PlaceDestroyer;

            //Todos os navios posicionados

            Console.Clear();
            //Posicionando navios inimigos
            EnemyCarrier.PlaceShip();
            EnemyBattleship.PlaceShip();  
            EnemyCruiser.PlaceShip();
            EnemySubmarine.PlaceShip(); 
            EnemyDestroyer.PlaceShip();


            //Fase de tiros
        PlayerTurn:
            Console.Clear();
            int LineAim = 0;
            int ColumnAim = 0;
            Console.WriteLine("\t\t\t--Jogador--");
            MyBoard.ShowBoard();
            Console.WriteLine("\n\t\t\t--Computador--");
            EnemyBoard.ShowBoard(DebugMode);

            Console.Write("\t\nSua vez! Escolha a linha para atirar: ");
            aux = int.Parse(Console.ReadLine());
            if (aux < 0 || aux > 9)
            {
                Console.WriteLine("\tCoordenada errada! Vamos de novo(aguarde)");
                Thread.Sleep(3000);
                goto PlayerTurn;
            }
            LineAim = aux;

            Console.Write("\t\nEscolha a coluna para atirar: ");
            aux = int.Parse(Console.ReadLine());
            if (aux < 0 || aux > 9)
            {
                Console.WriteLine("\tCoordenada errada! Vamos de novo(aguarde)");
                Thread.Sleep(3000);
                goto PlayerTurn;
            }
            ColumnAim = aux;

            if (GM.Shoot(EnemyBoard, LineAim, ColumnAim) == 1)
            {
                goto PlayerTurn;
            }
            if (GM.CheckLose(EnemyBoard))
            {
                
                Console.WriteLine("\t\tPARABÉNS!!!!\n\tVocê ganhou! E é só isso mesmo :)\n\tPressione ENTER para voltar ao menu principal!");
                goto menu;
            }

        
            Console.Clear();
            Console.WriteLine("\t\t\t--Jogador--");
            MyBoard.ShowBoard();
            Console.WriteLine("\n\t\t\t--Computador--");
            EnemyBoard.ShowBoard(DebugMode);
            Console.WriteLine("\t O computador irá atirar, cuidado!");
            Thread.Sleep(500);
            GM.ComputerShoot(MyBoard);
            if (GM.CheckLose(MyBoard))
            {
                Console.WriteLine("\n\tQue pena,você perdeu!\n\tPressione ENTER para voltar ao menu principal!");
                goto menu;
            }
            goto PlayerTurn;




            
            break;
        case 2:
            Console.Clear();
            //tutorial do jogo
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
            Console.Clear();
            goto menu;

        case 0:
            Console.WriteLine("\n\t\t Obrigado por Jogar!");
            break;
    }

}

