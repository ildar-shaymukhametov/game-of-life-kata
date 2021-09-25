public class DeadCell : Cell
{
    public DeadCell(Coordinates coordinates, Cell[,] cells) : base(coordinates, cells)
    {
    }

    internal override bool IsAliveInNextGeneration()
    {
        return GetNumberOfNeighbours() == 3;
    }

    public override string ToString() => " ";
}