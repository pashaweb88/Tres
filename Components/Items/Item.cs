using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private int needIndex;

    

    public int GetNeedIndex()
    {
        return needIndex;
    }

    public void SetNeedIndex(int index)
    {
        needIndex = index;
    }
}
