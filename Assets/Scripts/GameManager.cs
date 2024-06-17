using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// This will be for the level. for now, it is an instance, but later, it will not be.
    /// </summary>
    public static GameManager instance;


    public int livesCount;
    public int enemyCount;

    

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
