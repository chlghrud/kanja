using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : MonoBehaviour
{

    public Transform cat;
    public Cat catt;
    private SpriteRenderer spriter;
    private Collider2D companionColleder;
    void Start()
    {
        spriter = GetComponent<SpriteRenderer>();
        companionColleder = GetComponent<Collider2D>();
    }

   
    void Update()
    {
        
    }
    public void fadeIn(bool isLeft)
    {
        spriter.flipX = isLeft;
        companionColleder.enabled = true;
        if (isLeft)
        {
            companionColleder.transform.position = new Vector2(cat.position.x - 1.7f, transform.position.y);
            transform.position = new Vector2(cat.position.x - 1.7f, transform.position.y);
        }
        else
        {
            companionColleder.transform.position = new Vector2(cat.position.x - 1.7f, transform.position.y);
            transform.position = new Vector2(cat.position.x + 1.7f, transform.position.y);
        }
        Color c = spriter.color;
        c.a = 1f;
        spriter.color = c;
    }
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
           
            if (collision.CompareTag("Ground"))
            {
                Debug.Log("Ãæµ¹");
                fadeOut();
                if(catt != null)
                    catt.Swap();
            }
        }
    }
    public void fadeOut()
    {
        companionColleder.enabled = false;
        Color c = spriter.color;
        c.a = 0f;
        spriter.color = c;
    }
}
