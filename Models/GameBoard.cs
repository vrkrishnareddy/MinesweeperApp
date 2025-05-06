/// <summary>
/// Represents the game board grid.
/// </summary>
public class GameBoard
{
    public int Size { get; }
    public Cell[,] Grid { get; }

    public GameBoard(int size)
    {
        Size = size;
        Grid = new Cell[size, size];
        for (int row = 0; row < size; row++)
            for (int col = 0; col < size; col++)
                Grid[row, col] = new Cell();
    }

    public bool IsInBounds(int row, int col) => row >= 0 && col >= 0 && row < Size && col < Size;
}