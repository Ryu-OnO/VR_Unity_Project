using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mana : MonoBehaviour
{
    public TargetMove[] gameObjects;
    float time;
    bool isClear = false;
    bool isStart = false;

    int num = 0;
    int random = 0;
    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(0, gameObjects.Length -1);

        for (int i = 0; i < gameObjects.Length; i++)
        {
            if(i == random)
            {
                gameObjects[i].m_isActive = true;
            }
            else
            {
                gameObjects[i].m_isActive = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {  
        if(isStart)
        {
            time += Time.deltaTime;
        }

        if (!gameObjects[random].m_isActive && !isClear)
        {
            num++;
            isStart = true;
            random = Random.Range(0, gameObjects.Length - 1);

            for (int i = 0; i < gameObjects.Length; i++)
            {
                if (i == random)
                {
                    gameObjects[i].m_isActive = true;
                }
                else
                {
                    gameObjects[i].m_isActive = false;
                }
            }
        }

        if(time > 30 && !isClear)
        {
            Debug.Log(num);
            isClear = true;
        } 
    }
}
