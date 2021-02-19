﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StageTouch : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject m;

   [SerializeField]
    public GameObject pad;

    public Vector3 v3MovePos = Vector3.zero;

    public bool firstRotate = true;
    public Vector3 mousePosTranOri = Vector3.zero;
    public Vector3 mousePosTran = Vector3.zero;

    public Vector3 mousePosOri = Vector3.zero;
    public Vector3 mousePos = Vector3.zero;

    public float saveR = 90;

    public float playerR = 0; //반지름

    public float y = 0;
    public float x = 0;

    public float moveR = 0f;

    private void Start()
    {
        v3MovePos = StageManager.instance.v3MovePos;
        playerR = StageManager.instance.playerR; //반지름
        saveR = 90;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        firstRotate = true;
        if (Input.GetMouseButton(0))
        {
            mousePosOri = Camera.main.ScreenToWorldPoint(
            new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            -Camera.main.transform.position.z)
            );
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        mousePos = Camera.main.ScreenToWorldPoint(
        new Vector3(
        Input.mousePosition.x,
        Input.mousePosition.y,
        -Camera.main.transform.position.z)
        );
        moveR = Mathf.Deg2Rad * saveR +
        Mathf.Atan2(mousePos.y - v3MovePos.y, mousePos.x - v3MovePos.x) -
        Mathf.Atan2(mousePosOri.y - v3MovePos.y, mousePosOri.x - v3MovePos.x);

        if (check() == 0)
        {
            move();
            rotate();
        }
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        mousePosTranOri = Vector3.zero;
        moveR = Mathf.Deg2Rad * saveR;
        pad.transform.Rotate(0, 0, 0);
        move();
    }

    public int check()
    {
        if(moveR >= 2.1)
        {
            //Debug.Log("왼쪽 넘었어");
            m.GetComponent<Scroll>().Left();
            return 1;
        }
        else if (moveR <= 1.0)
        {
            //Debug.Log("오른쪽 넘었어");
            m.GetComponent<Scroll>().Right();
            return 2;
        }
        else
        {
            return 0;
        }
    }

    public void rotate()
    {
    }

    public void move()
    {
        //추가 시킨 각도의 Radian을 구한다
        float deRad = moveR;

        //Radian값으로 sin과 cos 값을 구한다.
        float sinValue = Mathf.Sin(deRad);
        float cosValue = Mathf.Cos(deRad);

        //반지름을 곱해 포인트 x,y값을 구한다
        y = sinValue * playerR;
        x = cosValue * playerR;

        //이동
        pad.transform.localPosition = new Vector3(x, y, 0) + v3MovePos;

    }
}
