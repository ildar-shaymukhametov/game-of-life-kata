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
}