using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag=="Ground")
        {
            Destroy(this.gameObject);
        }
    }
}
