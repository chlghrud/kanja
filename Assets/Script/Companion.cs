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
            Debug.Log("cat ������");
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
            companionColleder.transform.position = new Vector2(catTransform.position.x - 1.7f, transform.position.y);
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
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision != null)
        {

            if (collision.collider.CompareTag("Ground"))
            {
                fadeOut();
                if (cat != null)
                    cat.Swap();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            
            ContactPoint2D contac = collision.contacts[0]; // ù��° �浹�� ��������
            if (contac.normal == Vector2.up && collision.contacts.Length <= 4) // contac.normal <- ù��° �浹���� �������͸� ������ͼ� ���� ���Ⱑ �����̸� == ������ ��Ȯ�� �������ϸ� fadeOut ��������
                return;
            if (collision.collider.CompareTag("Ground"))
            {
                fadeOut();
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
