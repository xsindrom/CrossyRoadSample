using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class VariableReference<T> : ScriptableObject
    {
        [SerializeField]
        protected T value;
        [SerializeField, Header("Default")]
        protected T defaultValue;

        public T Value
        {
            get { return value; }
            set
            {
                if(!EqualityComparer<T>.Default.Equals(this.value, value))
                {
                    this.value = value;
                    OnValueChanged?.Invoke(this.value);
                }
            }
        }

        public event Action<T> OnValueChanged;

        protected virtual void OnEnable()
        {
            value = defaultValue;
        }
    }
}