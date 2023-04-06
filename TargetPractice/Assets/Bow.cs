using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bow : MonoBehaviour
{
    public GameObject arrow;
    public float launchForce;
    public Transform shotPoint;
    public Slider forceUI;
    public Text text;
    int score = 0;
    public AudioSource audioSource;
    public AudioClip pop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void IncrementScore(){
        score = score + 1;
        Debug.Log("newScore:"+score);
        text.text = score.ToString();
    }
    void Update()
    {
       Vector2 bowPosition = transform.position;
       Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
       Vector2 direction = mousePosition - bowPosition;
       transform.right = direction;

       if (Input.GetMouseButton(0))
        {
            launchForce++;
            slider();
            if (launchForce > 100){
                ResetGuage();
            }
        }
        if (Input.GetMouseButtonUp(0)){
            Shoot();
            StartCoroutine(Wait());
       }
        void Shoot() {
            GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
            newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * (launchForce/4);
        }
    }
    public void slider()
    {
        forceUI.value = launchForce;
    }
    public void ResetGuage()
    {
        launchForce = 0;
        forceUI.value = 0;
    }
    public void getSound(){
        audioSource.PlayOneShot(pop);
    }
    IEnumerator Wait(){
        yield return new WaitForSeconds(1.5f); //Wait a while before resetting slider value/force
        ResetGuage(); //Reset slider/force after shooting
    }
}
