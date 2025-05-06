using System;
using System.Collections.Generic;

public class GameService : IGameService
{
    private GameBoard board;
    private int totalMines;
    private bool gameOver;
    private int revealedCells;

    public bool IsGameOver => gameOver;
    public bool IsGameWon => revealedCells == (board.Size * board.Size - totalMines) && !gameOver;

    public void Initialize(int size, int mineCount)
    {
        board = new GameBoard(size);
        totalMines = mineCount;
        revealedCells = 0;
        gameOver = false;
        PlaceMines();
        CalculateAdjacents();
    }

    private void PlaceMines()
    {
        Random rand = new();
        int placed = 0;
        while (placed < totalMines)
        {
            int r = rand.Next(board.Size);
            int c = rand.Next(board.Size);
            if (!board.Grid[r, c].IsMine)
            {
                board.Grid[r, c].IsMine = true;
                placed++;
            }
        }
    }

    private void CalculateAdjacents()
    {
        for (int r = 0; r < board.Size; r++)
        {
            for (int c = 0; c < board.Size; c++)
            {
                if (board.Grid[r, c].IsMine) continue;

                int count = 0;
                for (int dr = -1; dr <= 1; dr++)
                {
                    for (int dc = -1; dc <= 1; dc++)
                    {
                        int nr = r + dr, nc = c + dc;
                        if (board.IsInBounds(nr, nc) && board.Grid[nr, nc].IsMine)
                            count++;
                    }
                }
                board.Grid[r, c].AdjacentMines = count;
            }
        }
    }

    public void Reveal(string input)
    {
        var coord = Coordinate.FromInput(input);
        RevealRecursive(coord.Row, coord.Col);
    }

    private void RevealRecursive(int r, int c)
    {
        if (!board.IsInBounds(r, c) || board.Grid[r, c].IsRevealed)
            return;

        var cell = board.Grid[r, c];
        cell.IsRevealed = true;

        if (cell.IsMine)
        {
            gameOver = true;
            return;
        }

        revealedCells++;

        if (cell.AdjacentMines == 0)
        {
            for (int dr = -1; dr <= 1; dr++)
                for (int dc = -1; dc <= 1; dc++)
                    RevealRecursive(r + dr, c + dc);
        }
    }

    public string GetBoardDisplay()
    {
        var display = "  ";
        for (int i = 1; i <= board.Size; i++) display += i + " ";
        display += "\n";

        for (int r = 0; r < board.Size; r++)
        {
            display += (char)('A' + r) + " ";
            for (int c = 0; c < board.Size; c++)
            {
                var cell = board.Grid[r, c];
                if (!cell.IsRevealed)
                    display += "_ ";
                else if (cell.IsMine)
                    display += "* ";
                else
                    display += cell.AdjacentMines + " ";
            }
            display += "\n";
        }

        return display;
    }
}