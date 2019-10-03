using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Session
{
    [Serializable]
    public struct LineInfo
    {
        public float speed;
        public float interval;
        public string[] filter;
    }
    [CreateAssetMenu(menuName ="ScriptableObjects/Session/Clusters/Cluster")]
    public class Cluster : ScriptableObject
    {
        [SerializeField]
        private string id;
        [SerializeField]
        private List<LineInfo> lines = new List<LineInfo>();

        public string Id => id;
        public List<LineInfo> Lines => lines;
    }
}