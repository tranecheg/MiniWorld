using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elixirs : MonoBehaviour
{
    public GameObject btnNoDamage, btnSlowTime;
    [NonSerialized] public bool noDmg, slow;
    
    private void FixedUpdate()
    {
        if (slow && Time.timeScale > 0.4f)
        {
            Time.timeScale -= 0.005f;
            StartCoroutine(SlowTime());
        }
    }
    IEnumerator SlowTime()
    {
        yield return new WaitForSeconds(5f);
        Time.timeScale = 1f;
        slow = false;
    }
    public void setSlowTime()
    {
        slow = true;
        Destroy(btnSlowTime);
    }
    IEnumerator NoDamage()
    {
        noDmg = true;
        yield return new WaitForSeconds(5f);
        noDmg = false;
    }
    public void setNoDamage()
    {
        StartCoroutine(NoDamage());
        Destroy(btnNoDamage);
    }
   

}
