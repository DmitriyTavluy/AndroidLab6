using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSameColor : MonoBehaviour
{
    
    private bool firstOne;
 

    void OnCollisionEnter (Collision other)
    {
        if ( other.gameObject.tag == "Cube" && firstOne )
        {
           
            other.gameObject.GetComponent <MeshRenderer> ().material.color = GetComponent <MeshRenderer> ().material.color;
           // other.gameObject.GetComponent<Animation>().Play("DifferentPos");
            if (other.transform.position.y > -2.4)
            other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y - 0.1f, other.transform.position.z);

        }
        if (!firstOne)
        {
            firstOne = true;
        }
    }

    
}
