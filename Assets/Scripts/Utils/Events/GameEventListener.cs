using UnityEngine;
using UnityEngine.Events;

namespace Utils
{
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField]
        private GameEvent gameEvent;
        [SerializeField]
        private UnityEvent gameResponse;

        private void Awake()
        {
            gameEvent.RegisterListener(this);
        }

        private void OnDestroy()
        {
            gameEvent.UnRegisterListener(this);
        }

        public void Invoke()
        {
            gameResponse?.Invoke();
        }
    }
}