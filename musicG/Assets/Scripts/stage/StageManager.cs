using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager instance = null;

    public Vector3 v3MovePos = Vector3.zero; //원의 중심
    public float playerR = 2; //플레이어가 움직일 반지름

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
    }

    private void Update()
    {
    }

    //void OnDrawGizmos()
    //{
    //    UnityEditor.Handles.color = Color.green;
    //    UnityEditor.Handles.DrawWireDisc(v3MovePos, Vector3.forward, playerR);
    //}
}
