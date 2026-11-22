public class MyShip(Board board, int size) : Ship(board, size)
{

    public bool PlaceShip()
    {
        bool validDirection = !CheckIfItGoesBeyondFromTheBorders();

        if (validDirection == false)
        {
            Console.WriteLine("\nNão é possível posicionar o navio nessa posição e ângulo pois o navio está parcialmente fora do tabuleiro. Tente novamente.");

            return false;
        }

        bool thereIsNoOverlapOrContact = CheckForOverlapOrContact();

        if (thereIsNoOverlapOrContact == false)
        {
            Console.WriteLine("\nNão é possível posicionar o navio nessa posição por sobreposição ou contato de navios. Tente novamente.");

            return false;
        }

        AllocateTheShip();
        return true;
    }

}