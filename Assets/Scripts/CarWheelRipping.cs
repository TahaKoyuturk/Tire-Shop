using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWheelRipping : MonoBehaviour
{
    private bool canRippable = false;

    public GameObject w1;
    public GameObject jant;
    public GameObject h1, h2;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    IEnumerator Ripping()
    {
        jant.SetActive(false);
        w1.SetActive(false);
        yield return new WaitForSeconds(2f);
        h1.SetActive(false);
        h2.SetActive(false);
        canRippable = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && canRippable) {
            StartCoroutine(Ripping());
        }
    }
}
