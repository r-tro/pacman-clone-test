using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    private Tween activeTween;
    //private List<Tweener> activeTweens;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        if (activeTween == null)
        {
            activeTween = new Tween(targetObject, startPos, endPos, Time.time, duration);
        }
        else
        {
            //activeTween = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(activeTween.Target.position, activeTween.EndPos) > 0.05f)
        {
            float timeFraction = (Time.time - activeTween.StartTime) / activeTween.Duration;
            activeTween.Target.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, timeFraction);
        }
        else
        {
            activeTween.Target.position = activeTween.EndPos;
            activeTween = null;
        }
    }
}
