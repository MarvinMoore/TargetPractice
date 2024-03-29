using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{   
    Rigidbody2D rb;
    bool hasHit;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Awake(){
    }
    void Update()
    {
        if (hasHit == false){
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("MovingTarget")){
            Debug.Log("Arrow Detected Collision");
            Destroy(gameObject);
        }
        hasHit = true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
    }
    IEnumerator Wait(){
        yield return new WaitForSeconds(1.0f); //Wait a while before resetting slider value/force
    }
}
