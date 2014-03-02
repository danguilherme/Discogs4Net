using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Discogs4Net.Data.Pagination
{
    public class PaginatedList<T> : IList<T>
    {
        public PaginatedList(Paging paging, List<T> dataList)
        {
            this.Pagination = paging;
            this.Data = dataList;
        }

        public Paging Pagination { get; set; }
        public List<T> Data { get; set; }

        public override string ToString()
        {
            StringBuilder toReturn = new StringBuilder();

            toReturn.Append("[\r\n");
            for (int i = 0, len = Data.Count; i < len; i++)
            {
                toReturn.Append(Data[i].ToString());
                if (i != len - 1)
                    toReturn.Append(",\r\n");
            }
            toReturn.Append("\r\n]");

            return toReturn.ToString();
        }

        // IList
        public int IndexOf(T item)
        {
            return Data.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            Data.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            Data.RemoveAt(index);
        }

        public T this[int index]
        {
            get
            {
                return Data[index];
            }
            set
            {
                Data[index] = value;
            }
        }

        public void Add(T item)
        {
            Data.Add(item);
        }

        public void Clear()
        {
            Data.Clear();
        }

        public bool Contains(T item)
        {
            return Data.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Data.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return Data.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            return Data.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Data.GetEnumerator();
        }
    }
}
