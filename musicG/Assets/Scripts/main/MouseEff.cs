using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEff : MonoBehaviour
{
    public GameObject pracPraf;

    float spawnT;
    public float defaultT = 0.05f;

    private void Update()
    {
        if (Input.GetMouseButton(0) && spawnT >= defaultT )
        {
            StarCreate();
            spawnT = 0;
        }
        spawnT += Time.deltaTime;
    }

    void StarCreate()
    {
        Vector3 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mPos.z = 0;

        Instantiate(pracPraf, mPos, Quaternion.identity);
    }
}
