using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    [Header("Waypoints")]
    public List<Transform> waypoints = new List<Transform>();
    public GameObject waypointsParent;

    public Transform _destination;
    public Transform destination
    {
        get { return _destination; }
    }
    [Space(20)]

    public int destinationInt = 0;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GetWaypoints();
    }

    void Update()
    {
        CheckAIPosition();
    }

    void GetWaypoints()
    {
        int waypointsAmount = waypointsParent.transform.childCount;

        if (destinationInt < waypointsAmount && waypoints.Count != waypointsAmount)
        {
            waypoints.Add(waypointsParent.transform.GetChild(destinationInt).gameObject.transform);
            _destination = waypointsParent.transform.GetChild(destinationInt).gameObject.transform;
            agent.SetDestination(destination.position);
        }
    }

    void CheckAIPosition()
    {
        Transform aiPosition = this.gameObject.transform;
        Transform waypointEnd = waypointsParent.transform.GetChild(waypointsParent.transform.childCount - 1).transform;
        if (aiPosition.position == destination.position)
        {
            if (destinationInt < waypointsParent.transform.childCount && aiPosition.position != waypointEnd.position)
            {
                destinationInt++;
                GetWaypoints();
            }
            else if (aiPosition.position == waypointEnd.position)
            {
                destinationInt--;
                DestinationWayBack();
            }
        }
    }

    void DestinationWayBack()
    {
        _destination = waypointsParent.transform.GetChild(destinationInt).gameObject.transform;
        agent.SetDestination(destination.position);
    }

    IEnumerable WaitForNextDestination(float t)
    {
        yield return new WaitForSeconds(t);
    }
}