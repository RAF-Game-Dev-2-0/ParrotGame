using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemySpawner))]
public class EnemySpawnerEditor : Editor
{
    public override void OnInspectorGUI(){

        base.OnInspectorGUI();
        serializedObject.Update();

        EnemySpawner script = (EnemySpawner)target;

        // EditorGUILayout.IntField("Repeat Spawn After", script.repeatSpawnAfter);
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("locations"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("enemies"));
        for(int i = 0; i < script.reSpawn.Count; i++){
            script.reSpawn[i] = false;
        }

        EditorGUILayout.EndHorizontal();
        serializedObject.ApplyModifiedProperties();
    }


}
