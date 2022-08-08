using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TargetMove : MonoBehaviour
{
    public GameObject collisionPointTest;
    public bool m_isActive = false;

    public float m_Time;
    private float m_TimeCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_isActive)
        {
            m_TimeCount += Time.deltaTime;
            if (m_TimeCount >= m_Time)
            {
                m_TimeCount = 0;
                m_isActive = true;

            }

        }

        ChangeActive();
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Shot")
        {
            ContactPoint contactPoint = c.contacts
                .Where(contact => contact.otherCollider.tag == "Shot")
                .FirstOrDefault();

            //Vector3 hitpos = c.collider.ClosestPointOnBounds(this.transform.position);

            Debug.Log("Hit");

            Instantiate(collisionPointTest, contactPoint.point, Quaternion.identity);
            ChangeActive();
            m_isActive = false;
        }
    }

    void ChangeActive()
    {
        if (m_isActive)
        {
            Vector3 rotationAngles = new Vector3(270, 0, 0);
            //オイラー角をクオータニオンに変換
            Quaternion rotation = Quaternion.Euler(rotationAngles);
            this.transform.localRotation = rotation;
        }
        else
        {
            Vector3 rotationAngles = new Vector3(0, 0, 0);
            //オイラー角をクオータニオンに変換
            Quaternion rotation = Quaternion.Euler(rotationAngles);
            this.transform.localRotation = rotation;
        }
    }

    //private IEnumerator Roteto(float _angle)
    //{


    //    yield return false;
    //}

}
