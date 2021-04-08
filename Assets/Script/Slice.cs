using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice : MonoBehaviour {

    [SerializeField]
    private Transform gameobjSlice = null;

    [SerializeField]
    private ParticleSystem particleSlice = null;

    public static Vector2 vec2Direction;
    public static float floatDistace;



    private Vector2 vec2StartPos,vec2EndPos;

    private Vector2 screenPoint;
    private Vector2 offset;


    float floatCheckMove;

    void FixedUpdate () {
        //mouse input
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 touchPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            particleSlice.Play();
            vec2StartPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 cursorPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            cursorPoint = Camera.main.ScreenToWorldPoint(cursorPoint);
            gameobjSlice.position = cursorPoint;
            if (floatCheckMove < 5)
            {
                floatCheckMove += 1 * Time.deltaTime;
            }
            else if (floatCheckMove >= 5 ) {
                
            }


        }
        else if (Input.GetMouseButtonUp(0)) {
            particleSlice.Stop();
        }

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Knife") )
        {
            vec2EndPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            floatDistace = Vector2.Distance(vec2StartPos, vec2EndPos);
            vec2Direction = vec2EndPos - vec2StartPos;
        }
    }
}
