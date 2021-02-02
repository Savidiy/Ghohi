using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum PatrolType {PingPong, Circle}

public class WaypointPatrol : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] GameObject path;
    [SerializeField] PatrolType patrolType;
    [SerializeField] Transform teleportOnStart;
    int _currentWaypointIndex;
    bool _isIncreaseWaypointIndex = true;

    void Start()
    {
        if (path != null && path.transform.childCount > 0)
        {

            Vector3 startPoint = path.transform.GetChild(0).position;
            if (teleportOnStart)
                teleportOnStart.position = startPoint;
            navMeshAgent.SetDestination(startPoint);
        }
    }

    void Update()
    {
        if (path != null && path.transform.childCount > 0)
        {
            if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
            {
                switch (patrolType)
                {
                    case PatrolType.Circle: /// 0123_0123_0123
                        _currentWaypointIndex = (_currentWaypointIndex + 1) % path.transform.childCount;
                        break;
                    case PatrolType.PingPong: /// 0123_210_123
                        if (path.transform.childCount > 1)
                        {
                            if (_isIncreaseWaypointIndex)
                            {
                                _currentWaypointIndex++;
                                if (_currentWaypointIndex >= path.transform.childCount)
                                {
                                    _currentWaypointIndex -= 2;
                                    _isIncreaseWaypointIndex = false;
                                }
                            }
                            else
                            {
                                _currentWaypointIndex--;
                                if (_currentWaypointIndex < 0)
                                {
                                    _currentWaypointIndex += 2;
                                    _isIncreaseWaypointIndex = true;
                                }
                            }
                        }
                        break;
                    default:
                        Debug.LogError($"{this.GetType().Name}: Unknown Patrol Type");
                        break;
                }

                if (_currentWaypointIndex >= 0 && _currentWaypointIndex < path.transform.childCount)
                    navMeshAgent.SetDestination(path.transform.GetChild(_currentWaypointIndex).position);
                else
                    _currentWaypointIndex = 0;
            }
        } 
    }
}
