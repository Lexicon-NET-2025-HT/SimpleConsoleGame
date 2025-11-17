
namespace SimpleConsoleGame.LimitedList;

public interface ILimitedsList<T>
{
    int Count { get; }
    bool IsFull { get; }

    IEnumerator<T> GetEnumerator();

    bool Add(T item);
}