using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVidaController : MonoBehaviour
{
    public static PlayerVidaController instance;

    public int currentHealth, maxiHealth;

    private void Awake()
    {
        instance = this;
    }
   
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxiHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage()
    {
        currentHealth --;

        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
