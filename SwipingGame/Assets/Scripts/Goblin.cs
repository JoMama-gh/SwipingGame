using System.Net;
using UnityEngine;

public class Goblin : MonoBehaviour
      
{
    float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

 
    }

    // Update is called once per frame
    void Update()

     
    {
        print("bugi" + Time.deltaTime);
        transform.position += new Vector3(-50, 0, 0) * 1f * Time.deltaTime;
        timer += Time.deltaTime;
        if (timer >= 5f)
        {
            transform.position = new Vector3(0, 0, 0);
        }
        ;
    }
}
