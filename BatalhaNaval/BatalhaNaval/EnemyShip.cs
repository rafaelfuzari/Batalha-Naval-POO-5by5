using System.Security.Cryptography;

public class EnemyShip(Board board, int size) : Ship(board, size)
{

    public void GeneratesDirectionThatDoesntPassFromtheBorders()
    {
        bool validDirection = false;

        while (validDirection == false)
        {
            this.Direction = RandomNumberGenerator.GetInt32(1, 2);
            validDirection = !CheckIfItGoesBeyondFromTheBorders();
        }
    }

    public void PlaceShip()
    {
        bool positioned = false;

        while (positioned == false)
        {
            this.Line = RandomNumberGenerator.GetInt32(0, this.BoardBounds);
            this.Column = RandomNumberGenerator.GetInt32(0, this.BoardBounds);

            bool thereIsNoOverlapOrContact = false;

            GeneratesDirectionThatDoesntPassFromtheBorders();

            int AttemptToChangePosition = 0;

            while (thereIsNoOverlapOrContact == false)
            {

                if (AttemptToChangePosition == 4)
                {
                    break;
                }
                else
                {
                    thereIsNoOverlapOrContact = CheckForOverlapOrContact();
                    if (thereIsNoOverlapOrContact == false) GeneratesDirectionThatDoesntPassFromtheBorders();
                    AttemptToChangePosition++;
                }
            }

            if (thereIsNoOverlapOrContact)
            {
                AllocateTheShip();
                positioned = true;
            }

        }

    }

}