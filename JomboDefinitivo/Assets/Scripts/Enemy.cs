using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour

{
    public GameObject John;

  
    private void Update()
    {
        Vector3 direction = John.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(5.41871786f, 4.87028313f, 1f);
        else transform.localScale = new Vector3(-5.41871786f, 4.87028313f, 1f);


    }


}
