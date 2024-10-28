using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform targetToMove;
    void Start()
    {
        this.agent.SetDestination(this.targetToMove.position);
    }

}
