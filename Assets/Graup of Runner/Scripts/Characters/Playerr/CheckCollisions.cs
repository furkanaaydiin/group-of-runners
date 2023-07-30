using System.Collections;
using DG.Tweening;
using Graup_of_Runner.Scripts.Camera;
using UnityEngine;
using UnityEngine.Serialization;
using CameraType = Graup_of_Runner.Scripts.Camera.CameraType;


namespace Graup_of_Runner.Scripts.Characters.Playerr
{
	public class CheckCollisions : MonoBehaviour
	{
    
		public Player.Player playerController;
		 public PlayerAnimatorController playerAnimatorController;
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
				FinisCamRotation.Instance.FinisRotation();
				CameraController.Instance.ChangeCamera(CameraType.FinishCamera);
				player.transform.DOScale(Vector3.one * 5, 1f);
			
				gameManager.FinishParticleConfeti();
			}
			if (other.CompareTag("speedboost"))
			{
				StartCoroutine(SlowAfterAWhileCoroutine());
			}

			if (other.CompareTag("attackjump")) 
			{
				playerAnimatorController.AttackJump();
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
			playerAnimatorController.DeadAnim();
			deadparticle.transform.position = transform.position;
			deadparticle.Play();
			yield return new WaitForSeconds(2.5f);
			transform.position = playerStartPos;
			playerAnimatorController.RestartAnim();
			playerController.PlayeraAnimator.CrossFade("FastRun",0.10f);
			playerController.runningSpeed = 8;
			playerController.xSpeed = 20;
		
		}

	
	}
}
