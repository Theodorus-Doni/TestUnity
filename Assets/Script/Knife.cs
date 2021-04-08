using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {

    //false stop move
    bool boolCheckMove;

    private Rigidbody2D rigidThis;

    bool checkColl;

    void Start () {
        rigidThis = GetComponent<Rigidbody2D>();
        boolCheckMove = true;
        transform.right = new Vector3(0,0,0) - transform.position;
	}

    private void FixedUpdate()
    {
        if (boolCheckMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 0), 5 * Time.deltaTime);
        }
        
    }

 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Touch") && !checkColl)
        {
            checkColl = true;
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(0.01f);
        rigidThis.AddForce(Slice.vec2Direction * 10f,ForceMode2D.Force );
        rigidThis.AddTorque(500, ForceMode2D.Force);
        boolCheckMove = false;
    }
}

