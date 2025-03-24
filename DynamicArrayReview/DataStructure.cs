public abstract class DataStructure
{
    protected int[] _values = new int[8];
    protected int _count = 0;
    public int Count { get { return _count; } }
    public abstract void Add(int value);
    public abstract void Clear();
    public int Get(int idx)
    {
        return _values[idx];
    }
    public abstract bool Remove(int target);
    public abstract void Sort();
    public abstract int BinarySearch(int target);
}