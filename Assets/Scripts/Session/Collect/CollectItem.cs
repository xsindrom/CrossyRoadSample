using UnityEngine;
using Utils;

namespace Session.Collect
{
    public abstract class CollectItem : ScriptableObject
    {
        [SerializeField]
        protected string id;
        [SerializeField]
        protected IntVariable count;

        public string Id => id;
        public IntVariable Count => count;

        public abstract void Collect();
    }
}