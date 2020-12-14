using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 3f;
    [SerializeField] float _moveSpeedUp = 3f;
    bool isGrounded;
    public Animator animate;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.InvokeDialogFinished();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void FixedUpdate()
    {
        isGrounded = false;
    }

    void Move()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * _moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        animate.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        if(Input.GetButtonDown("Jump") && isGrounded){
            GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * _moveSpeed, _moveSpeedUp);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
    }
}
