using UnityEngine;

namespace Utils
{
    public class TouchInputModule : InputModule
    {
        public override bool IsAvailable { get => Input.touchSupported; }

        public override void Init()
        {
            Input.multiTouchEnabled = false;
            Input.simulateMouseWithTouches = true;
        }

        protected override void Update()
        {
            if(Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                inputPosition.Value = touch.position;

                if(touch.phase == TouchPhase.Began)
                {
                    downPosition = Input.mousePosition;
                }

                if(touch.phase == TouchPhase.Ended)
                {
                    upPosition = Input.mousePosition;

                    if (down)
                    {
                        downCount.Value++;
                    }
                    else
                    {
                        if (right)      swipesRightCount.Value++;
                        else if (left)  swipesLeftCount.Value++;
                        else if (top)   swipesTopCount.Value++;
                        else if (bot)   swipesBotCount.Value++;
                    }
                }
            }
        }
    }
}