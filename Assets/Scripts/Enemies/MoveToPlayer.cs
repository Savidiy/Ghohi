using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPlayer : MonoBehaviour
{
    [SerializeField] NavMeshAgent _navMeshAgent;
    [SerializeField] Transform _transform;
    [SerializeField] float _seeDistance;
    [SerializeField] LayerMask _seeObsacles;
    GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //float distance = (_player.transform.position - _transform.position).magnitude;
        //if (distance < _seeDistance)
        {
            Vector3 origin = _transform.position + Vector3.up;
            Vector3 direction = _player.transform.position - _transform.position;
            if (Physics.Raycast(origin, direction, _seeDistance, _seeObsacles) == false)
            {
                _navMeshAgent.SetDestination(_player.transform.position);
            }
        }
    }
}
