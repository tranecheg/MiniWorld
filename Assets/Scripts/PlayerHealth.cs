using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public static bool death;
    private Rigidbody rb;
    private float force = 150f, forceTorque = 100f;
    public RectTransform healthBar;
    public GameObject gameController;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    public void takeDamage(float damage)
    {
        if (health <= 0 || gameController.GetComponent<Elixirs>().noDmg)
            return;
        
        health -= damage;
        setHealth();
        if (health <= 0 && !death) {
           
            death = true;
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(Vector3.up * force);
            rb.AddTorque(Vector3.back * forceTorque);
        }
    }
    public void setHealth()
    {
        healthBar.offsetMax = new Vector2(-1 * (230f * (100 - health) / 100), 0);
    }
}
