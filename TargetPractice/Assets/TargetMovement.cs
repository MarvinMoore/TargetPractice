using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public float speed;
    public bool movingUp = true;
    public bool movingDown = false;
    Spawner spawn;
    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("TargetSpawner").GetComponent<Spawner>();
    }
    // Update is called once per frame
    void Update()
    {
        if (movingUp) {
            transform.Translate(0, Time.deltaTime * speed, 0, Space.World);
        }
        if (movingDown) {
            transform.Translate(0, Time.deltaTime * -1 * speed, 0, Space.World);
        }
    }

    void OnTriggerEnter2D(Collider2D trig){
        if(trig.gameObject.CompareTag("Arrow")){
            movingUp = false;
            movingDown = false;
            Debug.Log("collision detected!");
            gameObject.SetActive(false);
            spawn.SpawnTarget();
            Destroy(gameObject);
        }
        if(trig.gameObject.CompareTag("TopThreshold")){
            movingDown = true;
            movingUp = false;
        } 
        if(trig.gameObject.CompareTag("BottomThreshold")){
            movingUp = true;
            movingDown = false;
        }
    }
}
