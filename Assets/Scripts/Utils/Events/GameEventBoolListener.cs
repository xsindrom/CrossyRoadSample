using System;
using UnityEngine;
using UnityEngine.Events;

namespace Utils
{
    [Serializable]
    public class UnityEventBool : UnityEvent<bool>
    {

    }

    public class GameEventBoolListener : GameEventArg0Listener<bool>
    {
        [SerializeField]
        private GameEventBool gameEvent;
        [SerializeField]
        private UnityEventBool gameResponse;

        public override GameEventArg0<bool> GameEvent => gameEvent;
        public override UnityEvent<bool> GameResponse => gameResponse;
    }
}