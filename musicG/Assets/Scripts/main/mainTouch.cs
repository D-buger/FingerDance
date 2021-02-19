using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class mainTouch : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    public GameObject pad;

    [SerializeField]
    public GameObject bubble1;
    [SerializeField]
    public GameObject bubble2;

    [SerializeField]
    Animator animator;
    [SerializeField]
    Animator animator1;

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
        v3MovePos = main.instance.v3MovePos;
        playerR = main.instance.playerR; //반지름
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
        Mathf.Atan2(mousePos.y - v3MovePos.y, mousePos.x - v3MovePos.x)-
        Mathf.Atan2(mousePosOri.y - v3MovePos.y, mousePosOri.x - v3MovePos.x);

        if (check() == 0)
        {
            move();
            rotate();
        }
        else{

        }
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        switch (check())
        {
            case 0:

                break;
            case 1:

                moveR = 2.9f;
                move();
                AudioSource S1 = bubble1.GetComponent<AudioSource>();
                S1.Play();
                animator.SetTrigger("isSelect");
                StartCoroutine("delay");
                break;
            case 2:

                AudioSource S2 = bubble2.GetComponent<AudioSource>();
                S2.Play();
                animator1.SetTrigger("isSelectE");
                Application.Quit();
                break;
        }
        mousePosTranOri = Vector3.zero;
        moveR = Mathf.Deg2Rad* saveR;
        pad.transform.rotation = Quaternion.Euler(0,0,90);
        move();
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Stage");
        yield return null;
    }

    int check()
    {
        if (moveR >= 2.9 || moveR <= -1.5)
        {
            return 1;
        }
        else if (moveR <= 0.23 )
        {
            return 2;
        }
        else
        {
            return 0;
        }
    }


    public void rotate()
    {
        if (mousePosTranOri == Vector3.zero)
            mousePosTranOri = mousePosOri;
        else
            mousePosTranOri = mousePosTran;

        mousePosTran = mousePos;
        
        pad.transform.Rotate(0, 0,
            Mathf.Atan2(mousePosTran.y, mousePosTran.x) * Mathf.Rad2Deg-
            Mathf.Atan2(mousePosTranOri.y, mousePosTranOri.x) * Mathf.Rad2Deg
        );

        firstRotate = false;

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
