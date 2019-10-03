using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public enum WindowState { Opened, Closed }
    public delegate void WindowStateChanged(WindowState prevState, WindowState newState);

    public class UIBaseWindow : MonoBehaviour
    {
        [SerializeField]
        protected string id;
        [SerializeField]
        protected WindowState windowState;

        public event WindowStateChanged OnWindowStateChanged;

        public string Id => id;
        public WindowState WindowState
        {
            get { return windowState; }
            set
            {
                if (windowState != value)
                {
                    var prevState = windowState;
                    windowState = value;
                    OnWindowStateChanged?.Invoke(prevState, windowState);
                }
            }
        }

        public virtual void Init()
        {

        }

        public virtual void OpenWindow()
        {
            gameObject.SetActive(true);
            WindowState = WindowState.Opened;
        }

        public virtual void CloseWindow()
        {
            gameObject.SetActive(false);
            WindowState = WindowState.Closed;
        }
    }

}