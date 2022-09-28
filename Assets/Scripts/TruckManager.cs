using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TruckManager : MonoBehaviour
{
    [SerializeField] Transform carExit;
    [SerializeField] Transform truckStop;
    private void Start()
    {
        DOTween.Init();
        StartCoroutine(LiftCar());
    }
    IEnumerator LiftCar()
    {
        transform.DOMoveX(truckStop.position.x, Mathf.Abs(transform.position.x / 3));
        yield return new WaitForSeconds(5f);
        transform.DOMoveX(carExit.position.x, 3);
    }
}
