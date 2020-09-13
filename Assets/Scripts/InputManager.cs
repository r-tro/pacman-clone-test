using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{ 
    [SerializeField]
    private GameObject item;
    //public float speed = 1f;
    private Tweener tweener;
    private bool InputUsed = false;

    // for collision <-- use collision detection tags 

    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
        StartCoroutine(MoveLoop());
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        
    }

    void Awake()
    {
        
    }

    IEnumerator MoveLoop()
    {
        while (InputUsed == false)
        {
            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.localPosition.x - (int)0.0, item.transform.localPosition.y - (int)4.0, item.transform.localPosition.z + (int)0.0), (int)1.0); //converted to int for absolute value
            yield return new WaitForSeconds(1.01f); 
            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.localPosition.x + (int)11.0, item.transform.localPosition.y + (int)0.0, item.transform.localPosition.z + (int)0.0), (int)2.0);
            yield return new WaitForSeconds(2.01f);
            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.localPosition.x + (int)0.0, item.transform.localPosition.y  + (int)4.0, item.transform.localPosition.z + (int)0.0), (int)1.0);
            yield return new WaitForSeconds(1.01f);
            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.localPosition.x - (int)11.0, item.transform.localPosition.y + (int)0.0, item.transform.localPosition.z + (int)0.0), (int)2.0);
            yield return new WaitForSeconds(2.01f);
            yield return null;
        }
        //Debug.Log("not looping, input detected");
            yield break;
    }

    void CheckInput()
    {
        if (Input.GetKeyDown("w")) //up
        {
            InputUsed = true;
            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.localPosition.x, item.transform.localPosition.y + (int)1.0, item.transform.localPosition.z), (int)1.0);
        }
        if (Input.GetKeyDown("s")) //down
        {
            InputUsed = true;
            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.localPosition.x, item.transform.localPosition.y - (int)1.0, item.transform.localPosition.z), (int)1.0);
        }
        if (Input.GetKeyDown("a")) //left
        {
            InputUsed = true;
            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.localPosition.x - (int)1.0, item.transform.localPosition.y, item.transform.localPosition.z), (int)1.0);
        }
        if (Input.GetKeyDown("d")) //right
        {
            InputUsed = true;
            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.localPosition.x + (int)1.0, item.transform.localPosition.y, item.transform.localPosition.z), (int)1.0);
        }
    }
}
