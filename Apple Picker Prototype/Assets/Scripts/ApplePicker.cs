using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float bastketSpacingY = 2f;

    // Start is called before the first frame update
    void Start()
    {
        //This creates three baskets obj that are spaced out vertically
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (bastketSpacingY * i);
            tBasketGO.transform.position = pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
