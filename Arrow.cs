using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Destros");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Speed * Vector3.up * Time.deltaTime;
    }

    IEnumerator Destros()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
