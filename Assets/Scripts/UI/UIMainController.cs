using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIMainController : MonoBehaviour
    {
        [SerializeField]
        private RectTransform windowsRoot;
        [SerializeField]
        private UIBaseWindowsListReference windows;
        private Dictionary<string, UIBaseWindow> windowsDict = new Dictionary<string, UIBaseWindow>();

        private void Awake()
        {
            for(int i = 0; i < windows.Count; i++)
            {
                var window = windows[i];

                var cloned = Instantiate(window, windowsRoot);
                cloned.gameObject.SetActive(cloned.WindowState == WindowState.Opened);
                cloned.Init();
                windowsDict.Add(cloned.Id, cloned);
            }
        }
    }
}