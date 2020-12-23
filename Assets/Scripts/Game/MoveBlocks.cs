using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlocks : MonoBehaviour
{
    private bool moved = true;
    private Vector3 target;
   
    void Start()
    {
        target = new Vector3(0f, 0f, 0f);
        
    }

   
    void Update()
    {
        if (CubeJump.nextBlock)
        {
            if (transform.position != target)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 5f);
            }
            else if (transform.position == target && !moved)
            {
                target = new Vector3(transform.position.x - 2.3f, transform.position.y + 3.2f, transform.position.z);
                CubeJump.jump = false;
                moved = true;

            }

            if (CubeJump.jump)
                moved = false;
        }
    }
}
