using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerpush : MonoBehaviour
{
    public float distance = 1f;
    public LayerMask boxMask;

    GameObject box;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Push or pull objects
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

        //Push object
        if(hit.collider != null && hit.collider.gameObject.tag=="pushable" && Input.GetKeyDown(KeyCode.E))
        {
            box = hit.collider.gameObject;
            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<boxpull>().beingPushed = true;
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }
        //Pull object
        else if (Input.GetKeyUp(KeyCode.E))
        {
            box.GetComponent<FixedJoint2D>().enabled = false;
            box.GetComponent<boxpull>().beingPushed = false;
        }
    }

    //Yellow Line on player to show direction
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }
}
