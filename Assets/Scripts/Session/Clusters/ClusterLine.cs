using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Session
{
    public class ClusterLine : MonoBehaviour
    {
        [SerializeField]
        private List<Transform> spawnPoints = new List<Transform>();
        [SerializeField]
        private List<Transform> releasePoints = new List<Transform>();
        [SerializeField]
        private MovementObjectsPool movementObjectsPool;

        private List<MovementObject> movementObjects = new List<MovementObject>();
        private float currentTime;

        public LineInfo Source { get; set; }
        public Transform SpawnPoint { get; set; }
        public Transform ReleasePoint { get; set; }

        public void Init(LineInfo source)
        {
            Source = source;
            currentTime = Source.interval;
            SpawnPoint = spawnPoints.Find(x => Mathf.Sign(x.transform.localPosition.x) != Mathf.Sign(Source.speed));
            ReleasePoint = releasePoints.Find(x => Mathf.Sign(x.transform.localPosition.x) == Mathf.Sign(Source.speed));
        }

        private void SpawnRandomMovementObject()
        {
            var id = Source.filter[Random.Range(0, Source.filter.Length)];
            var movementObject = movementObjectsPool.GetOrInstantiate(id);
            if (movementObject)
            {
                movementObject.transform.SetParent(transform);
                movementObject.transform.localPosition = SpawnPoint.localPosition;
                movementObject.gameObject.SetActive(true);
                movementObjects.Add(movementObject);
            }
        }

        private void ReleaseMovementObject(MovementObject movementObject)
        {
            movementObjectsPool.ReleaseObject(movementObject);
            movementObjects.Remove(movementObject);
        }

        public void ReleaseLine()
        {
            movementObjectsPool.ReleaseAll();
            movementObjects.Clear();
            SpawnPoint = null;
            ReleasePoint = null;
            currentTime = 0.0f;
        }

        private void Update()
        {
            currentTime += Time.deltaTime;
            if(currentTime > Source.interval)
            {
                SpawnRandomMovementObject();
                currentTime = 0.0f;
            }

            for (int i = movementObjects.Count - 1; i >= 0; i--)
            {
                var movementObject = movementObjects[i];
                movementObject.transform.localPosition += Vector3.right * Source.speed * Time.deltaTime;

                if (movementObject.transform.localPosition.ApproximatelyEqual(ReleasePoint.transform.localPosition))
                {
                    ReleaseMovementObject(movementObject);
                    break;
                }
            }
        }
    }
}