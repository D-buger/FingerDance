using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class note : NoteBase
{
    protected override void moveNotes()
    {
        Vector2 transformPos = new Vector2(transform.position.x, transform.position.y);

        if (isMoving)
            transformPos -= (ori - v3MovePos).normalized * Time.deltaTime * enemySpeed;
    }
}
