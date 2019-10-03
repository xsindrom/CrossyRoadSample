using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Session.Scores
{
    public class ScoresController : MonoBehaviour
    {
        [SerializeField]
        private IntVariable scores;
        [SerializeField]
        private IntReference currentLineReference;

        private void Awake()
        {
            currentLineReference.OnValueChanged += CurrentLineReference_OnValueChanged;
        }

        private void CurrentLineReference_OnValueChanged(int value)
        {
            if(value > scores.Value)
            {
                scores.Value = value;
            }
        }

        public void OnStart()
        {
            scores.Value = 0;
        }
    }
}