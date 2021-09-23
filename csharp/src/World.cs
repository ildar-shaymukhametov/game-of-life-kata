using System.Text;

public class World
{
    private Cell[,] _cells;
    private readonly Size size;

    public World(Size size)
    {
        _cells = size.CreateGrid<Cell>();
        for (int x = 0; x < _cells.GetLength(0); x++)
        {
            for (int y = 0; y < _cells.GetLength(1); y++)
            {
                _cells[x, y] = new DeadCell(new Coordinates(x, y), _cells);
            }
        }

        this.size = size;
    }

    public bool IsEmpty()
    {
        return !_cells.Cast<Cell>().Any(x => x is LivingCell);
    }

    public void SetLivingAt(Coordinates coordinates)
    {
        _cells[coordinates.X, coordinates.Y] = new LivingCell(coordinates, _cells);
    }

    public void Tick()
    {
        var next = size.CreateGrid<Cell>();

        for (int x = 0; x < _cells.GetLength(0); x++)
        {
            for (int y = 0; y < _cells.GetLength(1); y++)
            {
                var coords = new Coordinates(x, y);
                if (_cells[coords.X, coords.Y].IsAliveInNextGeneration())
                {
                    next[coords.X, coords.Y] = new LivingCell(coords, _cells);
                }
                else
                {
                    next[coords.X, coords.Y] = new DeadCell(coords, _cells);
                }
            }
        }

        _cells = next;
    }

    public bool IsDeadAt(Coordinates coordinates)
    {
        return _cells[coordinates.X, coordinates.Y].IsDead();
    }

    public bool IsLivingAt(Coordinates coordinates)
    {
        return _cells[coordinates.X, coordinates.Y].IsAlive();
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        for (int y = 0; y < _cells.GetLength(1); y++)
        {
            for (int x = 0; x < _cells.GetLength(0); x++)
            {
                if (IsLivingAt(new Coordinates(x, y)))
                {
                    result.Append(" * ");
                }
                else
                {
                    result.Append("   ");
                }
            }
            result.AppendLine();
        }

        return result.ToString();
    }
}