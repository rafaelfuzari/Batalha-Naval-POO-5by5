using System.Security.Cryptography;

public class Ship(Board board, int size)
{
    public int BoardBounds = Board.Size - 1;
    public Board OwnerBoard = board;
    public int Size { get; set; } = size;
    public int Line { get; set; } 
    public int Column { get; set; }
    public int Direction { get; set; }

    public bool CheckIfItGoesBeyondFromTheBorders()
    {
        return (this.Direction == 1 && (this.Line + 1) - this.Size < 0) || (this.Direction == 2 && (this.Column - 1) + this.Size > this.BoardBounds);
    }

    public bool CheckForOverlapOrContact()
    {
        bool thereIsNoOverlapOrContact = true;

        int lineVariation = this.Size;
        int ColumnVariation = this.Size;

        if (this.Direction == 1) ColumnVariation = 1;
        else if (this.Direction == 2) lineVariation = 1;

        for (int l = this.Line + 1; l > (this.Line - lineVariation) - 1; l--)
        {
            if (l < 0 || l > this.BoardBounds) continue;

            for (int c = this.Column - 1; c < (this.Column + ColumnVariation) + 1; c++)
            {
                if (c < 0 || c > this.BoardBounds) continue;
                if (OwnerBoard.Positions[l, c] == 1) thereIsNoOverlapOrContact = false;
            }
        }

        return thereIsNoOverlapOrContact;
    }

    public void AllocateTheShip()
    {
        int lineVariation = this.Size;
        int ColumnVariation = this.Size;

        if (this.Direction == 1) ColumnVariation = 1;
        else if (this.Direction == 2) lineVariation = 1;

        for (int l = this.Line; l > (this.Line - lineVariation); l--)
        {
            for (int c = this.Column; c < (this.Column + ColumnVariation); c++)
            {
                OwnerBoard.Positions[l, c] = 1;
            }
        }
    }

    
}