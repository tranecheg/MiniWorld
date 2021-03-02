using UnityEngine.AI;
using UnityEngine;

public class MoveAgents : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform[] positions;
    private Transform nowPos;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        setNewPos();
    }
    public void setNewPos()
    {
        Transform moveTo = positions[Random.Range(0, positions.Length)];
        
        if(nowPos!=null && nowPos.position == moveTo.position)
        {
            setNewPos();
            return;
        }

        nowPos = moveTo;
        if (agent.enabled)
            agent.SetDestination(moveTo.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dots"))
            setNewPos();
    }
}
