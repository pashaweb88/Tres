using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
   
    public List<GameObject> blockChilds = new List<GameObject>();

    [Header("GameState_object")] public GameObject gameState; 

    private bool smTest = false;

    
    // Start is called before the first frame update
    void Start()
    {
        BlockPosesToScreenBorder();
        
    }
    /// <summary>
    /// Animation event: Block Fadein.
    /// </summary>
    private void StartSpawnerEvent()
    {
        gameState.GetComponent<GameState>().StartSpawner();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!smTest)
            {
                smTest = true;
                GetComponent<Animator>().SetBool("blockShow", true);
            }
            //else
            //{
            //    smTest = false;
            //    GetComponent<Animator>().SetBool("blockShow", false);
            //}
            
        }
    }

    private void BlockPosesToScreenBorder()
    {
        float minX = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        float maxX = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x;

        for (int i = 0; i < blockChilds.Count; i++)
        {
            if (i==0 || i == 2)
            {
                blockChilds[i].transform.position = new Vector2(minX, blockChilds[i].transform.position.y);
            } else
            {
                blockChilds[i].transform.position = new Vector2(maxX, blockChilds[i].transform.position.y);
            }
        }
    }
}
