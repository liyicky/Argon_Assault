using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject explosion;

    Scoreboard scoreboard;
    // Start is called before the first frame update
    void Start()
    {
        print("Enemy script loaded");
        scoreboard = FindObjectOfType<Scoreboard>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        print("Particles collided with enemy " + other.name);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        scoreboard.ScoreHit();
    }
}
