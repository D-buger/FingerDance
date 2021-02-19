using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NoteBase : MonoBehaviour
{
    static float delRange = 0.3f;

    protected Vector2 ori = Vector2.zero;
    protected Vector2 v3MovePos = Vector2.zero;
    protected float enemySpeed;

    protected bool isMoving = true;
    protected bool iscrash = false;

    protected virtual void OnEnable()
    {
        transform.position = ori;
    }

    protected virtual void Update()
    {
        moveNotes();
    }

    //해당 노트가 어떻게 움직일지
    protected abstract void moveNotes();

    //적 개체가 판정선에 닿았을 때 (게임오버판정)
    protected void del()
    {
        if(Vector2.Distance(v3MovePos, transform.position) <= delRange)
        {
            gameObject.SetActive(false);
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            gameObject.SetActive(false);
    }
}
