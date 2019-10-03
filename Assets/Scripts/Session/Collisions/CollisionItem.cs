using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Session.Collisions
{
    public abstract class CollisionItem : ScriptableObject
    {
        [SerializeField]
        protected string collisionTag;
        public string CollisionTag => collisionTag;

        public virtual void OnCollision(Collider collider)
        {
            Debug.Log($"Collision with: {collisionTag}");
        }
    }
}