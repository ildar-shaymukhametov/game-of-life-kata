public class LivingCell : Cell
{
    internal override bool IsAliveInNextGeneration(int numberOfNeighbours)
    {
        return numberOfNeighbours == 3 || numberOfNeighbours == 2;
    }
}