﻿using UnityEditor;
using UnityEngine;

namespace SplatTheRat.ScriptableObjects.Events.Editor
{
    [CustomEditor(typeof(GameEvent))]
    public class EventEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            GameEvent e = target as GameEvent;
            if (GUILayout.Button("Raise")) e.Raise();
        }
    }
}