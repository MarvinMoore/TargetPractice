using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAchievement : MonoBehaviour
{
    //General Variables
    public GameObject achNote;
    public AudioSource achSound;
    public bool achActive = false;
    public GameObject achTitle;
    public GameObject achText;

    //Achievement 01 Specific
    public GameObject ach01Image;
    public static int ach01Count;
    public int ach01Trigger = 10;
    public int ach01Code;

    // Update is called once per frame
    void Update()
    {
       //ach01Code = PlayerPrefs.GetInt("Ach01");
       //Debug.Log(ach01Code.ToString());
     //Observer Pattern - Listen for ach01Count
     if (ach01Count == ach01Trigger){// && ach01Code != 12345){
        StartCoroutine(Trigger01Ach());
     }   
    }

    IEnumerator Trigger01Ach()
    {
        achActive = true;
        ach01Code = 12345;
        PlayerPrefs.SetInt("Ach01", ach01Code);
        achSound.Play();
        ach01Image.SetActive(true);
        achTitle.GetComponent<Text>().text = "ACHIEVEMENT UNLOCKED!";
        achText.GetComponent<Text>().text = "Reached a score of 10!";
        achNote.SetActive(true);
        yield return new WaitForSeconds(7);
        //Resetting UI
        achNote.SetActive(false);
        ach01Image.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achText.GetComponent<Text>().text = "";
        achActive = false;
    }
}
