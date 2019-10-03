using UnityEngine;

namespace Utils
{
    public class MouseInputModule : InputModule
    {
        public override bool IsAvailable { get => Input.mousePresent; }

        public override void Init()
        {
        }

        protected override void Update()
        {
            inputPosition.Value = Input.mousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                downPosition = Input.mousePosition;
            }

            if(Input.GetMouseButtonUp(0))
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