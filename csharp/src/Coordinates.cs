using System.Linq;

public class Coordinates
{
    private int x;
    private int y;

    public Coordinates(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void Initialize(Cell[,] cells)
    {
        SetDead(cells);
    }

    public void SetLiving(Cell[,] cells)
    {
        cells[x, y] = new LivingCell();
    }

    internal bool IsLiving(Cell[,] cells)
    {
        return cells[x, y] is LivingCell;
    }

    internal bool IsAliveInNextGeneration(Cell[,] cells)
    {
        return cells[x, y].IsAliveInNextGeneration(GetNumberOfNeighbours(cells));
    }

    private int GetNumberOfNeighbours(Cell[,] cells)
    {
        return GetAdjacent().Where(x => x.IsInBounds(cells)).Where(x => x.IsLiving(cells)).Count();
    }

    private bool IsInBounds(Cell[,] cells)
    {
        return x < cells.GetLength(0) && x >= 0 && y < cells.GetLength(1) && y >= 0;
    }

    internal void SetDead(Cell[,] cells)
    {
        cells[x, y] = new DeadCell();
    }

    internal bool IsDead(Cell[,] cells)
    {
        return cells[x, y] is DeadCell;
    }

    private List<Coordinates> GetAdjacent()
    {
        return new List<Coordinates>
        {
            new Coordinates(x - 1, y - 1),
            new Coordinates(x, y - 1),
            new Coordinates(x + 1, y - 1),
            new Coordinates(x - 1, y),
            new Coordinates(x + 1, y),
            new Coordinates(x - 1, y + 1),
            new Coordinates(x, y + 1),
            new Coordinates(x + 1, y + 1),
        };
    }
}