using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private GameObject item;
    public float speed = 1f;
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
            //Debug.Log("looping");
            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.localPosition.x - 0.0f, item.transform.localPosition.y - 1.18f, item.transform.localPosition.z + 0.0f), 1f);
            yield return new WaitForSeconds(1);
            //Debug.Log("looping2");
            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.localPosition.x + 3.08f, item.transform.localPosition.y + 0.0f, item.transform.localPosition.z + 0.0f), 1f);
            yield return new WaitForSeconds(1);
            //Debug.Log("looping3");
            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.localPosition.x + 0.0f, item.transform.localPosition.y + 1.18f, item.transform.localPosition.z + 0.0f), 1f);
            yield return new WaitForSeconds(1);
            //Debug.Log("looping4");
            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.localPosition.x - 3.08f, item.transform.localPosition.y + 0.0f, item.transform.localPosition.z + 0.0f), 1f);
            yield return new WaitForSeconds(1);
            //Debug.Log("looping5");
            yield return null;
        }
        //ebug.Log("not looping, input detected");
            yield break;
    }

    void CheckInput()
    {
        if (Input.GetKeyDown("a")) //left
        {
            InputUsed = true;
            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.localPosition.x - 1.0f, item.transform.localPosition.y + 0.0f, item.transform.localPosition.z + 0.0f), 1f);
        }
        if (Input.GetKeyDown("d")) //right
        {
            InputUsed = true;
            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.localPosition.x + 1.0f, item.transform.localPosition.y + 0.0f, item.transform.localPosition.z + 0.0f), 1f);
        }
        if (Input.GetKeyDown("s")) //down
        {
            InputUsed = true;
            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.localPosition.x + 0.0f, item.transform.localPosition.y - 1.0f, item.transform.localPosition.z + 0.0f), 1f);
        }
        if (Input.GetKeyDown("w")) //up
        {
            InputUsed = true;
            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.localPosition.x - 0.0f, item.transform.localPosition.y + 1.0f, item.transform.localPosition.z + 0.0f), 1f);
        }
    }
}
