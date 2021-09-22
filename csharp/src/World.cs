public class World
{
    private readonly Cells _cells;

    public World()
    {
        _cells = new Cells();
    }

    public bool IsEmpty()
    {
        return !_cells.AnyAlive();
    }

    public void SetLivingAt(Coordinates coordinates)
    {
        _cells.SetLivingAt(coordinates);
    }

    public void Tick()
    {
        _cells.Tick();
    }

    public bool IsLivingAt(Coordinates coordinates)
    {
        return _cells.IsLivingAt(coordinates);
    }

    public bool IsDeadAt(Coordinates coordinates)
    {
        return _cells.IsDeadAt(coordinates);
    }

    public override string ToString()
    {
        return _cells.ToString();
    }
}