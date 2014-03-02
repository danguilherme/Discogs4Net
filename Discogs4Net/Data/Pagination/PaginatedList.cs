using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Discogs4Net.Data.Pagination
{
    public class PaginatedList<T>
    {
        protected class Keys
        {
            public const string PagingRoot = Paging.Keys.Root;
            public const string ResultsRoot = "data";
        }

        public PaginatedList(Paging paging, List<T> dataList)
        {
            this.Pagination = paging;
            this.Data = dataList;
        }

        public PaginatedList()
        {
            this.Data = new List<T>();
        }

        [JsonProperty(PropertyName = Keys.PagingRoot)]
        public virtual Paging Pagination { get; set; }

        [JsonProperty(PropertyName = Keys.ResultsRoot)]
        public virtual List<T> Data { get; set; }

        public override string ToString()
        {
            StringBuilder toReturn = new StringBuilder();

            toReturn.Append("[ ");
            for (int i = 0, len = Data.Count; i < len; i++)
            {
                toReturn.Append(Data[i].ToString());
                if (i != len - 1)
                    toReturn.Append(", ");
            }
            toReturn.Append(" ]");

            return toReturn.ToString();
        }

        // IList
        public int IndexOf(T item)
        {
            return Data.IndexOf(item);
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

        public void Clear()
        {
            Data.Clear();
        }

        public int Count
        {
            get { return Data.Count; }
        }
    }
}
