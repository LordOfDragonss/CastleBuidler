using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ProceduralGenerationGameobjects))]
public class TWODPCGEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ProceduralGenerationGameobjects generator = (ProceduralGenerationGameobjects)target;
        if (GUILayout.Button("Generate"))
        {
            generator.Generate();
        }
    }
}
