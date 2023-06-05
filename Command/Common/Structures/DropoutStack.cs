using System.Collections;

namespace command.Common.Structures
{
    public class DropoutStack<T> : IEnumerable<T>
    {
        private readonly T[] _array;
        private int _top;
        private int _count;

        public DropoutStack(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity), capacity, "Need non-negative number");
            _array = new T[capacity];
        }

        public DropoutStack(ICollection<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));
            _array = new T[collection.Count()];
        }

        public int Count
        {
            get { return _count; }
        }

        public void Push(T item)
        {
            _count += 1;
            _count = _count > _array.Length ? _array.Length : _count;

            _array[_top] = item;
            _top = (_top + 1) % _array.Length;
        }

        public T Pop()
        {
            if (_count == 0)
                ThrowForEmptyStack();

            _count -= 1;
            _count = _count < 0 ? 0 : _count;

            _top = (_array.Length + _top - 1) % _array.Length;
            return _array[_top];
        }

        public T Peek()
        {
            if (_count == 0)
                ThrowForEmptyStack();

            return _array[(_array.Length + _top - 1) % _array.Length];
        }

        public void Clear()
        {
            _count = 0;
        }

        public bool Contains(T item)
        {
            return _array.Contains(item);
        }

        public T GetItem(int index)
        {
            if (index > Count)
            {
                throw new InvalidOperationException("Index out of bounds");
            }
            else
            {
                return _array[(_array.Length + _top - (index + 1)) % _array.Length];
            }
        }

        public T[] ToArray()
        {
            return _array.ToArray();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return GetItem(i);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void ThrowForEmptyStack()
        {
            throw new InvalidOperationException("Empty stack");
        }
    }
}