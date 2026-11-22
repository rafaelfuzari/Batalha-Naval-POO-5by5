using System.Security.Cryptography;

public class EnemyShip(Board board, int size) : Ship(board, size)
{
    public void PlaceShip()
    {
        bool positioned = false;

        while (positioned == false)
        {
            this.Line = RandomNumberGenerator.GetInt32(0, Board.Size);
            this.Column = RandomNumberGenerator.GetInt32(0, Board.Size);
            this.Direction = RandomNumberGenerator.GetInt32(1, 3);

            if (!CheckIfItGoesBeyondFromTheBorders() && CheckForOverlapOrContact())
            {
                AllocateTheShip();
                positioned = true;
            }
        }
    }
}
