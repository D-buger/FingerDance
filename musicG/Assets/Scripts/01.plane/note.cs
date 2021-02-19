using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class note : MonoBehaviour
{
    //Vector3 pos = Vector3.zero;
    protected Vector3 ori = Vector3.zero;

    protected Vector3 v3MovePos = Vector3.zero;

    [SerializeField]
    protected  float enemySpeed = 1;

    protected bool isMoving = true;

    protected bool iscrash = false;

    //float fRadian = 1;
    //float y = 0;
    //float x = 0;

    //float Rad = 0;

    protected void Awake()
    {
        //SetR();
        ori = transform.position;
        v3MovePos = GameManager.instance.v3MovePos;
    }

    protected void Update()
    {
        //pos = transform.position;
        //SetR();

        moveNotes();
        del();
    }

    //void SetR()
    //{
    //    Rad = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
    //}

    void moveNotes()
    {
        if(isMoving)
            transform.position -= (ori - v3MovePos).normalized * Time.deltaTime * enemySpeed;
    }

    protected void del()
    {
        if (Vector3.Distance(v3MovePos, transform.position) <= 0.3)
        {
            Debug.Log("너죽");
            Destroy(gameObject);
            SceneManager.LoadScene("Stage");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Destroy(gameObject);
    }
}
