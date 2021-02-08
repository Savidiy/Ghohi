using System;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(RequireInterfaceAttribute))]
public class RequireInterfaceDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType == SerializedPropertyType.ObjectReference)
        {
            var requireAttribute = this.attribute as RequireInterfaceAttribute;

            EditorGUI.BeginProperty(position, label, property);

            label.text += $" ({requireAttribute.RequiredType.Name})";

            UnityEngine.Object obj = EditorGUI.ObjectField(
                position: position,
                label: label,
                obj: property.objectReferenceValue,
                objType: typeof(UnityEngine.Object),
                allowSceneObjects: true);

            if (obj is GameObject g)
                property.objectReferenceValue = g.GetComponent(requireAttribute.RequiredType);

            //property.objectReferenceValue = EditorGUI.ObjectField(
            //    position: position,
            //    label: label,
            //    obj: property.objectReferenceValue,
            //    objType: requireAttribute.RequiredType,
            //    allowSceneObjects: true);



            EditorGUI.EndProperty();
        }
        else
        {
            var previousColor = GUI.color;
            GUI.color = Color.red;
            
            EditorGUI.LabelField(position, label, new GUIContent("Property is not a reference type"));

            GUI.color = previousColor;
        }
    }
}
