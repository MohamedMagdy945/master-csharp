using master_csharp.App.Enumerator;
using System.Collections;
namespace master_csharp.App.Enumerator
{
  

    class MyCustomCollection : IEnumerable<int>
    {
        private int[] data = { 1, 2, 3, 4 };

        public IEnumerator<int> GetEnumerator()
        {
            return new MyEnumerator(data);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class MyEnumerator : IEnumerator<int>
        {
            private int[] _data;
            private int _position = -1;

            public MyEnumerator(int[] data)
            {
                _data = data;
            }

            public int Current
            {
                get
                {
                    if (_position < 0 || _position >= _data.Length)
                        throw new InvalidOperationException();
                    return _data[_position];
                }
            }

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                _position++;
                return (_position < _data.Length);
            }

            public void Reset()
            {
                _position = -1;
            }

            public void Dispose()
            {
            }
        }
    }
}
class CustomCollectionUsage
{
    public static void Test()
    {
        MyCustomCollection col = new MyCustomCollection();

        foreach (var x in col)
        {
            Console.WriteLine(x);
        }
    }
}
