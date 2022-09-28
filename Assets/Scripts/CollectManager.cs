using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    public List<GameObject> wheelsList = new List<GameObject>();
    public GameObject wheelPrefab;
    public Transform exitPoint;
    int wheelLimit = 3;
    private void OnEnable()
    {
        TriggerManager.OnWheelCollect+=GetWheel;
        TriggerManager.carArea += GiveWheel;
    }
    private void OnDisable()
    {
        TriggerManager.OnWheelCollect -= GetWheel;
        TriggerManager.carArea -= GiveWheel;
    }
    void GetWheel()
    {
        if (wheelsList.Count <= wheelLimit) {
            GameObject temp = Instantiate(wheelPrefab,exitPoint);
            temp.transform.position = new Vector3(exitPoint.position.x,0.5f+((float)wheelsList.Count/13), exitPoint.position.z);
            wheelsList.Add(temp);

            if (TriggerManager.wheelManager != null)
            {
                TriggerManager.wheelManager.RemoveLast();
            }
        }
    }
    public void RemoveLast()
    {
        if (wheelsList.Count > 0)
        {
            Destroy(wheelsList[wheelsList.Count - 1]);
            wheelsList.RemoveAt(wheelsList.Count - 1);
        }
    }
    public void GiveWheel()
    {
        if (wheelsList.Count > 0)
        {
            TriggerManager.workerManager.GetWheel();
            RemoveLast();
        }
    }

}
