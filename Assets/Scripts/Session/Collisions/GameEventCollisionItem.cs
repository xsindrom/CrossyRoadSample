using UnityEngine;
using Utils;

namespace Session.Collisions
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Session/Collisions/GameEventCollisionItem")]
    public class GameEventCollisionItem : CollisionItem
    {
        [SerializeField]
        private GameEvent collisionEvent;

        public override void OnCollision(Collider collider)
        {
            base.OnCollision(collider);
            collisionEvent?.Invoke();
        }
    }
}