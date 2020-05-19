using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        print("triggerd :" + other.name);
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        SendMessage("Stop");
        explosion.SetActive(true);
    }

    
}
