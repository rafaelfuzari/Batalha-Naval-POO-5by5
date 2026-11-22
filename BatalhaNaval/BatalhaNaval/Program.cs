Board MyBoard = new Board();
Board EnemyBoard = new Board();

MyShip ship = new MyShip(MyBoard, 5);
ship.PlaceShip();


for (int i = 0; i < 10; i++) { 

    Console.WriteLine();
    for (int j = 0; j < 10; j++)
    {
        Console.Write(MyBoard.Positions[i, j]);
    }
}