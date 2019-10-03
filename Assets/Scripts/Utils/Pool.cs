using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class Pool<T> : MonoBehaviour where T: MonoBehaviour, IPoolObject
    {
        [SerializeField]
        protected List<T> templates = new List<T>();
        protected List<T> freeObjects = new List<T>();
        protected List<T> busyObjects = new List<T>();

        public T GetOrInstantiate(string id)
        {
            var freeObject = freeObjects.Find(WithId);
            if (freeObject)
            {
                freeObjects.Remove(freeObject);
                busyObjects.Add(freeObject);
                return freeObject;
            }
            else
            {
                var template = templates.Find(WithId);
                if (template)
                {
                    var cloned = Instantiate(template);
                    busyObjects.Add(cloned);
                    return cloned;
                }
            }
            return null;

            bool WithId(T item) => item.Id == id;
        }

        public void ReleaseObject(T item)
        {
            if (busyObjects.Contains(item))
            {
                item.Release();
                busyObjects.Remove(item);
                freeObjects.Add(item);
            }
        }

        public void ReleaseAll()
        {
            for(int i = 0; i < busyObjects.Count; i++)
            {
                var busyObject = busyObjects[i];
                busyObject.Release();
                freeObjects.Add(busyObject);
            }
            busyObjects.Clear();
        }
    }
}