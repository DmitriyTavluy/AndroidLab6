using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour
{
    public GameObject block, startBlock, allCubes;
    private GameObject blockInst, blockInstStart;
    private Vector3 blockPos, blockPosStart;
    private float speed = 5f;
    private bool onPlase;

    void Start()
    {
        
        blockPosStart = new Vector3(-1.29f, 1.55f, -0.3f);
        blockInstStart = Instantiate(startBlock, new Vector3(-5f, -1.5f, -0.3f), Quaternion.identity) as GameObject;
        blockInstStart.transform.parent = allCubes.transform;

        spawn();

    }

    void Update()
    {
        if (blockInstStart.transform.position != blockPosStart && !onPlase)
        {
            blockInstStart.transform.position = Vector3.MoveTowards(blockInstStart.transform.position, blockPosStart, Time.deltaTime * speed);
        } else if (blockInst.transform.position == blockPos)
            onPlase = true;


        if (blockInst.transform.position != blockPos && !onPlase)
        {
            blockInst.transform.position = Vector3.MoveTowards(blockInst.transform.position, blockPos, Time.deltaTime * speed);
        } else if (blockInst.transform.position == blockPos)
            onPlase = true;

        if (CubeJump.jump && CubeJump.nextBlock)
        {
            blockPosStart = new Vector3(-1.68f, 20f, -0.3f);
            blockInstStart = Instantiate(startBlock, new Vector3(-5f, -1.5f, -0.3f), Quaternion.identity) as GameObject;
            blockInstStart.transform.parent = allCubes.transform;
            spawn();
            onPlase = false;
        }
    }

    float RandScale()
    {
        float rand;
        if (Random.Range(0, 100) > 80)
            rand = Random.Range(1.2f, 2f);
        else
            rand = Random.Range(1.2f, 1.5f);
        return rand;
    }
    void spawn()
    {
        blockPos = new Vector3(/*Random.Range(0.7f, 1.3f)*/0.8524778f, /*-Random.Range(0.6f, 3.2f)*/-2.34f, -0.3f);
        blockInst = Instantiate(block, new Vector3(5f, -6f, -0.3f), Quaternion.identity) as GameObject;
        blockInst.transform.localScale = new Vector3(RandScale(), blockInst.transform.localScale.y, blockInst.transform.localScale.z);
        blockInst.transform.parent = allCubes.transform;
    }
    
}
