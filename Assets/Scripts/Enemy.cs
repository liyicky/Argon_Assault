using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject explosion;
    [SerializeField] int hits = 5;

    Scoreboard scoreboard;
    // Start is called before the first frame update
    void Start()
    {
        print("Enemy script loaded");
        scoreboard = FindObjectOfType<Scoreboard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        HandleDamage();
        scoreboard.ScoreHit();
    }

    private void HandleDamage()
    {
        hits--;

        if (hits <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
    }
}
