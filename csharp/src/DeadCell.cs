public class DeadCell : Cell
{
    internal override bool IsAliveInNextGeneration(int numberOfNeighbours)
    {
        return numberOfNeighbours == 3;
    }
}