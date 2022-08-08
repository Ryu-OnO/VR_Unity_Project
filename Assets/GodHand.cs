using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GodHand : MonoBehaviour
{
    enum HandType
    {
        LEFT,
        RIGHT
    }

    [SerializeField] HandType handType = HandType.LEFT;

    public GameObject holdObjL, holdObjR;
    private List<GameObject> hitObjList = new();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hitObjList.Clear();
    }
    //private void LateUpdate()
    //{
        
    //}

    void OnPress_Grip_L()
    {
        Debug.Log("left");
        foreach(GameObject obj in hitObjList)
        {
            obj.transform.parent = transform;
        }
    }

    void OnPress_Grip_R()
    {
        Debug.Log("right");
        foreach (GameObject obj in hitObjList)
        {
            obj.transform.parent = transform;
        }
    }

    void OnRelease_Grip_L()
    {
        Debug.Log("left_");

    }

    void OnRelease_Grip_R()
    {
        Debug.Log("right_");

    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.name);
        hitObjList.Add(other.gameObject);
    }
}
