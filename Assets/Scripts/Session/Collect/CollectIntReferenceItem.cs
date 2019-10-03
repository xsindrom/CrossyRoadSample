using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Session.Collect
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Session/Collect/CollectIntReferenceItem")]
    public class CollectIntReferenceItem : CollectItem
    {
        [SerializeField]
        private IntReference source;

        public override void Collect()
        {
            source.Value += count.Value;
        }

    }
}