using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
namespace Session
{
    public class MovementObject : MonoBehaviour, IPoolObject
    {
        [SerializeField]
        private string id;
        public string Id => id;

        public void Release()
        {
            gameObject.SetActive(false);
        }
    }
}