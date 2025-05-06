/// <summary>
/// Represents a single cell in the Minesweeper grid.
/// </summary>
public class Cell
{
    public bool IsMine { get; set; }
    public bool IsRevealed { get; set; }
    public int AdjacentMines { get; set; }
}