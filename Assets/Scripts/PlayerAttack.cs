using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float damage = 10f;
    private bool attack;
    private Collider monster;
    private Animator anim;
    private AudioSource audio;
    private void Start()
    {
        anim = transform.parent.GetComponent<Animator>();
        audio = GetComponent<AudioSource>();


    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && attack && monster!=null && !PlayerHealth.death 
            && monster.GetComponent<EnemyHealth>().health>0)
        {
            monster.GetComponent<EnemyHealth>().takeDamage(damage);
            anim.SetTrigger("attack");
            audio.Play();
        }
           
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            attack = true;
            monster = other;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            attack = false;
            monster = null;
           
        }
    }

}
