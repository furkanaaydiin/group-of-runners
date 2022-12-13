using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Unity.VisualScripting;


public class CheckCollisions : MonoBehaviour
{
    
	public PlayerController playerController;
	public AnimatorController animatorController;
	public FinisCamRotation finisCamRotation;
	public CameraManager cameraManager;
	public GameManager gameManager;
	
	public ParticleSystem deadparticle;
	public ParticleSystem airParticle;
	
	public GameObject restartPanel;
	public GameObject player;
	Vector3 playerStartPos;
	public GameObject speedBoosterIcon;

	private void Start()
	{
		playerStartPos = new Vector3(transform.position.x,transform.position.y,transform.position.z);
	}
	private void OnTriggerEnter(Collider other)
	{
		
		if (other.CompareTag("finish"))
		{
			restartPanel.SetActive(true);
			finisCamRotation.FinisRotation();
			cameraManager.GameFinisCam();
			player.transform.DOScale(Vector3.one * 5, 1f);
			
			gameManager.FinishParticleConfeti();
		}
		if (other.CompareTag("speedboost"))
		{
			StartCoroutine(SlowAfterAWhileCoroutine());
		}

		if (other.CompareTag("attackjump")) 
		{
			animatorController.AttackJump();
			transform.DOJump(new Vector3(transform.position.x,transform.position.y + 0.5f,transform.position.z +5f),1f, 1, 1f).SetEase(Ease.Flash);
		}
		
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("obstacle"))
		{
			StartCoroutine(RestartPlayerCorontine());
		}
		if (collision.collider.CompareTag("ramp"))
		{
			transform.DOJump(new Vector3(transform.position.x,transform.position.y,transform.position.z +6f),3f, 1, 1f).SetEase(Ease.Flash);
		}
	}
	private IEnumerator SlowAfterAWhileCoroutine()
	{
		speedBoosterIcon.SetActive(true);
		playerController.runningSpeed = playerController.runningSpeed + 3f;
		airParticle.Play();
		yield return new WaitForSeconds(2.0f);
		playerController.runningSpeed = playerController.runningSpeed - 3f;
		speedBoosterIcon.SetActive(false);
	}
	private IEnumerator RestartPlayerCorontine()
	{
		playerController.runningSpeed = 0;
		playerController.xSpeed = 0;
		animatorController.DeadAnim();
		deadparticle.transform.position = transform.position;
		deadparticle.Play();
		yield return new WaitForSeconds(2.5f);
		transform.position = playerStartPos;
		animatorController.RestartAnim();
		playerController.playerAnimControl.CrossFade("FastRun",0.10f);
		playerController.runningSpeed = 8;
		playerController.xSpeed = 20;
		
	}

	
}
