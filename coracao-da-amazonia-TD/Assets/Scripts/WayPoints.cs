using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    //array que armazena os waypoints
    public static Transform[] points;
     
    void Awake()
    {
        //array points com o tamanho do número de children/filhos do objeto transform
        points = new Transform[transform.childCount];
        //percorre cada child/filho(waypoint) do transform e armazena na array points
        for (int i = 0; i < points.Length; i++) 
        {
            points[i] = transform.GetChild(i);
        }
    }
}
