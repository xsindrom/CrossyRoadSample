using UnityEngine;
using UnityEditor;

namespace Utils
{
    public class SimpleVariableDrawerHelper
    {
        public const string USE_REFERENCE_PROP = "useReference";
        public const string REFERENCE_PROP = "reference";
        public const string VALUE_PROP = "value";

        public void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            var prevlevel = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;
            EditorGUI.LabelField(new Rect(position.x,
                                          position.y,
                                          position.width * 0.2f,
                                          position.height), label);

            var userReferenceProp = property.FindPropertyRelative("useReference");
            EditorGUI.LabelField(new Rect(position.x + position.width * 0.2f,
                                            position.y,
                                            position.width * 0.2f,
                                            position.height), new GUIContent("Use Reference"));
            EditorGUI.PropertyField(new Rect(position.x + position.width * 0.4f,
                                             position.y,
                                             position.width * 0.1f,
                                             position.height), userReferenceProp, GUIContent.none);
            if (userReferenceProp.boolValue)
            {
                var referenceProp = property.FindPropertyRelative("reference");
                EditorGUI.PropertyField(new Rect(position.x + position.width * 0.5f,
                                                 position.y,
                                                 position.width * 0.5f,
                                                 position.height), referenceProp, GUIContent.none);
            }
            else
            {
                var valueProp = property.FindPropertyRelative("value");
                EditorGUI.PropertyField(new Rect(position.x + position.width * 0.5f,
                                                 position.y,
                                                 position.width * 0.5f,
                                                 position.height), valueProp, GUIContent.none);
            }
            EditorGUI.indentLevel = prevlevel;
            EditorGUI.EndProperty();
        }

        public float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight;
        }
    }
}