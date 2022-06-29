using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public ZombieSpawnManager spawnManager;
    
    [SerializeField] private Transform _target;

    [SerializeField] private NavMeshAgent _agent;

    [SerializeField] private Animator _animator;

    [SerializeField] private float _speed;

    [SerializeField] private float _timeReturnMove;

    [SerializeField] private bool _isMove;

    private bool _playerHasSeenMe;

    private float timerDecisionMaking;
    public float timeBeforeMoveAgain;

    public float decisionMakeTimeMin;
    public float decisionMakeTimeMax;

    public MMFeedbacks growling;
    public MMFeedbacks stepping;

    public float minTimeBetweenGrowls;
    public float maxTimeBetweenGrowls;

    private float timerGrowl;

    private bool _gameIsOver;
    
    [Range(0,10)] public int respawnChance = 5;
    // Start is called before the first frame update
    void Start()
    {
        _gameIsOver = false;
        timerGrowl = Random.Range(minTimeBetweenGrowls, maxTimeBetweenGrowls);
        _agent.speed = _speed;
        _playerHasSeenMe = false;
        timerDecisionMaking = 0;
      
        StartMoveAgente();
        RespawnMe();
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameIsOver)
        {
            return;
        }
        
        _agent.destination = _target.position;
        if (!_isMove)
        {
            _agent.speed = 0;
            _animator.SetBool("Idle",true);
            _animator.SetBool("Walk",false);
            if ((_timeReturnMove -= Time.deltaTime) <= 0)
            {
                _isMove = true; 
                StartMoveAgente();  
            }
        }
        else
        {
            if (timerDecisionMaking > 0)
            {
                timerDecisionMaking -= Time.deltaTime;
                if (timerDecisionMaking <= 0)
                {
                    MakeDecision();
                }
            }

        }

        if ((timerGrowl -= Time.deltaTime) <= 0)
        {
            timerGrowl = Random.Range(minTimeBetweenGrowls, maxTimeBetweenGrowls);
            growling.PlayFeedbacks();
        }

    }

    public void PlayerSawZombie()
    {
        Debug.Log(name,this);
        
        stepping.StopFeedbacks();
        _isMove = false;
        _timeReturnMove = timeBeforeMoveAgain;
        if (!_playerHasSeenMe)
        {
            _playerHasSeenMe = true;
            timerDecisionMaking = Random.Range(decisionMakeTimeMin,decisionMakeTimeMax);
        }
    }

    private void MakeDecision()
    {
        int r = Random.Range(0, 10);
        _playerHasSeenMe = false;
        if (r >= 10-respawnChance)
        {
            RespawnMe();
            StartMoveAgente();
        }
    }

    private void RespawnMe()
    {
        Vector3 newPos = spawnManager.GetBestPoint();
        newPos = new Vector3(newPos.x, newPos.x + 5f, newPos.z);

        transform.position = newPos;
    }

    public void StartMoveAgente()
    {
        //_agent.destination = _target.position;
        stepping.PlayFeedbacks();
        _agent.speed = _speed;
        _animator.SetBool("Idle",false);
        _animator.SetBool("Walk",true);
    }

    public void GameOver()
    {
        _gameIsOver = true;
        stepping.StopFeedbacks();
        _isMove = false;
    }
}
