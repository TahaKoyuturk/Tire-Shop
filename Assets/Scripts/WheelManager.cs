using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelManager : MonoBehaviour
{
    public List<GameObject> wheels = new List<GameObject>();
    public GameObject wheelPrefab;
    public Transform exitPoint;
    bool isWorking;
    void Start()
    {
        StartCoroutine(GenerateWheel());
    }
    public void RemoveLast()
    {
        if (wheels.Count > 0)
        {
            Destroy(wheels[wheels.Count - 1]);
            wheels.RemoveAt(wheels.Count - 1);
        }
    }
   IEnumerator GenerateWheel()
    {
        while (true)
        {
            float wheelCount = wheels.Count;
            if (isWorking)
            {
                GameObject temp = Instantiate(wheelPrefab);
                temp.transform.position = new Vector3(exitPoint.position.x, 0.556f + wheelCount / 6, exitPoint.position.z);
                wheels.Add(temp);
            }
            if (wheels.Count >= 4)
            {
                isWorking = false;
            }else if (wheels.Count<4)
            {
                isWorking = true;
            }
            yield return new WaitForSeconds(1f);
        }
        
    }
}
