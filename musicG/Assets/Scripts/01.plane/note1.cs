using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class note1 : note
{
    float t = 0;

    [SerializeField]
    float delayT = 1;

    void Update()
    {
        //pos = transform.position;
        //SetR();

        moveNotes();
        del();
    }

    void moveNotes()
    {
        t += Time.deltaTime;
        if (isMoving && t >= delayT)
        {
            transform.position -= (ori - v3MovePos).normalized * Time.deltaTime * enemySpeed;
        }
    }
}
