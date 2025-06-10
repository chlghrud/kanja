using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : MonoBehaviour
{

    private SpriteRenderer spriter;
    public Transform cat;
    void Start()
    {
        spriter = GetComponent<SpriteRenderer>();
    }

   
    void Update()
    {
        
    }
    public void fadeIn(bool isLeft)
    {
        spriter.flipX = isLeft;
        if (isLeft)
        {
            transform.position = new Vector2(cat.position.x - 1.7f, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(cat.position.x + 1.7f, transform.position.y);
        }
        Color c = spriter.color;
        c.a = 1f;
        spriter.color = c;
    }
    public void fadeOut()
    {
        Color c = spriter.color;
        c.a = 0f;
        spriter.color = c;
    }
}
