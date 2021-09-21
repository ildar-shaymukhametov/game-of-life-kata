public class Cells
{
    private readonly Cell[,] _cells;

    public Cells()
    {
        _cells = new Cell[1000, 1000];
        Iterate(x => x.Initialize(_cells));
    }

    public bool AnyAlive()
    {
        return _cells.Cast<Cell>().Any(x => x is LivingCell);
    }

    public void SetLivingAt(Coordinates coordinates)
    {
        coordinates.SetLiving(_cells);
    }

    private void Iterate(Action<Coordinates> action)
    {
        for (int x = 0; x < _cells.GetLength(0); x++)
        {
            for (int y = 0; y < _cells.GetLength(1); y++)
            {
                action(new Coordinates(x, y));
            }
        }
    }
}