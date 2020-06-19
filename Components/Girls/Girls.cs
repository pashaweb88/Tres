using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girls : MonoBehaviour
{
    public List<GameObject> girlsList = new List<GameObject>();

    public float offsetPoses;

    // Start is called before the first frame update
    void Start()
    {
        FixPoses();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixPoses()
    {
        float minX = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        float maxX = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x;

        for (int i = 0; i< girlsList.Count; i++)
        {
            if (i == 0|| i== 2)
            {
                girlsList[i].transform.position = new Vector2(minX+offsetPoses, girlsList[i].transform.position.y);
            } else
            {
                girlsList[i].transform.position = new Vector2(maxX-offsetPoses, girlsList[i].transform.position.y);
            }
        }
    }   
}
