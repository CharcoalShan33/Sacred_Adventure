using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    float _pSpeed;

    Transform shootPosition;
    private void Start()
    {

        shootPosition = GameObject.FindWithTag("Hero").transform;
    }
    private void Update()
    {

        transform.Translate(shootPosition.position* _pSpeed * Time.deltaTime);

        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "BattleEnemy")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
