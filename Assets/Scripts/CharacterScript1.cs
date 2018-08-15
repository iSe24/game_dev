using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript1 : MonoBehaviour {
    Rigidbody2D rigid2D;
    bool facingLeft = false;
    Animator anim;

    
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rigid2D = GetComponent<Rigidbody2D>();
        
    }
	
	// Update is called once per frame
	void Update () {
            if (Input.GetKeyDown(KeyCode.Space))
            {

            
            Debug.Log("Detected a keyboard event!");
            }
            
            float move = Input.GetAxis("Horizontal");
            rigid2D.velocity = new Vector3(move * 2f, rigid2D.velocity.y);
            //set our speed
            anim.SetFloat("Speed", Mathf.Abs(move));


            if (move < 0 && !facingLeft)
            {

                Flip();
            }
            else if (move > 0 && facingLeft)
            {
                Flip();
            }
        
    }
    void FixedUpdate()
    {

        
    }
    //flip if needed
    void Flip()
    {
        facingLeft = !facingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void SayFuck()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("leaveLvl"))
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
}
