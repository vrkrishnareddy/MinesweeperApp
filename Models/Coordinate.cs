public class Coordinate
{
    public int Row { get; }
    public int Col { get; }

    public Coordinate(int row, int col)
    {
        Row = row;
        Col = col;
    }

    public static Coordinate FromInput(string input)
    {
        int row = input.ToUpper()[0] - 'A';
        int col = int.Parse(input.Substring(1)) - 1;
        return new Coordinate(row, col);
    }
}