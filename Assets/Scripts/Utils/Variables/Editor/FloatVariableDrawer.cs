﻿using UnityEngine;
using UnityEditor;

namespace Utils
{
    [CustomPropertyDrawer(typeof(FloatVariable))]
    public class FloatVariableDrawer : PropertyDrawer
    {
        private SimpleVariableDrawerHelper drawerHelper = new SimpleVariableDrawerHelper();

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            drawerHelper.OnGUI(position, property, label);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return drawerHelper.GetPropertyHeight(property, label);
        }
    }
}