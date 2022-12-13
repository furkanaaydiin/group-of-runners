using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using Unity.VisualScripting;
using Random = UnityEngine.Random;

public class Opponent : MonoBehaviour
{
    public NavMeshAgent opponentAgentNavMash;
    public Animator opponentAnim;
    public GameManager gamemanager;
    public FinisCamRotation finisCamRotation;
    public CameraManager cameraManager;
    
    public GameObject opponentTarget;
    public GameObject speedBoosterIcon;
    public GameObject AI;
    public GameObject restartPanel;
    

    private Vector3 _opponentStartPos;
    
    private bool _isRunningOpponent;
    private bool _isOpponentJump;
    
    public Rigidbody opponentRigidbody;


    public ParticleSystem deadParticle;

    private void Awake()
    {
	    opponentAgentNavMash = GetComponent<NavMeshAgent>();
	    opponentRigidbody = GetComponent<Rigidbody>();
	    opponentAgentNavMash.speed = Random.Range(7,10);
	    _opponentStartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	   
	    

    }
    
    
    public void Finish()
    {
	    opponentAgentNavMash.speed = 0;
	    opponentAnim.SetBool("isWin",true);
	    opponentRigidbody.isKinematic = true;
	    gamemanager.FinishTac.SetActive(false);
	    AI.transform.DOScale(Vector3.one * 5, 1f);
	    finisCamRotation.FinisRotation();
	    cameraManager.ToLoseCam();
	    gamemanager.FinishParticle1.Play();
	    gamemanager.FinishParticle2.Play();
	    restartPanel.SetActive(true);
    }
    public void Lose()
   {
	   opponentAgentNavMash.speed = 0;
	   opponentAnim.SetBool("isLose",true);
   }
   private void FixedUpdate()
    {
	    if (gamemanager.startGame)
	    {
		    opponentAgentNavMash.destination = opponentTarget.transform.position;
	    }
	   
        if (opponentAgentNavMash.velocity.magnitude > 0.1f && !_isRunningOpponent)
        {
	        opponentAnim.CrossFade("FastRun",0.10f);
	        _isRunningOpponent = true;
        }
        else if (_isRunningOpponent && opponentAgentNavMash.velocity.magnitude <= 0.1)
        {
	        _isRunningOpponent = false;
        }
    }

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("obstacle"))
		{
			StartCoroutine(RestartOpponentCorontine());
		}
		if (collision.collider.CompareTag("ramp"))
		{
			transform.DOJump(new Vector3(transform.position.x,transform.position.y,transform.position.z +6f),3f, 1, 1f).SetEase(Ease.Flash);
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("speedboost"))
		{
			StartCoroutine(SlowAfterAWhileCoroutine());
        }
		if (other.CompareTag("attackjump"))
		{
			AttackJump();
			transform.DOJump(new Vector3(transform.position.x,transform.position.y + 0.5f,transform.position.z +5f),1f, 1, 1f).SetEase(Ease.Flash);
		}
	}
	private void AttackJump()
	{
		if (_isOpponentJump == false)
		{
			StartCoroutine(RunningendJumpCorontine());
		}
	}
	private IEnumerator SlowAfterAWhileCoroutine()
    {
	    opponentAgentNavMash.speed = opponentAgentNavMash.speed + 3f;
	    speedBoosterIcon.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        opponentAgentNavMash.speed = opponentAgentNavMash.speed - 3f;
        speedBoosterIcon.SetActive(false);
    }
	

    private  IEnumerator RunningendJumpCorontine()
    {
	    _isOpponentJump = true;
	    opponentAnim.SetBool("isAttackjump",true);
	    opponentAnim.SetBool("isRun",false);
	    yield return new WaitForSeconds(1f);
	    opponentAnim.SetBool("isRun",true);
	    opponentAnim.SetBool("isAttackjump",false);
	    _isOpponentJump = false;
	    
    }

    private IEnumerator RestartOpponentCorontine()
    {
	    opponentAgentNavMash.speed = 0;
	    opponentAnim.SetBool("isDead",true);
	    deadParticle.transform.position = transform.position;
	    deadParticle.Play();
	    yield return new WaitForSeconds(3f);
	    transform.position = _opponentStartPos;
	    opponentAnim.SetBool("isDead",false);
	    opponentAnim.CrossFade("FastRun",0.10f);
	    opponentAgentNavMash.speed = Random.Range(7, 10);
	  

    }
 
}
