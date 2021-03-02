using UnityEngine.AI;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;
    public bool death;
    private Rigidbody rb;
    private float force = 150f, forceTorque = 100f;
    public Transform healthBar;
    public GameObject[] mummyParts;
    public Color matColor;
    private AudioSource audio;
    public bool canHeal = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        if(healthBar!=null)
        healthBar.localScale = new Vector3(health / 100, 0.1f ,0.1f);
        if (health <= 0 && !death)
        {
            Destroy(healthBar.gameObject);
            death = true;
            audio.Play();
            setNewColor(matColor);

            foreach (GameObject obj in mummyParts) {
                obj.GetComponent<SkinnedMeshRenderer>().material.color = matColor;
            }

            GetComponent<Animator>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(Vector3.up * force);
            rb.AddTorque(Vector3.back * forceTorque);
            
        }
    }
    public void setNewColor(Color color)
    {
        foreach (GameObject obj in mummyParts)
        {
            obj.GetComponent<SkinnedMeshRenderer>().material.color = color;
        }
    }

}
