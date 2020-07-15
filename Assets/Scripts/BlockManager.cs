using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{

    public List<Block> blocks = new List<Block>();

    Block currentBlock = null;

    void Start()
    {
        p1();
        p2();
        p2();
        p2();
        p2();
        p1();
        p1();
        p1();
        p1();
        p1();
    }

    void p1()
    {
        SpawnBlock(0);
        SpawnBlock(0);
        SpawnBlock(3);
        SpawnBlock(3);
        SpawnBlock(1);
    }

    void p2()
    {
        SpawnBlock(2);
        SpawnBlock(2);
        SpawnBlock(1);
        SpawnBlock(3);
        SpawnBlock(0);
    }

    void SpawnBlock(int num)
    {
        if(currentBlock == null)
        {
            currentBlock = Instantiate(blocks[num], Vector3.zero, Quaternion.identity) as Block;
        }
        else
        {
            currentBlock = Instantiate(blocks[num], currentBlock.head.position, Quaternion.identity) as Block;
        }
    }

}
