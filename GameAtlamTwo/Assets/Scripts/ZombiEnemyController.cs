using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombiEnemyController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private NavMeshAgent _agent;
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        _agent.SetDestination(_target.position);
    }
}
