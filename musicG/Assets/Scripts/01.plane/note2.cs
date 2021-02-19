using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class note2 : note
{
    float playerR = 2;
    float enemyR = 3;

    float turnningP = 1;

    bool isTurn = false;

    new void Start()
    {
        ori = transform.position;
        v3MovePos = GameManager.instance.v3MovePos;

        playerR = GameManager.instance.playerR;
        enemyR = GameManager.instance.enemyR;

        turnningP = playerR + ((enemyR - playerR) / 2);
    }

    void Update()
    {
        //pos = transform.position;
        //SetR();

        moveNotes();
        del();
    }

    void moveNotes()
    {
            if (isMoving)
            {
                transform.position -= (ori - v3MovePos).normalized * Time.deltaTime * enemySpeed;

                if (Vector3.Distance(v3MovePos, transform.position) <= turnningP && !isTurn)
                {
                    transform.position = -transform.position;
                    ori = transform.position;
                    isTurn = true;
                }
            }
    }
}
