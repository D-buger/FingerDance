using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoteManager : MonoBehaviour
{
    public GameObject clearP;
    public GameObject failP;

    bool end = false;

    [SerializeField]
    GameObject[] notes = new GameObject[3];

    [SerializeField]
    public Transform trans;

    float t = 0;

    int seq = 0;
    List<Dictionary<string, object>> data;

    float x = 0, y = 0;


    float enemyR = 0;
    float playerR = 0;
    Vector3 v3MovePos = Vector3.zero;

    float check = 0;

    private void Awake()
    {
        data = CSVReader.Read("plane");
    }

    private void Start()
    {
        v3MovePos = GameManager.instance.v3MovePos;
        enemyR = GameManager.instance.enemyR;
        playerR = GameManager.instance.playerR;
    }

    private void Update()
    {
        t += Time.deltaTime;
        //Debug.Log(t);
        //Debug.Log(seq);
        //Debug.Log((float)data[seq]["Time"] % 60);
        check = (float)data[seq]["Time"];
        //Debug.Log(check);
        if ((float)data[seq]["Time"] < t && (int)data[seq]["Num"] == -1)
        {
            end = true;
            clearP.SetActive(true);
            GameManager.IsClear = true;
            StartCoroutine(wait());
        }
        if (t > check
            && !end)
        {
            madeNotes(seq);
            seq++;
        }

    }

    //public void del()
    //{
    //    failP.SetActive(true);
    //    end = true;
    //    StartCoroutine(wait());
    //}

    IEnumerator wait() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Stage");

        yield return null;
    }

    void madeNotes(int seq)
    {
        //Debug.Log("생성" + seq);
        drawCir(seq);
        //Debug.Log("시작"+trans.position);
        Instantiate(notes[(int)data[seq]["Num"]], trans.position, Quaternion.identity);
        //Debug.Log("끝" + trans.position);
    }

    void Random(int min, int max)
    {
    }

    void drawCir(int seq)
    {
        
        float fRadian = (float)data[seq]["Rotate"];
        //추가 시킨 각도의 Radian을 구한다
        float deRad = fRadian * Mathf.Deg2Rad;

        //Radian값으로 sin과 cos 값을 구한다.
        float sinValue = Mathf.Sin(deRad);
        float cosValue = Mathf.Cos(deRad);

        float insertR = 0;

        switch ((int)data[seq]["Where"])
        {
            case 1: insertR = enemyR; break;
            case 2: insertR = playerR + ((enemyR - playerR) / 2); break;
        }

        //반지름을 곱해 포인트 x,y값을 구한다
        y = sinValue * insertR;
        x = cosValue * insertR;

        //이동
        trans.position = new Vector3(x, y, 0) + v3MovePos;
        //Debug.Log(trans.position);
    }
}
