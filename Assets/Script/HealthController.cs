using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float maxHealt = 10f;
    private float Health;

    void Start()
    {
        Health = maxHealt;
    }
    public void Damage(float f)
    {
        Health = Mathf.Clamp(Health - f, 0, maxHealt);
        Debug.Log("타격\n   남은 생명" + Health);
        if(Health == 0)
        {
            Dath();
        }
    }

    private void Dath()
    {
        Debug.Log("사망");
    }

    void Update()
    {
        
    }
}
