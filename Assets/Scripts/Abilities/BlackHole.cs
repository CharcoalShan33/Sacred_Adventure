using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{

    [SerializeField]
    float maxSize, growRadius;
    bool canGrow;

    bool canAttack;
    private List<GameObject> targets;

    [SerializeField]
    int amount = 4;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.L))
        {
            canAttack = true;
        }

        if(canGrow)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(maxSize, maxSize), growRadius * Time.deltaTime);
        }
    }
}
