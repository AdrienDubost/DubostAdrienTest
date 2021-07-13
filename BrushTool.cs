using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class BrushTool : EditorWindow
{
    #region Variables 

    private string MainTitle = "Map Editor";
    private string PrefabSection = "Prefab Section";
    private string SizeSection = "Size Section";
    private string RotationSection = "Rotation Section";

    private GameObject GameObject1;
    private GameObject GameObject2;
    private GameObject GameObject3;
    private GameObject GameObject4;

    private GameObject CurrentObject;
    private string[] PrefabList = {"Départ","Horizontal","Vertical","Arrivée" };
    private int PrefabIndex; 
    
   
    #endregion

    #region Creation de le fenêtre du Tool 

    [MenuItem("MyTools/LevelDesign/BrushTool")]
    public static void ShowWindow()
    {
        GetWindow(typeof(BrushTool));
    }
    #endregion

    private void OnGUI()s
    {

        EditorGUILayout.LabelField(MainTitle); 
        EditorGUILayout.Space(15);
        EditorGUILayout.LabelField(PrefabSection);
        EditorGUILayout.Space(8);
        PrefabIndex = EditorGUILayout.Popup(new GUIContent("Prefab"), PrefabIndex, PrefabList);
        EditorGUILayout.Space(15); 
        GameObject1 = (GameObject)EditorGUILayout.ObjectField(new GUIContent("Cube de départ"), GameObject1, typeof(GameObject), false);
        EditorGUILayout.Space(5); 
        GameObject2 = (GameObject)EditorGUILayout.ObjectField(new GUIContent("Cube Mouvant H"), GameObject2, typeof(GameObject), false);
        EditorGUILayout.Space(5);
        GameObject3 = (GameObject)EditorGUILayout.ObjectField(new GUIContent("Cube Mouvant V"), GameObject3, typeof(GameObject), false);
        EditorGUILayout.Space(5);
        GameObject4 = (GameObject)EditorGUILayout.ObjectField(new GUIContent("Cube d'arrivée"), GameObject4, typeof(GameObject), false);

        if (Event.current.keyCode == KeyCode.A && Event.current.type == EventType.KeyUp)
        {
            if(PrefabIndex == 0)
            {
                CurrentObject = GameObject1; 
            }
            else if (PrefabIndex == 1)
            {
                CurrentObject = GameObject2; 
            }
            else if (PrefabIndex == 2)
            {
                CurrentObject = GameObject3; 
            }
            else if (PrefabIndex == 3)
            {
                CurrentObject = GameObject4;
            }

            Vector3 TmpMousePosition = Event.current.mousePosition + position.position - SceneView.lastActiveSceneView.position.position; 
            TmpMousePosition /= SceneView.lastActiveSceneView.position.size;
            TmpMousePosition.z = 1;
            TmpMousePosition.y = 1 - TmpMousePosition.y;
            Ray TmpRay = SceneView.lastActiveSceneView.camera.ViewportPointToRay(TmpMousePosition); 
            if(Physics.Raycast(TmpRay, out RaycastHit TmpHit))
            {
                if(TmpHit.collider != null)
                {
                    Vector3 TilesPosition = TmpHit.collider.transform.position;
                    Vector3 NextTilePosition = Vector3.zero;
                    NextTilePosition = TilesPosition + TmpHit.normal * TmpHit.collider.transform.localScale.x;
                    Instantiate(CurrentObject, NextTilePosition, CurrentObject.transform.rotation, TmpHit.collider.transform.parent); 
                }
            }
            else
            {
                Debug.Log("TVous ne pouvez pas poser de cubes Ici"); 
            }
        }
    }
}


