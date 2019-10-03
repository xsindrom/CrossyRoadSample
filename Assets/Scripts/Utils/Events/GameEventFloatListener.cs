using System;
using UnityEngine;
using UnityEngine.Events;

namespace Utils
{
    [Serializable]
    public class UnityEventFloat : UnityEvent<float>
    {

    }

    public class GameEventFloatListener : GameEventArg0Listener<float>
    {
        [SerializeField]
        private GameEventFloat gameEvent;
        [SerializeField]
        private UnityEventFloat gameResponse;

        public override GameEventArg0<float> GameEvent => gameEvent;
        public override UnityEvent<float> GameResponse => gameResponse;
    }
}