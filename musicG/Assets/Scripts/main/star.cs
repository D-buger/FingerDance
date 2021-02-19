using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star : MonoBehaviour
{
    SpriteRenderer sprite;

    Vector2 dir;
    public float moveSpeed = 0.1f;

    public float minS = 0.1f;
    public float maxS = 0.3f;

    public float sizeSp = 1;
    public float colorsp = 1;

    public Color[] colors;


    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        //dir = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        float size = Random.Range(minS,maxS);
        transform.localScale = new Vector2(size, size);

        sprite.color = colors[Random.Range(0, colors.Length)];
    }

    private void Update()
    {
        //transform.Translate(dir * moveSpeed);
        //transform.localScale = Vector2.Lerp(transform.localScale, Vector2.zero, Time.deltaTime * sizeSp);

        Color color = sprite.color;
        color.a = Mathf.Lerp(sprite.color.a, 0, Time.deltaTime * colorsp);

        sprite.color = color;

        if (sprite.color.a <= 0.3f)
            Destroy(gameObject);
    }
}
