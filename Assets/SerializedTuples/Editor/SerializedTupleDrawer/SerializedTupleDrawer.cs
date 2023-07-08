using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections.Generic;
using SerializedTuples.Runtime;

namespace SerializedTuples.EditorExtensions
{

    [CustomPropertyDrawer(typeof(SerializedTuple<,>), true)]
    public class SerializedTupleDrawer : PropertyDrawer
    {

        #region PRIVATE_SERIALIZED_VARS
        #endregion


        #region PRIVATE_VARS
        private const string DEFAULT_INSPECTOR_WARNINIG_LABEL_LITERAL = "#";
        private const string NO_ATTRIB_DEFINED = "No attributes defined";
        private const int ESTIMATED_HEIGHT_DIFFERENCE_MULTIPLIER = 4;             //Achieved from Trial and Error, No guarantee of supporting modifications
        private static string NameMapFieldName => SerializedTuple<byte, byte>.NameMapFieldName; //Doesnt matter what type we declare since field is static i.e. at class level




        private string[] defaultLabel = new[] { NO_ATTRIB_DEFINED };
        private GUIContent defaultInspectorWarningLabel = new GUIContent($"Non Serializable Datatype,inspector wont show them, Accessible from {DEFAULT_INSPECTOR_WARNINIG_LABEL_LITERAL} accessor");
        private Dictionary<string, bool> foldoutMap = new Dictionary<string, bool>();
        #endregion


        #region PRIVATE_PROPERTIES
        private float SingleLineHeight => EditorGUIUtility.singleLineHeight;
        private float VerticalSpacing => EditorGUIUtility.standardVerticalSpacing;
        private float InterPropertySpace => SingleLineHeight + VerticalSpacing;

       
        #endregion


        #region PUBLIC_VARS
        #endregion


        #region PUBLIC_PROPERTIES
        #endregion


        #region UNITY_CALLBAKCS
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (!IsFoldOut(property.propertyPath))
            {
                return EditorGUIUtility.singleLineHeight; // Only account for label
            }
            else
            {
                string[] labels = GetTupleLables();
                float foldoutHeight = 0;

                for (int i = 0; i < labels.Length; i++)
                {
                    SerializedProperty tupleFieldAsProperty = property.FindPropertyRelative($"v{i + 1}");
                    if (tupleFieldAsProperty != null)
                    {
                        foldoutHeight += CalculateTupleHeight(tupleFieldAsProperty) + SingleLineHeight;
                    }
                    else
                    {
                        foldoutHeight = SingleLineHeight + InterPropertySpace * ESTIMATED_HEIGHT_DIFFERENCE_MULTIPLIER;
                    }
                }

                return foldoutHeight;
            }
        }


        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            string[] labels = GetTupleLables();

            EditorGUI.BeginProperty(position, label, property);
            position.height = EditorGUIUtility.singleLineHeight;
            string propPath = property.propertyPath;

            SetFoldOut(propPath,EditorGUI.Foldout(position, IsFoldOut(propPath), label));

            if (IsFoldOut(propPath))
            {
                EditorGUI.indentLevel += property.depth + 1;
                position.y += InterPropertySpace;

                for (int i = 0; i < labels.Length; i++)
                    DrawTuple(ref position, property, labels[i], $"v{i + 1}");

                EditorGUI.indentLevel -= property.depth + 1;
            }

            EditorGUI.EndProperty();


            ValidateNameMap(property, labels);
        }



        #endregion


        #region CONSTRUCTOR
        #endregion


        #region PRIVATE_METHODS
        private SerializedProperty DrawTuple(ref Rect position, SerializedProperty property, string displayLabel, string tupleFieldName)
        {

            SerializedProperty tupleFieldAsProperty = property.FindPropertyRelative(tupleFieldName);
            if (tupleFieldAsProperty != null)
            {
                EditorGUI.PropertyField(position, tupleFieldAsProperty, new GUIContent(displayLabel));
                position.y += CalculateTupleHeight(tupleFieldAsProperty) + SingleLineHeight / ESTIMATED_HEIGHT_DIFFERENCE_MULTIPLIER;
            }
            else
            {
                defaultInspectorWarningLabel.text = defaultInspectorWarningLabel.text.Replace(DEFAULT_INSPECTOR_WARNINIG_LABEL_LITERAL, tupleFieldName);
                EditorGUI.LabelField(position, defaultInspectorWarningLabel);
                position.y += SingleLineHeight + InterPropertySpace * ESTIMATED_HEIGHT_DIFFERENCE_MULTIPLIER;
            }



            return tupleFieldAsProperty;
        }

        private static void ValidateNameMap(SerializedProperty property, string[] labels)
        {
            SerializedProperty nameMap = property.FindPropertyRelative(NameMapFieldName);

            if (nameMap.arraySize != labels.Length)
            {
                nameMap.ClearArray();

                for (int i = 0; i < labels.Length; i++)
                {
                    nameMap.InsertArrayElementAtIndex(i);
                    nameMap.GetArrayElementAtIndex(i).stringValue = labels[i];
                }
            }
        }

        private float CalculateTupleHeight(SerializedProperty tupleFieldAsProperty)
        {
            return EditorGUI.GetPropertyHeight(tupleFieldAsProperty);
        }

        private string[] GetTupleLables()
        {
            SerializedTupleLabelsAttribute labelsAttribute = this.fieldInfo.GetCustomAttributes(typeof(SerializedTupleLabelsAttribute), true).FirstOrDefault() as SerializedTupleLabelsAttribute;
            if (labelsAttribute == null)
                return defaultLabel;

            return labelsAttribute.labels;
        }

        private bool IsFoldOut(string propName)
        {
            AddIfNotFound(propName);
            return foldoutMap[propName];
        }

        private void SetFoldOut(string propName, bool status)
        {
            AddIfNotFound(propName);
            foldoutMap[propName] = status;
        }

        private void AddIfNotFound(string propName)
        {
            if (!foldoutMap.ContainsKey(propName))
                foldoutMap.Add(propName, false);
        }
        #endregion


        #region PUBLIC_METHODS
        #endregion


        #region EVENT_CALLBACKS
        #endregion


        #region COROUTINES
        #endregion


        #region INNERCLASS_DEFINITIONS
        #endregion


        #region EDITOR_ACCESSORS_OR_HELPERS
#if UNITY_EDITOR

#endif
        #endregion


    }
}
