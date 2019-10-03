using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class Extensions
    {
        public static bool ApproximatelyEqual(this Vector3 a, Vector3 b, float approximity = 0.1f)
        {
            return Mathf.Abs(a.x - b.x) <= approximity &&
                   Mathf.Abs(a.y - b.y) <= approximity &&
                   Mathf.Abs(a.z - b.z) <= approximity;
        }

    }
}