using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShot : MonoBehaviour
{
    public GameObject Arrow;
    public float shotTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Shot");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator Shot()
    {
        yield return new WaitForSeconds(shotTime);
        Instantiate(Arrow, this.transform);
        StartCoroutine("Shot");
    }
}
