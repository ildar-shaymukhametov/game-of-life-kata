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
        cells[x, y] = new DeadCell();
    }

    public void SetLiving(Cell[,] cells)
    {
        cells[x, y] = new LivingCell();
    }
}