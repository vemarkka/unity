using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Target : MonoBehaviour
{

    public ParticleSystem explosionParticle;



    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider collider)
    {
        explosionParticle.Play();

    }
}
