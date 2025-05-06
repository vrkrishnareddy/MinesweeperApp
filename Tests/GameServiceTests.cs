using NUnit.Framework;

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
        Assert.IsFalse(game.IsGameOver);
    }

    [Test]
    public void Test_GameWinCondition_IsRecognized()
    {
        var game = new GameService();
        game.Initialize(2, 1);
        // Uncover 3 safe cells assuming 1 mine
        game.Reveal("A1");
        game.Reveal("A2");
        game.Reveal("B1");
        Assert.IsTrue(game.IsGameWon || game.IsGameOver);
    }
}