public class LivingCell : Cell
{
    public LivingCell(Coordinates coordinates, Cell[,] cells) : base(coordinates, cells)
    {
    }

    internal override bool IsAliveInNextGeneration()
    {
        var numberOfNeighbours = GetNumberOfNeighbours();
        return numberOfNeighbours == 3 || numberOfNeighbours == 2;
    }
}