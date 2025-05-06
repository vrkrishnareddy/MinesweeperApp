public class GameBoard
{
    public int Size { get; }
    public Cell[,] Grid { get; }

    public GameBoard(int size)
    {
        Size = size;
        Grid = new Cell[size, size];
        for (int r = 0; r < size; r++)
            for (int c = 0; c < size; c++)
                Grid[r, c] = new Cell();
    }

    public bool IsInBounds(int r, int c) => r >= 0 && c >= 0 && r < Size && c < Size;
}