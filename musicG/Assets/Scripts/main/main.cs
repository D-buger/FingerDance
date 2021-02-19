using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class main : MonoBehaviour
{
    public static main instance = null;
    [SerializeField]
    public Vector3 v3MovePos = Vector3.zero; //원의 중심
    [SerializeField]
    public float playerR = 2; //플레이어가 움직일 반지름

    private void Awake()
    {
        instance = this;
    }

    //void OnDrawGizmos()
    //{
    //    UnityEditor.Handles.color = Color.red;
    //    UnityEditor.Handles.DrawWireDisc(v3MovePos, Vector3.forward, playerR);
    //}
}
