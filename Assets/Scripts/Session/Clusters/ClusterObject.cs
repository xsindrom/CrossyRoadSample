using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Session
{
    public class ClusterObject : MonoBehaviour, IPoolObject
    {
        [SerializeField]
        private string id;
        [SerializeField]
        private List<ClusterLine> lines = new List<ClusterLine>();
        [SerializeField]
        private List<Transform> specialObjects = new List<Transform>();

        public string Id => id;
        public Cluster Source { get; set; }
        public int StartLine { get; set; }

        public void Init(Cluster source, int startLine)
        {
            Source = source;
            StartLine = startLine;

            for(int i = 0; i < lines.Count; i++)
            {
                var line = lines[i];
                if(Source.Lines.Count > i)
                {
                    line.Init(Source.Lines[i]);
                }
            }

            for (int i = 0; i < specialObjects.Count; i++)
            {
                specialObjects[i].gameObject.SetActive(true);
            }
        }

        public void Release()
        {
            Source = null;
            gameObject.SetActive(false);
            for (int i = lines.Count - 1; i >= 0; i--)
            {
                lines[i].ReleaseLine();
            }
        }
    }
}