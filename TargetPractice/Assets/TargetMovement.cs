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
        if ((movingUp == false) && (movingDown == false))
            movingUp = true;
    }

    void OnTriggerEnter2D(Collider2D trig){
        if(trig.gameObject.CompareTag("Arrow")){
            //gameObject.SetActive(false);
            movingUp = false;
            movingDown = false;
            Debug.Log("collision detected!");
            spawn.KillTarget(gameObject);
            spawn.SpawnTarget();
            ScoreManager.instance.changeScore(1);
             //Wait 2 seconds before spawning another target
           // movingUp = true;
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
    IEnumerator Wait(){
        yield return new WaitForSeconds(2.0f); //Wait a while before resetting slider value/force
    }
}
