using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class WorkerManager : MonoBehaviour
{
    
    Sequence seq;
    [SerializeField] Transform tr;
    [SerializeField] Transform exitPoint;
    [SerializeField] Transform winPanel;
    public GameObject lift1;
    public GameObject lift2;
    public GameObject w1;
    public GameObject jant;
    public GameObject h1, h2;
    bool isOk = false;
    public bool liftable;
    private void Start()
    {
        DOTween.Init();
        StartCoroutine(CarMovingToLift());
    }
    public void GetWheel()
    { 
        StartCoroutine(CarMovingFromLift());
    }
    IEnumerator CarMovingToLift()
    {

        seq = DOTween.Sequence();
        seq.Append(transform.DOMoveX(tr.position.x, Mathf.Abs(transform.position.x / 4)));
        seq.Append(transform.DOLocalRotate(new Vector3(0, 0, 0), 4f, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear));
        seq.Append(lift1.transform.DOMoveY(0.6f, 2));
        seq.Join(lift2.transform.DOMoveY(0.6f, 2));
        seq.Join(transform.DOMoveY(0.62f, 2));
        yield return new WaitForSeconds(3f);
        if (this.gameObject.transform.position.x < 0){
            transform.DOMoveX(0, 2);
        }
        //StartCoroutine(TimeReverse());
    }
    
    IEnumerator CarMovingFromLift()
    {
        StartCoroutine(Time());
        yield return new WaitForSeconds(2f);
        seq = DOTween.Sequence();
        seq.Append(lift1.transform.DOMoveY(0f, 2));
        seq.Join(lift2.transform.DOMoveY(0f, 2));
        yield return new WaitForSeconds(2f);
        seq.Append(transform.DOMoveX(exitPoint.position.x,3));
        seq.Join(winPanel.DOMoveY(2000f, 3));
    }
    IEnumerator Time()
    {
        jant.SetActive(true);
        w1.SetActive(true);
        yield return new WaitForSeconds(2f);
        h1.SetActive(true);
        h2.SetActive(true);
        isOk = true;
    }
    IEnumerator TimeReverse()
    {
        jant.SetActive(false);
        w1.SetActive(false);
        yield return new WaitForSeconds(2f);
        h1.SetActive(false);
        h2.SetActive(false);
        isOk = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            StartCoroutine(TimeReverse());
        }
    }
}
