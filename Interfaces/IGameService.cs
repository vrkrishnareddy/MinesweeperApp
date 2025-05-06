/// <summary>
/// Interface defining the contract for the Minesweeper game logic.
/// </summary>
public interface IGameService
{
    void Initialize(int size, int mineCount);
    void Reveal(string input);
    bool IsGameOver { get; }
    bool IsGameWon { get; }
    string GetBoardDisplay();
}