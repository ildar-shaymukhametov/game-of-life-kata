public class Size
{
    private readonly int width;
    private readonly int height;

    public Size(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    internal T[,] Create<T>()
    {
        return new T[width, height];
    }
}