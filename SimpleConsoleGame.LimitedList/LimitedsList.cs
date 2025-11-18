using System.Collections;

namespace SimpleConsoleGame.LimitedList;

public class LimitedsList<T> : IEnumerable<T>, ILimitedsList<T>
{
    protected List<T> _list;
    private readonly int _capacity;
    public int Count => _list.Count;
    public bool IsFull => _capacity <= Count;

    public T this[int index] => _list[index];

    public LimitedsList(int capacity)
    {
        _capacity = Math.Max(capacity, 2);
        _list = new List<T>(_capacity);
    }

    public virtual bool Add(T item)
    {
        if (IsFull) return false;
        _list.Add(item); return true;
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (T item in _list)
        {
            //....
            //....
            //....
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

}
