using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerManager : MonoBehaviour
{
    [SerializeField] Animation carMove;
    private string cm = "carMove";
    public GameObject w1;
    public GameObject w2;
    public GameObject w3;
    public GameObject w4;
    void Start()
    {
        
        w1.SetActive(false);
        w2.SetActive(false);
        w3.SetActive(false);
        w4.SetActive(false);
    }
    public void GetWheel()
    {
        w1.SetActive(true);
        StartCoroutine(timee());
        w2.SetActive(true);
        StartCoroutine(timee());
        w3.SetActive(true);
        StartCoroutine(timee());
        w4.SetActive(true);
       
    }
    IEnumerator timee()
    {
        yield return new WaitForSeconds(1f);
    }

}
