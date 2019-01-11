using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BoardCreator))]
public class BoardCreationInspector : Editor
{
    public BoardCreator current => (BoardCreator)target;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Clear"))
        {
            current.Clear();
        }
        if(GUILayout.Button("Grow"))
        {
            current.Grow();
        }
        if (GUILayout.Button("Shrink"))
        {
            current.Shrink();
        }
        if(GUILayout.Button("Grow Area"))
        {
            current.GrowArea();
        }
        if(GUILayout.Button("Shrink Area"))
        {
            current.ShrinkArea();
        }
        if(GUILayout.Button("Save"))
        {
            current.Save();
        }
        if (GUILayout.Button("Load"))
        {
            current.Load();
        }

        if(GUI.changed)
        {
            current.UpdateMarker();
        }

        CheckKeyboardInput();
    }

    void OnSceneGUI()
    {
        CheckKeyboardInput();
    }

    private void CheckKeyboardInput()
    {
        Event e = Event.current;
        if (e.type == EventType.KeyDown)
        {
            if (e.keyCode == KeyCode.A)
            {
                current.SelectLeft();
            }
            if (e.keyCode == KeyCode.D)
            {
                current.SelectRight();
            }
            if (e.keyCode == KeyCode.W)
            {
                current.SelectUp();
            }
            if (e.keyCode == KeyCode.S)
            {
                current.SelectDown();
            }
        }
    }
}
