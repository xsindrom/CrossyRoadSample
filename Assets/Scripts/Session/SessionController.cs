using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Session
{
    public class SessionController : MonoBehaviour
    {
        [SerializeField]
        private GameEvent startSessionEvent;
        [SerializeField]
        private GameEvent finishSessionEvent;

        public void StartSession()
        {
            startSessionEvent?.Invoke();
        }

        public void FinishSession()
        {
            finishSessionEvent?.Invoke();
        }
    }
}