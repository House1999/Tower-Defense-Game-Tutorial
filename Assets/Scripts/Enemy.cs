using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int waypointIndex = 0;

    void Start()
    {
        target = Waypoints.points[0]; // target est le premier waypoint
    }

    void Update() // every frame
    {
        // vecteur x y z pour trouver la direction vers le target

        Vector3 dir = target.position - transform.position; // aller de A a B faut soustraire leur position. ici on va de notre current location au point target
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World); // .normalized comme ca on peut avoir la meme vitesse pour tout (qui sera controller par notre variable speed), deltaTime pour pas dependre des frames mais le temps depuis dernier frame

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)  // if waypoint is reached (within 0.2 unites pour surete)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {
        if(waypointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);                                // l'ennemie est mort (arrive a la fin)
            return;                                           // car destroy prend du temps, et visual studio peut lancer les instructions below avant de detruire --> out of range
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex]; // on change de waypoint quand on arrive au waypoint (Donc si on arrive au premier, il le guide vers le 2e)
    }
}
