using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieEnemyHealth : MonoBehaviour
{
    public int _health;
    public Image healthbar;
    private int currenthalth;

    private void Start()
    {
        currenthalth = _health;
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Bullet"))
        {
            _health -= 100;

            UpdateHealth((float)_health/(float)currenthalth);
            if (_health <= 0)
            {
                Die();
                other.gameObject.SetActive(false);

            }
        }
    }
    

    void Die()
    {
        Destroy(gameObject);
    }
    public void UpdateHealth(float ff)
    {
        healthbar.fillAmount =ff;
    }
}
