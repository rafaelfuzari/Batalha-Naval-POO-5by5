public class MyShip(Board board, int size) : Ship(board, size)
{
    public bool PlaceShip()
    {
        bool validDirection = !CheckIfItGoesBeyondFromTheBorders();

        if (validDirection == false)
        {
            Console.WriteLine("\n\tNão é possível posicionar o navio nessa posição e ângulo pois o navio está parcialmente fora do tabuleiro. \n\tTente novamente.");
            Thread.Sleep(3500);
            return false;
        }

        bool thereIsNoOverlapOrContact = CheckForOverlapOrContact();

        if (thereIsNoOverlapOrContact == false)
        {
            Console.WriteLine("\n\tNão é possível posicionar o navio nessa posição por sobreposição ou contato de navios. Tente novamente.");
            Thread.Sleep(3000);
            return false;
        }

        AllocateTheShip();
        return true;
    }
}
