
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
    private Vector2 direction = Vector2.zero;

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
        UpdateOrientation();
    }

    void Awake()
    {

    }

    IEnumerator MoveLoop()
    {
        while (InputUsed == false)
        {
            direction = Vector2.right;
            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.localPosition.x + (int)11.0, item.transform.localPosition.y + (int)0.0, item.transform.localPosition.z + (int)0.0), (int)2.0); //converted to int for absolute value
            yield return new WaitForSeconds(2.01f);
            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.localPosition.x + (int)0.0, item.transform.localPosition.y + (int)-4.0, item.transform.localPosition.z + (int)0.0), (int)1.0);
            direction = Vector2.down;
            yield return new WaitForSeconds(1.01f);
            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.localPosition.x + (int)-11.0, item.transform.localPosition.y + (int)0.0, item.transform.localPosition.z + (int)0.0), (int)2.0);
            direction = Vector2.left;
            yield return new WaitForSeconds(2.01f);
            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.localPosition.x + (int)0.0, item.transform.localPosition.y + (int)4.0, item.transform.localPosition.z + (int)0.0), (int)1.0);
            direction = Vector2.up;
            yield return new WaitForSeconds(1.01f);
        }
        //Debug.Log("not looping, input detected");
        yield break;
    }

    void CheckInput()
    {
        if (Input.GetKeyDown("w")) //up
        {
            InputUsed = true;
            direction = Vector2.up;
            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.localPosition.x, item.transform.localPosition.y + (int)1.0, item.transform.localPosition.z), (int)1.0);
        }
        if (Input.GetKeyDown("s")) //down
        {
            InputUsed = true;
            direction = Vector2.down;
            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.localPosition.x, item.transform.localPosition.y - (int)1.0, item.transform.localPosition.z), (int)1.0);
        }
        if (Input.GetKeyDown("a")) //left
        {
            InputUsed = true;
            direction = Vector2.left;
            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.localPosition.x - (int)1.0, item.transform.localPosition.y, item.transform.localPosition.z), (int)1.0);
        }
        if (Input.GetKeyDown("d")) //right
        {
            InputUsed = true;
            direction = Vector2.right;
            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.localPosition.x + (int)1.0, item.transform.localPosition.y, item.transform.localPosition.z), (int)1.0);
        }
    }

    void UpdateOrientation()
    {
        float imageScale = 1.75f; //change to how large you want the sprite to be
        if (direction == Vector2.up)
        {
            item.transform.localScale = new Vector3(imageScale, imageScale, 1);
            item.transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        else if (direction == Vector2.down)
        {
            item.transform.localScale = new Vector3(imageScale, imageScale, 1);
            item.transform.localRotation = Quaternion.Euler(0, 0, -90);
        }
        else if (direction == Vector2.left)
        {
            item.transform.localScale = new Vector3(-imageScale, imageScale, 1);
            item.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction == Vector2.right)
        {
            item.transform.localScale = new Vector3(imageScale, imageScale, 1);
            item.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
