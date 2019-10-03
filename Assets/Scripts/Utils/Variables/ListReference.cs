using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class ListReference<T> : ScriptableObject
    {
        [SerializeField]
        private List<T> items = new List<T>();

        public List<T> Items => items;
        public int Count => items.Count;

        public T this[int index]
        {
            get { return items[index]; }
            set { items[index] = value; }
        }

        public event Action<T> OnItemAdded;
        public event Action<T> OnItemRemoved;
        public event Action OnItemsCleared;

        public void Add(T item)
        {
            items.Add(item);
            OnItemAdded?.Invoke(item);
        }

        public void Remove(T item)
        {
            if (items.Remove(item))
            {
                OnItemRemoved?.Invoke(item);
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= items.Count)
                return;

            var item = items[index];
            items.RemoveAt(index);
            OnItemRemoved?.Invoke(item);
        }

        public void Clear()
        {
            items.Clear();
            OnItemsCleared?.Invoke();
        }
    }
}