using UnityEngine;
using UnityEngine.Events;

namespace Utils
{
    public abstract class GameEventArg0Listener<T0> : MonoBehaviour
    {
        public abstract GameEventArg0<T0> GameEvent { get; }
        public abstract UnityEvent<T0> GameResponse { get; }

        private void Awake()
        {
            GameEvent?.RegisterListener(this);
        }

        private void OnDestroy()
        {
            GameEvent?.UnRegisterListener(this);
        }

        public void Invoke(T0 data)
        {
            GameResponse?.Invoke(data);
        }
    }
}