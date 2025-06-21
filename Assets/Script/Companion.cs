using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Companion : MonoBehaviour
{
    public Transform catTransform;
    public CatMove cat;

    private SpriteRenderer spriter;
    private Collider2D companionColleder;
    internal Coroutine currentCoroutine;

    void Start()
    {
        spriter = GetComponent<SpriteRenderer>();
        companionColleder = GetComponent<Collider2D>();
        if(cat == null || catTransform == null)
        {
            Debug.Log("cat 비여있음");
        }
    }

   
    void Update()
    {
        
    }
    public IEnumerator fadeIn(bool isLeft)
    {
        spriter.flipX = isLeft;
        companionColleder.enabled = true;
        if (isLeft)
        {
            transform.position = new Vector2(catTransform.position.x - 1.7f, transform.position.y);
        }
        else
        {
            companionColleder.transform.position = new Vector2(catTransform.position.x - 1.7f, transform.position.y);
            transform.position = new Vector2(catTransform.position.x + 1.7f, transform.position.y);
        }
        Color c = spriter.color;
        while (c.a < 1f)
        {
            c.a += 0.1f;
            spriter.color = c;
            yield return new WaitForSeconds(0.02f);
        }
    }
    public void StartMyCoroutine(Func<IEnumerator> coroutineFunc)
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
            currentCoroutine = null;
        }

        currentCoroutine = StartCoroutine(coroutineFunc());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {

            ContactPoint2D contac = collision.contacts[0]; // 첫번째 충돌면 가저오기
            if (contac.normal == Vector2.up)  // contac.normal <- 첫번째 충돌면의 법선백터를 가지고와서 만약 기울기가 수직이면 == 점프뒤 정확한 착지를하면 fadeOut 하지않음
                return;
            if (collision.collider.CompareTag("Ground"))
            {
                StartMyCoroutine(() => fadeOut());
                if (cat != null)
                    cat.Swap();
            }
        }
    }
    public IEnumerator fadeOut()
    {
        companionColleder.enabled = false;
        Color c = spriter.color;
        while (c.a > 0f)
        {
            c.a -= 0.1f;
            spriter.color = c;
            yield return new WaitForSeconds(0.02f);
        }
        
    }
}
