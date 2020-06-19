using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public GameObject lifeActive;

    public void LoseLifeEffect()
    {
        lifeActive.GetComponent<Animator>().SetBool("lifeOver", true);
    }
}
