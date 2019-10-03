using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Utils/Events/GameEvent")]
    public class GameEvent : BaseGameEvent
    {
        private List<GameEventListener> listeners = new List<GameEventListener>();

        public void Invoke()
        {
            for(int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].Invoke();
            }
        }

        public void RegisterListener(GameEventListener listener)
        {
            listeners.Add(listener);
        }

        public void UnRegisterListener(GameEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}