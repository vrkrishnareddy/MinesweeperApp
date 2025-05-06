
# 🧨 Minesweeper Console App in C#

This is a C# console-based implementation of the classic **Minesweeper** game. It uses clean code principles, interfaces, and includes unit tests built with NUnit.

---

## 🎮 Game Features

- Customizable grid size and number of mines (max 35% of total cells)
- Random mine placement
- Auto-reveal of surrounding cells with 0 adjacent mines
- Text-based UI using coordinates like `A1`, `B3`, etc.
- Detect win/loss and restart
- SOLID, testable, production-ready design

---

## 🧰 Requirements

- OS: Windows (Console App)
- .NET SDK 8.0 or later
- Dependencies via NuGet:
  - `NUnit`
  - `NUnit3TestAdapter`
  - `Microsoft.NET.Test.Sdk`

---

## 📦 How to Run

1. **Restore and build**
   ```bash
   dotnet restore
   dotnet build
   ```

2. **Run the game**
   ```bash
   dotnet run --project MinesweeperApp
   ```

3. **Run unit tests**
   ```bash
   dotnet test
   ```

---

## 📁 Project Structure

```
MinesweeperApp/
│
├── MinesweeperApp.sln
│
├── MinesweeperApp/
│   ├── Program.cs
│   ├── Interfaces/
│   │   ├── IGame.cs
│   │   ├── IBoard.cs
│   │   └── ICell.cs
│   ├── Models/
│   │   ├── Game.cs
│   │   ├── Board.cs
│   │   └── Cell.cs
│   └── Helpers/
│       └── InputParser.cs
│
└── MinesweeperApp.Tests/
    ├── GameTests.cs
    ├── BoardTests.cs
    └── MinesweeperApp.Tests.csproj
```

---

## 🔧 Required NuGet Packages

Add these to your test project:

```bash
dotnet add package NUnit
dotnet add package NUnit3TestAdapter
dotnet add package Microsoft.NET.Test.Sdk
```

Or in `.csproj`:

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.10.0" />
  <PackageReference Include="NUnit" Version="3.14.1" />
  <PackageReference Include="NUnit3TestAdapter" Version="4.5.0" />
</ItemGroup>
```

---

## 🧪 Sample Gameplay

```
Enter the size of the grid (e.g. 4): 4
Enter the number of mines (max 35%): 3

  1 2 3 4
A _ _ _ _
B _ _ _ _
C _ _ _ _
D _ _ _ _

Select a square to reveal (e.g. A1): B2
This square contains 2 adjacent mines.
```

---

## 🧪 Sample Test (NUnit)

```csharp
[Test]
public void RevealMine_EndsGame()
{
    var board = new Board(3);
    var game = new Game(board);
    board.PlaceMine(0, 0);
    game.RevealCell("A1");
    Assert.IsTrue(game.IsGameOver);
}
```

---

## ✨ Design Notes

- Uses interfaces (`IGame`, `IBoard`, `ICell`) for dependency injection and testability
- Automatically uncovers 0-adjacent mine areas using BFS
- Coordinates are parsed with a helper (`InputParser`)
- Follows SRP, DIP, and test-driven development principles

---

## 📜 License

MIT License — Free to use and modify for educational or professional purposes.
