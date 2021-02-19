using UnityEngine;
using System.Collections.Generic;
using System.Collections;

using UnityEngine.UI;

public class Scroll : MonoBehaviour
{
    [SerializeField]
    RectTransform List;

    public int count;
    private float pos;
    private float movepos;

    private bool IsScroll = false;
    private bool Resize = false;

    int or = 0;

    public LayoutElement comp;
    public HorizontalLayoutGroup lis;

    // Use this for initialization
    void Start()
    {
        pos = List.localPosition.x;
        movepos = List.rect.xMax - comp.minWidth - comp.minWidth / 2 - lis.spacing;
        
        List.GetChild(or).localScale = new Vector2(1.2f, 1.2f);
        List.GetChild(or).GetChild(0).localScale = new Vector2(2,2);
        List.GetChild(or - 1).GetComponent<Button>().interactable = false;
        List.GetChild(or + 1).GetComponent<Button>().interactable = false;
    }

    public void Right()
    {
        if (or < List.transform.childCount - 1)
        {
            IsScroll = true;
            movepos = pos - comp.minWidth - lis.spacing;
            pos = movepos;
            or += 1;
            Debug.Log(or);
            StartCoroutine(scroll());
        }
    }

    public void Left()
    {
        if (or > 0)
        {
            IsScroll = true;
            movepos = pos + comp.minWidth + lis.spacing;
            pos = movepos;
            or -= 1;
            Debug.Log(or);
            StartCoroutine(scroll());
        }
    }

    IEnumerator scroll()
    {
        List.GetChild(or).localScale = new Vector2(1.2f, 1.2f);
        List.GetChild(or).GetChild(0).localScale = new Vector2(2,2);
        List.GetChild(or).GetComponent<Button>().interactable = true;
        if (or - 1 >= 0)
        {
            List.GetChild(or - 1).localScale = new Vector2(1, 1);
            List.GetChild(or - 1).GetChild(0).localScale = new Vector2(1,1);
            List.GetChild(or - 1).GetComponent<Button>().interactable = false;
        }
        if (or + 1 < List.transform.childCount)
        {
            List.GetChild(or + 1).localScale = new Vector2(1, 1);
            List.GetChild(or + 1).GetChild(0).localScale = new Vector2(1, 1);
            List.GetChild(or + 1).GetComponent<Button>().interactable = false;
        }
        while (IsScroll)
        {
            List.localPosition = Vector2.Lerp(List.localPosition, new Vector2(movepos, 0), Time.deltaTime * 5);
            if (Vector2.Distance(List.localPosition, new Vector2(movepos, 0)) < 0.1f)
            {
                IsScroll = false;
            }
            yield return null;
        }
    }
}

//    IEnumerator scrollEffect(Transform tran, bool hTAc)
//    {
//        Resize = true;
//        float T = 0;
//        while (Resize && hTAc)
//        {
//            T += Time.deltaTime;
//             tran.localScale = Vector2.Lerp(List.localScale, new Vector2(1.5f, 1.5f), Time.deltaTime);
//            Debug.Log(T);
//             if (T > 5)
//                Resize = false;
//        }
//        while (Resize && !hTAc)
//        {
//            T += Time.deltaTime;
//            Debug.Log(T);
//            tran.localScale = Vector2.Lerp(List.localScale, new Vector2(0.5f, 0.5f), Time.deltaTime);
//            if (T > 5)
//                Resize = false;
//        }
//        yield return null;
//    }
//}
