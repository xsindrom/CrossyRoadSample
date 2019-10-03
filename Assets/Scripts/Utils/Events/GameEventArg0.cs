using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class GameEventArg0<T0> : BaseGameEvent
    {
        private List<GameEventArg0Listener<T0>> listeners = new List<GameEventArg0Listener<T0>>();

        public void Invoke(T0 data)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].Invoke(data);
            }
        }

        public void RegisterListener(GameEventArg0Listener<T0> listener)
        {
            listeners.Add(listener);
        }

        public void UnRegisterListener(GameEventArg0Listener<T0> listener)
        {
            listeners.Remove(listener);
        }
    }
}