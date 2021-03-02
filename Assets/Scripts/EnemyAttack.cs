using UnityEngine.AI;
using UnityEngine;
using System.Collections;
public class EnemyAttack : MonoBehaviour
{
    private NavMeshAgent agent;
    public float damage = 5f;
    private Coroutine dmg;
    private Animator anim;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (agent.enabled)

                agent.SetDestination(other.transform.parent.gameObject.transform.position);
        }  
        if (other.CompareTag("Attack"))
        {
            if(dmg==null)
            dmg = StartCoroutine(setDamage(other));
            anim.SetBool("isAttack", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<MoveAgents>().setNewPos();
        }
        if (other.CompareTag("Attack"))
        {
            StopCoroutine(dmg);
            anim.SetBool("isAttack", false);
            dmg = null;
        }
    }
    IEnumerator setDamage(Collider other)
    {
        while (true)
        {
            if (agent.enabled)
                other.transform.parent.GetComponent<PlayerHealth>().takeDamage(damage);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
