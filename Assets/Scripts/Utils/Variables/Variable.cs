using UnityEngine;

namespace Utils
{
    public class Variable<T0, T1> where T0 : VariableReference<T1>
    {
        [SerializeField]
        protected T1 value;
        [SerializeField]
        protected bool useReference;
        [SerializeField]
        protected T0 reference;

        public T1 Value
        {
            get { return useReference ? reference.Value : value; }
            set
            {
                if (useReference)
                {
                    reference.Value = value;
                }
                else
                {
                    this.value = value;
                }
            }
        }
    }
}