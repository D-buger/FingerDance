using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    public static bool IsClear = false;

    private void Awake()
    {
        instance = this;

    }

    //void OnDrawGizmos()
    //{
    //    UnityEditor.Handles.color = Color.red;
    //    UnityEditor.Handles.DrawWireDisc(v3MovePos, Vector3.forward, playerR);


    //    UnityEditor.Handles.color = Color.green;
    //    UnityEditor.Handles.DrawWireDisc(v3MovePos, Vector3.forward, enemyR);


    //    UnityEditor.Handles.color = Color.blue;
    //    UnityEditor.Handles.DrawWireDisc(v3MovePos, Vector3.forward, playerR + ((enemyR- playerR)/2));
    //}
}
