using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoteManager : MonoBehaviour
{
    [SerializeField]
    string csvName;

    [SerializeField]
    private GameObject clearP;
    [SerializeField]
    private GameObject failP;

    private bool end = false;
    
    [SerializeField]
    GameObject[] notes = new GameObject[3];

    Dictionary<GameObject, List<GameObject>> noteList;

    [SerializeField]
    private int poolingAmount;

    [SerializeField]
    public Transform trans;

    float t = 0;

    int seq = 0;
    List<Dictionary<string, object>> data;

    float x = 0, y = 0;

    [SerializeField]
    float enemyR = 3;
    [SerializeField]
    float playerR = 2;
    [SerializeField]
    Vector3 v3MovePos = Vector3.zero;

    float check = 0;

    private void Awake()
    {
        noteList = new Dictionary<GameObject, List<GameObject>>();
        data = CSVReader.Read(csvName);
        for(int i = 0; i < notes.Length; i++)
        {
            InstantiatePrefabs(notes[i]);
        }
    }

    private void InstantiatePrefabs(GameObject prefab)
    {
        List<GameObject> list = new List<GameObject>();
        GameObject obj;

        for (int i = 0; i < poolingAmount; i++)
        {
            obj = Instantiate(prefab, prefab.transform);
            obj.SetActive(false);
            list.Add(obj);
        }

        noteList.Add(prefab, list);
    }

    private void Update()
    {
        t += Time.deltaTime;
        check = (float)data[seq]["Time"];
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

    IEnumerator wait() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Stage");

        yield return null;
    }

    List<GameObject> dictionaryList;
    void madeNotes(int seq)
    {
        dictionaryList = new List<GameObject>();
        GameObject obj = null;

        if (noteList.ContainsKey(notes[seq]))
        {
            noteList.TryGetValue(notes[seq], out dictionaryList);
            if (dictionaryList.Count != 0)
            {
                obj = dictionaryList[0];
                obj.transform.position = drawCir(seq);
                //회전구현해야함
                obj.SetActive(true);


                dictionaryList.Remove(obj);
            }
        }
    }

    void Random(int min, int max)
    {
    }

    Vector2 drawCir(int seq)
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

        return trans.position;
    }
}
