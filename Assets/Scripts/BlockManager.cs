using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{

    public List<Block> statirsList = new List<Block>();
    Block currentStatirs = null;

    int[] maps = new int[] { 0, 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 1 };

    private void Start()
    {

        for (int i = 0; i < maps.Length; i++)
        {
            if (currentStatirs == null)
            {
                currentStatirs = Instantiate(statirsList[maps[i]], transform.position, Quaternion.identity) as Block;
            }
            else
            {
                currentStatirs = Instantiate(statirsList[maps[i]], currentStatirs.GetFrontPos(), Quaternion.identity) as Block;
            }
        }

        
        
    }

}
