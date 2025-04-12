using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float Speed;
    public float JumpForce;
    private bool Grounded;

    private float Horizontal;
    private Animator Animator;
    private Rigidbody2D rigiBodyPlayer;

    [SerializeField] private AudioClip saltoSonido;

    // Start is called before the first frame update
    void Start()
    {
        rigiBodyPlayer = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }



// Update is called once per frame
    void Update()
    {
    Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3 (-9.36361694f, 9.48618889f, 1.0f); 
        else if (Horizontal > 0.0f) transform.localScale = new Vector3 (9.36361694f, 9.48618889f, 1.0f);
        
        Animator.SetBool("running", Horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.3f, Color.red);

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.3f))
        {
            Grounded = true;
        }
        else Grounded = false;

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Jump()
    {
        rigiBodyPlayer.AddForce(Vector2.up * JumpForce);
        AudioController.Instance.EjecutarSonido(saltoSonido);
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        
    }

    private void FixedUpdate()
    {
        rigiBodyPlayer.velocity = new Vector2(Horizontal, rigiBodyPlayer.velocity.y);
    }

}

