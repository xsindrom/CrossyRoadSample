using UnityEngine;

namespace Session.Collisions
{
    public class CollisionController : MonoBehaviour
    {
        [SerializeField]
        private CollisionItemsListReference collisionItems;

        private void OnTriggerEnter(Collider collider)
        {
            if (!collider.gameObject || !collider)
                return;

            var collisionItem = collisionItems.Items.Find(WithTag);
            collisionItem?.OnCollision(collider);

            bool WithTag(CollisionItem item) => collider.CompareTag(item.CollisionTag);
        }
    }
}