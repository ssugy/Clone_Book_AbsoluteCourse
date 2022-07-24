using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info
{
    public int data;
}


public class Test : MonoBehaviour
{
    Info[] list;

    void Start()
    {
        //list = new Info[3];

        //list[0] = new();
        //list[1] = new();
        //list[2] = new();

        //list[0].data = -1;
        //list[1].data = -1;
        //list[2].data = -1;

        //Debug.Log(list[0].data);
        //Debug.Log(list[1].data);
        //Debug.Log(list[2].data);

       //    Mathf.Sqrt
    }

    private void OnTriggerEnter(Collider other)
    {
        print("트리거 발생" + name);
        Vector3 v3 = Vector3.zero;
        
    }
}
