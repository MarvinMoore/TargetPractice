using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    public GameObject target;
    private ObjectPool<GameObject> _pool;
    // Start is called before the first frame update
    void Start()
    {
        _pool = new ObjectPool<GameObject>(() => {
            return Instantiate(target, new Vector2(12, 2), Quaternion.identity);
        }, targetV => {
            targetV.gameObject.SetActive(true);
        }, targetV => {
            targetV.gameObject.SetActive(false);
        }, targetV => {
            Destroy(targetV.gameObject);
        }, false, 1, 1);
        SpawnTarget();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnTarget(){
       var targetV = _pool.Get(); //Instantiate(target, new Vector2(12, 2), Quaternion.identity);
    }
    public void KillTarget(GameObject target1) {
        Wait();
        _pool.Release(target1);
    }
    IEnumerator Wait(){
        yield return new WaitForSeconds(1.0f); //Wait a while before resetting slider value/force
    }
}
