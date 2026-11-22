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
}