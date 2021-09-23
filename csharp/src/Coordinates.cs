public class Coordinates
{
    public Coordinates(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; }
    public int Y { get; }

    internal List<Coordinates> GetAdjacent()
    {
        return new List<Coordinates>
        {
            new Coordinates(X - 1, Y - 1),
            new Coordinates(X, Y - 1),
            new Coordinates(X + 1, Y - 1),
            new Coordinates(X - 1, Y),
            new Coordinates(X + 1, Y),
            new Coordinates(X - 1, Y + 1),
            new Coordinates(X, Y + 1),
            new Coordinates(X + 1, Y + 1),
        };
    }
}