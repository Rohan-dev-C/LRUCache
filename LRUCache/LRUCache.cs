using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUCache
{

    public interface ICache<TKey, TValue>
    {
        bool TryGetValue(TKey key, out TValue value);
        void Put(TKey key, TValue value);

    }

    public class LRUCache<TKey, TValue> : ICache<TKey, TValue>
    {
        LinkedList<KeyValuePair<TKey, TValue>> list;
        Dictionary<TKey, LinkedListNode<KeyValuePair<TKey, TValue>>> dict;


        public int Count => dict.Count;
        int limit; 

        public LRUCache(int limit)
        {
           dict = new Dictionary<TKey, LinkedListNode<KeyValuePair<TKey, TValue>>>(limit);
           list = new LinkedList<KeyValuePair<TKey, TValue>>();
            this.limit = limit; 
        }

        public void Put(TKey key, TValue value)
        {
            if(dict.ContainsKey(key))
            {
                var temp = dict[key];

                list.Remove(temp);

                var pair = new KeyValuePair<TKey, TValue>(key, value);
                list.AddFirst(pair); 
                dict[key] = list.First; 
            }
            else
            {
                var temp = new LinkedListNode<KeyValuePair<TKey, TValue>>(new KeyValuePair<TKey, TValue>(key, value));
                list.AddFirst(temp);
                dict.Add(key, temp);
                if (list.Count > limit)
                {
                    var temp2 = list.Last; 
                    list.Remove(temp2);
                    dict.Remove(temp2.Value.Key); 
                }
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if(dict.ContainsKey(key))
            {
                var temp = dict[key];

                list.Remove(temp);
                list.AddFirst(temp);

                value = temp.Value.Value; 

                return true;

            }
            value = default; 
            return false;
        }
    }
}
