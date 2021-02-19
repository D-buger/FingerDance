using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    public static bool IsClear = false;

    [SerializeField]
    public float fSpeed = 5; //얼마나 움직이는지 (각도)
    [SerializeField]
    public Vector3 v3MovePos = Vector3.zero; //원의 중심
    [SerializeField]
    public float playerR = 2; //플레이어가 움직일 반지름

    [SerializeField]
    public float enemyR = 3;

    private void Awake()
    {
        instance = this;

    }

    private void Start()
    {
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
