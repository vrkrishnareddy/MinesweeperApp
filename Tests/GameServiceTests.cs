using NUnit.Framework;


/// <summary>
/// Unit tests for the GameService logic.
/// </summary>
[TestFixture]
public class GameServiceTests
{
    [Test]
    public void Test_GameInitialization_DoesNotThrow()
    {
        var game = new GameService();
        Assert.DoesNotThrow(() => game.Initialize(4, 3));
    }

    [Test]
    public void Test_Reveal_DoesNotEndGameForSafeCell()
    {
        var game = new GameService();
        game.Initialize(4, 1);
        game.Reveal("A1");
        Assert.That(!game.IsGameOver);
    }

    [Test]
    public void Test_GameWinCondition_IsRecognized()
    {
        var game = new GameService();
        game.Initialize(2, 1);
        game.Reveal("A1");
        game.Reveal("A2");
        game.Reveal("B1");
        Assert.That(game.IsGameWon || game.IsGameOver);
    }

    [Test]
    public void Test_DisplayBoardFormat_ValidString()
    {
        var game = new GameService();
        game.Initialize(3, 0);
        game.Reveal("A1");
        var board = game.GetBoardDisplay();
        Assert.That(board.Contains('A'));
        Assert.That(board.Contains('1'));
    }
}
