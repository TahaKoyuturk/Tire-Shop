using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public delegate void OnCollectArea();
    public static event OnCollectArea OnWheelCollect;

    public static WheelManager wheelManager;

    public delegate void CarArea();
    public static event CarArea carArea;

    public static WorkerManager workerManager;
    bool isCollecting,isGiving;


    private void Start()
    {
        StartCoroutine(CollectEnum());
    }
    IEnumerator CollectEnum()
    {
        while (true)
        {
            if (isCollecting)
            {
                OnWheelCollect();
            }
            if (isGiving)
            {
                carArea();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            isCollecting = true;
            wheelManager = other.gameObject.GetComponent<WheelManager>();
        }
        if (other.gameObject.CompareTag("Car"))
        {
            isGiving = true;
            workerManager = other.gameObject.GetComponent<WorkerManager>();
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            isCollecting = false ;
            wheelManager = null;
        }
        if (other.gameObject.CompareTag("Car"))
        {
            isGiving = false;
            workerManager = null;
        }
    }




}
