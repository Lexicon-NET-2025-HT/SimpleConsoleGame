internal class Map
{

    private Cell[,] _cells;
    
    private int height;
    private int width;

    public Map(int height, int width)
    {
        this.height = height;
        this.width = width;

        _cells = new Cell[height, width];
    }
}