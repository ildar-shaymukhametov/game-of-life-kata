using System.Text;

public class World
{
    private Cell[,] _cells;

    public World(Size size)
    {
        _cells = size.CreateGrid<Cell>();
        for (int x = 0; x < _cells.GetLength(0); x++)
        {
            for (int y = 0; y < _cells.GetLength(1); y++)
            {
                _cells[x, y] = new DeadCell();
            }
        }
    }

    public bool IsEmpty()
    {
        return !_cells.Cast<Cell>().Any(x => x is LivingCell);
    }

    public void SetLivingAt(Coordinates coordinates)
    {
        coordinates.SetLiving(_cells);
    }

    public void Tick()
    {
        var next = new Cell[_cells.GetLength(0), _cells.GetLength(1)];

        for (int x = 0; x < _cells.GetLength(0); x++)
        {
            for (int y = 0; y < _cells.GetLength(1); y++)
            {
                var coords = new Coordinates(x, y);
                if (coords.IsAliveInNextGeneration(_cells))
                {
                    coords.SetLiving(next);
                }
                else
                {
                    coords.SetDead(next);
                }
            }
        }

        _cells = next;
    }

    public bool IsDeadAt(Coordinates coordinates)
    {
        return coordinates.IsDead(_cells);
    }

    public bool IsLivingAt(Coordinates coordinates)
    {
        return coordinates.IsLiving(_cells);
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