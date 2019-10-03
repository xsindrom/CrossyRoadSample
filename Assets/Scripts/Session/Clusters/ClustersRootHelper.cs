using UnityEngine;
using Utils;

namespace Session
{
    public class ClustersRootHelper : MonoBehaviour
    {
        [SerializeField]
        private float minX;
        [SerializeField]
        private float maxX;

        [SerializeField]
        private IntReference downCount;
        [SerializeField]
        private IntReference swipesLeftCount;
        [SerializeField]
        private IntReference swipesRightCount;
        [SerializeField]
        private IntReference swipesBotCount;
        [SerializeField]
        private IntReference swipesTopCount;
        [SerializeField]
        private Transform clustersRoot;

        private void OnEnable()
        {
            downCount.OnValueChanged += DownCount_OnValueChanged;
            swipesLeftCount.OnValueChanged += SwipesLeftCount_OnValueChanged;
            swipesRightCount.OnValueChanged += SwipesRightCount_OnValueChanged;
            swipesTopCount.OnValueChanged += SwipesTopCount_OnValueChanged;
            swipesBotCount.OnValueChanged += SwipesBotCount_OnValueChanged;
        }

        private void SwipesBotCount_OnValueChanged(int count)
        {
            clustersRoot.position += Vector3.forward;
        }

        private void SwipesTopCount_OnValueChanged(int count)
        {
            clustersRoot.position += Vector3.back;
        }

        private void SwipesRightCount_OnValueChanged(int count)
        {
            if (clustersRoot.position.x > minX)
            {
                clustersRoot.position += Vector3.left;
            }
        }

        private void SwipesLeftCount_OnValueChanged(int count)
        {
            if (clustersRoot.position.x < maxX)
            {
                clustersRoot.position += Vector3.right;
            }
        }

        private void DownCount_OnValueChanged(int count)
        {
            clustersRoot.position += Vector3.back;
        }

        public void OnStart()
        {
            clustersRoot.position = Vector3.forward;
        }

        private void OnDisable()
        {
            downCount.OnValueChanged -= DownCount_OnValueChanged;
            swipesLeftCount.OnValueChanged -= SwipesLeftCount_OnValueChanged;
            swipesRightCount.OnValueChanged -= SwipesRightCount_OnValueChanged;
            swipesTopCount.OnValueChanged -= SwipesTopCount_OnValueChanged;
            swipesBotCount.OnValueChanged -= SwipesBotCount_OnValueChanged;
        }
    }
}