using System;
using UnityEngine;
using UnityEngine.Events;

namespace Utils
{
    [Serializable]
    public class UnityEventString : UnityEvent<string>
    {

    }

    public class GameEventStringListener : GameEventArg0Listener<string>
    {
        [SerializeField]
        private GameEventString gameEvent;
        [SerializeField]
        private UnityEventString gameResponse;

        public override GameEventArg0<string> GameEvent => gameEvent;
        public override UnityEvent<string> GameResponse => gameResponse;
    }
}