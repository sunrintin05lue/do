using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laver : MonoBehaviour
{
    public ArrowShot arrowCont;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Deto()
    {
        Destroy(arrowCont.gameObject);
    }
}
