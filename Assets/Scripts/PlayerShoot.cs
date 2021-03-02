using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private float damage = 5f;
    public LayerMask mask;
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, 20f, mask))
            {
                EnemyHealth enemy = hit.transform.gameObject.GetComponent<EnemyHealth>();
                    if (enemy.health>0)
                        enemy.takeDamage(damage);
            }
                
        
        
    }
}
