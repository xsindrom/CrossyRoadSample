using System;
using UnityEngine;
using UnityEngine.Events;

namespace Utils
{
    [Serializable]
    public class UnityEventInt : UnityEvent<int>
    {

    }

    public class GameEventIntListener : GameEventArg0Listener<int>
    {
        [SerializeField]
        private GameEventInt gameEvent;
        [SerializeField]
        private UnityEventInt gameResponse;

        public override GameEventArg0<int> GameEvent => gameEvent;
        public override UnityEvent<int> GameResponse => gameResponse;
    }
}