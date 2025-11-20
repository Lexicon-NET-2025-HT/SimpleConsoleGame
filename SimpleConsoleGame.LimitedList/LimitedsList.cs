using System.Collections;

namespace SimpleConsoleGame.LimitedList;

//Generic custom list we use for backpack in Player and as a baseclass for MessageLog
//T can be anything no constrants.
//What Type T is desides when creating an instance example: var li = new LimitedList<string>(6);
public class LimitedsList<T> : IEnumerable<T>, ILimitedsList<T>
{
    protected List<T> _list;
    private readonly int _capacity;
    public int Count => _list.Count;
    public bool IsFull => _capacity <= Count;

    //Makes it possible to get something from the list based on Index. example: var x = backpack[3]
    public T this[int index]  => _list[index];
    //{  
    //    get => _list[index];
    //    set => _list[index] = value; 
    //}

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

    public void Print(Action<T> action)
    {
        _list.ForEach(x => action?.Invoke(x));
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

    public bool Remove(T item) => _list.Remove(item);
  
}
