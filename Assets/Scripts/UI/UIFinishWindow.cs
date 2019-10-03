using UnityEngine;
using TMPro;
using Utils;

namespace UI
{
    public class UIFinishWindow : UIBaseWindow
    {
        [SerializeField]
        private IntReference scores;
        [SerializeField]
        private IntReference coins;
        [SerializeField]
        private IntReference coinsCollected;

        [SerializeField]
        private TMP_Text scoresText;
        [SerializeField]
        private TMP_Text coinsText;
        [SerializeField]
        private TMP_Text coinsCollectedText;

        public override void Init()
        {
            base.Init();
            scores.OnValueChanged += Scores_OnValueChanged;
            coins.OnValueChanged += Coins_OnValueChanged;
            coinsCollected.OnValueChanged += CoinsCollected_OnValueChanged;
        }
        public override void OpenWindow()
        {
            base.OpenWindow();
            CoinsCollected_OnValueChanged(coinsCollected.Value);
            Coins_OnValueChanged(coins.Value);
            Scores_OnValueChanged(scores.Value);
        }

        private void CoinsCollected_OnValueChanged(int value)
        {
            coinsCollectedText.text = $"coins collected: +{value}";
        }

        private void Coins_OnValueChanged(int value)
        {
            coinsText.text = $"coins: {value}";
        }

        private void Scores_OnValueChanged(int value)
        {
            scoresText.text = $"scores: {value}";
        }
    }
}