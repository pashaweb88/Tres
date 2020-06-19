using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
   
    public GameObject itemPrefab;
    public List<Sprite> itemSpriteList;

    [Header("Blocks_Y_coords")] public float maxY;
    [Header("Blocks_Y_coords")] public float minY;

    [Header("Itme_born_speed")] public float speed;

    private float timer = 0;
    private float time = 1f;

    private float minX;
    private float maxX;

    private bool canSpawn = false;

    // Start is called before the first frame update
    public void SetCanSpawn(bool spawn)
    {
        canSpawn = spawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            timer += Time.deltaTime;
            if (timer > time)
            {
                timer = 0;
                BornNewItem();
            }
        }
    }

    private void BornNewItem()
    {
        minX = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        maxX = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x;

        Vector2[] bornCoords = new Vector2[4]
        {
            new Vector2(minX, maxY),
            new Vector2(maxX, maxY),
            new Vector2(minX, minY),
            new Vector2(maxX, minY)
        };
       
        var randomEl = Random.Range(0, itemSpriteList.Count);
        var randomPosIndex = Random.Range(0, 4);
        var bornIttem = Instantiate(itemPrefab, bornCoords[randomPosIndex], Quaternion.identity) as GameObject;
        bornIttem.GetComponent<SpriteRenderer>().sprite = itemSpriteList[randomEl];
        bornIttem.GetComponent<Item>().SetNeedIndex(randomPosIndex);

        if (randomPosIndex == 0 || randomPosIndex == 2)
        {
            bornIttem.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        } else
        {
            bornIttem.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
        }
    }
}
