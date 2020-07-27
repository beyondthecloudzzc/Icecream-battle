using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pack : MonoBehaviour
{
    public List<int> items = null;
    public int maxItem = 2;
    // Start is called before the first frame update
    void Start()
    {
        items = new List<int>();
        items.Add(0);
        items.Add(0);
    }

    
}
