using UnityEngine;
using Session.Collect;

namespace Session.Collisions
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Session/Collisions/CollisionCollectItem")]
    public class CollisionCollectItem : CollisionItem
    {
        [SerializeField]
        private CollectItem collectItem;
        [SerializeField]
        private CollectItemsListReference runtimeCollectItems;

        public override void OnCollision(Collider collider)
        {
            base.OnCollision(collider);
            if (!runtimeCollectItems.Items.Contains(collectItem))
            {
                runtimeCollectItems.Add(collectItem);
            }

            collectItem.Count.Value++;
            collider.gameObject.SetActive(false);
        }
    }
}