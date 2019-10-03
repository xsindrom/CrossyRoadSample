using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public abstract class InputModule : MonoBehaviour
    {
        [SerializeField]
        protected IntReference downCount;
        [SerializeField]
        protected IntReference swipesLeftCount;
        [SerializeField]
        protected IntReference swipesRightCount;
        [SerializeField]
        protected IntReference swipesTopCount;
        [SerializeField]
        protected IntReference swipesBotCount;
        [SerializeField]
        protected Vector3Reference inputPosition;

        protected Vector3 downPosition;
        protected Vector3 upPosition;

        protected float offsetX;
        protected float offsetY;

        protected float dx => upPosition.x - downPosition.x;
        protected float dy => upPosition.y - downPosition.y;

        protected bool right    => Mathf.Abs(dx) >  Mathf.Abs(dy) && dx > 0;
        protected bool left     => Mathf.Abs(dx) >  Mathf.Abs(dy) && dx < 0;
        protected bool top      => Mathf.Abs(dy) >  Mathf.Abs(dx) && dy > 0;
        protected bool bot      => Mathf.Abs(dy) >  Mathf.Abs(dx) && dy < 0;
        protected bool down     => Mathf.Abs(dx) <= offsetX && Mathf.Abs(dy) <= offsetY;

        public abstract bool IsAvailable { get; }
        public abstract void Init();

        protected abstract void Update();
    }
}