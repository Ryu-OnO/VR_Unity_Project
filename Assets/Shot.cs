using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shot : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Vector3 offset;
    public float power;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnPress_Trigger()
    {
        GameObject bullet = Instantiate(bulletPrefab, this.gameObject.transform.position + offset, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(this.transform.forward * power, ForceMode.Impulse);
    }
}
