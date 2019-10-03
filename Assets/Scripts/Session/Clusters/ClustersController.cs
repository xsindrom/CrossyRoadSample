using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Session
{
    public class ClustersController : MonoBehaviour
    {
        [SerializeField]
        private int maxVisibleClusters;
        [SerializeField]
        private int releaseLineOffset;

        [SerializeField]
        private IntReference downCount;
        [SerializeField]
        private IntReference swipesBotCount;
        [SerializeField]
        private IntReference swipesTopCount;

        [SerializeField]
        private IntReference currentLine;
        [SerializeField]
        private IntReference lastLine;

        [SerializeField]
        private ClustersListReference clusters;
        [SerializeField]
        private ClustersListReference runtimeActiveClusters;

        [SerializeField]
        private Transform clustersRoot;
        [SerializeField]
        private ClusterObjectsPool clustersPool;
        [SerializeField]
        private List<ClusterObject> clusterObjects = new List<ClusterObject>(); 

        private void Start()
        {
            runtimeActiveClusters.Clear();
            runtimeActiveClusters.OnItemRemoved += RuntimeActiveClusters_OnItemRemoved;
            runtimeActiveClusters.OnItemAdded += RuntimeActiveClusters_OnItemAdded;
            currentLine.OnValueChanged += CurrentLine_OnValueChanged;
            downCount.OnValueChanged += DownCount_OnValueChanged;
            swipesBotCount.OnValueChanged += SwipesBotCount_OnValueChanged;
            swipesTopCount.OnValueChanged += SwipesTopCount_OnValueChanged;
        }

        public void OnStart()
        {
            runtimeActiveClusters.Clear();
            var prevIndex = -1;
            var index = -1;
            for (int i = 0; i < maxVisibleClusters; i++)
            {
                index = GenerateNewRandomIndex(prevIndex);
                prevIndex = index;

                var cluster = clusters[index];
                runtimeActiveClusters.Add(cluster);
            }
            currentLine.Value = 0;
        }

        public void OnFinish()
        {
            clustersPool.ReleaseAll();
            clusterObjects.Clear();
            lastLine.Value = 0;
            currentLine.Value = 0;
        }

        private void SwipesTopCount_OnValueChanged(int count)
        {
            currentLine.Value++;
        }

        private void SwipesBotCount_OnValueChanged(int count)
        {
            currentLine.Value--;
        }

        private void DownCount_OnValueChanged(int count)
        {
            currentLine.Value++;
        }

        private void CurrentLine_OnValueChanged(int currentLine)
        {
            if (clusterObjects.Count > 0)
            {
                var clusterObject = clusterObjects[0];
                if (currentLine > clusterObject.StartLine + clusterObject.Source.Lines.Count + releaseLineOffset)
                {
                    ReleaseObject(clusterObject);
                }
            }
        }

        private int GenerateNewRandomIndex(int prevIndex)
        {
            var index = Random.Range(0, clusters.Count);
            while (index == prevIndex)
            {
                index = Random.Range(0, clusters.Count);
            }
            return index;
        }

        private void RuntimeActiveClusters_OnItemAdded(Cluster cluster)
        {
            var clusterObject = clustersPool.GetOrInstantiate(cluster.Id);
            if (!clusterObject)
                return;

            clusterObject.Init(cluster, lastLine.Value);
            clusterObjects.Add(clusterObject);

            clusterObject.transform.SetParent(clustersRoot);
            clusterObject.transform.localPosition =  Vector3.forward * lastLine.Value;
            clusterObject.gameObject.SetActive(true);

            lastLine.Value += cluster.Lines.Count;
        }

        private void RuntimeActiveClusters_OnItemRemoved(Cluster cluster)
        {
            var lastClusterObject = clusterObjects[clusterObjects.Count - 1];
            var lastIndex = clusters.Items.IndexOf(lastClusterObject.Source);
            var newIndex = GenerateNewRandomIndex(lastIndex);

            var newCluster = clusters[newIndex];
            runtimeActiveClusters.Add(newCluster);
        }

        private void ReleaseObject(ClusterObject clusterObject)
        {
            runtimeActiveClusters.Remove(clusterObject.Source);
            clustersPool.ReleaseObject(clusterObject);
            clusterObjects.Remove(clusterObject);
        }
    }
}