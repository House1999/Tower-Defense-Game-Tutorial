using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;

    void Awake()
    {
        points = new Transform[transform.childCount]; // childCount = 13 = nb d'objets dans "waypoints" donc nb de waypoints --> on cree 13 espaces dans l'array

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i); // les rajouter dans notre array points
        }
    }
}
