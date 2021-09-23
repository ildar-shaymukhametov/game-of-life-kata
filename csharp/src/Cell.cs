public abstract class Cell
{
    private readonly Coordinates coordinates;
    private readonly Cell[,] cells;

    public Cell(Coordinates coordinates, Cell[,] cells)
    {
        this.coordinates = coordinates;
        this.cells = cells;
    }

    internal abstract bool IsAliveInNextGeneration();

    protected int GetNumberOfNeighbours()
    {
        return coordinates.GetAdjacent().Where(IsInBounds).Where(IsAlive).Count();
    }

    private bool IsInBounds(Coordinates coordinates)
    {
        return coordinates.X < cells.GetLength(0) && coordinates.X >= 0 && coordinates.Y < cells.GetLength(1) && coordinates.Y >= 0;
    }

    private bool IsAlive(Coordinates coordinates)
    {
        return cells[coordinates.X, coordinates.Y].IsAlive();
    }

    internal bool IsDead()
    {
        return this is DeadCell;
    }

    internal bool IsAlive()
    {
        return this is LivingCell;
    }
}