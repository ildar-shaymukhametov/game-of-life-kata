using System.Text;

public class World
{
    private Cell[,] _cells;
    private readonly Size _size;

    public World(Size size)
    {
        _size = size;
        _cells = CreateGrid();
        PopulateCells();
    }

    private void PopulateCells()
    {
        ForEach(x => SetDead(_cells, x));
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
        _cells = GetNextGeneration();
    }

    private Cell[,] GetNextGeneration()
    {
        var next = CreateGrid();
        ForEach(x => next[x.X, x.Y] = CreateCell(x));

        return next;
    }

    private void ForEach(Action<Coordinates> action)
    {
        for (int x = 0; x < _cells.GetLength(0); x++)
        {
            for (int y = 0; y < _cells.GetLength(1); y++)
            {
                action(new Coordinates(x, y));
            }
        }
    }

    private Cell CreateCell(Coordinates coords)
    {
        if (CellAt(coords).IsAliveInNextGeneration())
        {
            return new LivingCell(coords, _cells);
        }
        else
        {
            return new DeadCell(coords, _cells);
        }
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
                result.Append($" {CellAt(new Coordinates(x, y))} ");
            }
            result.AppendLine();
        }

        return result.ToString();
    }
}