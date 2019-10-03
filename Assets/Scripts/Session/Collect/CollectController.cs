using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Session.Collect
{
    public class CollectController : MonoBehaviour
    {
        [SerializeField]
        private CollectItemsListReference runtimeCollectItems;

        public void OnStart()
        {
            for (int i = 0; i < runtimeCollectItems.Count; i++)
            {
                var collectItem = runtimeCollectItems[i];
                collectItem.Count.Value = 0;
            }
            runtimeCollectItems.Clear();
        }

        public void OnFinish()
        {
            for(int i = 0; i < runtimeCollectItems.Count; i++)
            {
                var collectItem = runtimeCollectItems[i];
                collectItem.Collect();
            }
        }

    }
}