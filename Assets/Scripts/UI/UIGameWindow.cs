using UnityEngine;
using TMPro;
using Utils;

namespace UI
{
    public class UIGameWindow : UIBaseWindow
    {
        [SerializeField]
        private IntReference scores;

        [SerializeField]
        private TMP_Text scoresText;

        public override void Init()
        {
            base.Init();
            scores.OnValueChanged += Scores_OnValueChanged;
        }

        private void Scores_OnValueChanged(int value)
        {
            scoresText.text = $"{value}";
        }
    }
}