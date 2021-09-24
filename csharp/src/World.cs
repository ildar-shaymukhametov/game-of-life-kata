using System.Text;

public class World
{
    private Cell[,] _cells;
    private readonly Size _size;

    public World(Size size)
    {
        _size = size;
        _cells = CreateGrid();
        for (int x = 0; x < _cells.GetLength(0); x++)
        {
            for (int y = 0; y < _cells.GetLength(1); y++)
            {
                SetDead(_cells, new Coordinates(x, y));
            }
        }
    }

    private Cell[,] CreateGrid()
    {
        return new Cell[_size.Width, _size.Height];
    }

    public bool IsEmpty()
    {
        return !_cells.Cast<Cell>().Any(x => x is LivingCell);
    }

    public void SetLivingAt(Coordinates coordinates)
    {
        SetAlive(_cells, coordinates);
    }

    public void Tick()
    {
        var next = CreateGrid();

        for (int x = 0; x < _cells.GetLength(0); x++)
        {
            for (int y = 0; y < _cells.GetLength(1); y++)
            {
                var coords = new Coordinates(x, y);
                if (CellAt(coords).IsAliveInNextGeneration())
                {
                    SetAlive(next, coords);
                }
                else
                {
                    SetDead(next, coords);
                }
            }
        }

        _cells = next;
    }

    private Cell CellAt(Coordinates coords)
    {
        return _cells[coords.X, coords.Y];
    }

    private void SetDead(Cell[,] cells, Coordinates coords)
    {
        cells[coords.X, coords.Y] = new DeadCell(coords, _cells);
    }

    private void SetAlive(Cell[,] cells, Coordinates coords)
    {
        cells[coords.X, coords.Y] = new LivingCell(coords, _cells);
    }

    public bool IsDeadAt(Coordinates coordinates)
    {
        return CellAt(coordinates).IsDead();
    }

    public bool IsLivingAt(Coordinates coordinates)
    {
        return CellAt(coordinates).IsAlive();
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