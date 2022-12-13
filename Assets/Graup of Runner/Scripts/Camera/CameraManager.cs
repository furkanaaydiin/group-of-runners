using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
  [SerializeField] public GameObject StartCam;
  [SerializeField] public GameObject PlayerFollowCam;
  [SerializeField] public GameObject FinisCam;
  [SerializeField] public GameObject PlayerLoseCam;

  public void GameStartCam()
  {
    StartCam.SetActive(false);
    PlayerFollowCam.SetActive(true);
  }

  public void GameFinisCam()
  {
    PlayerFollowCam.SetActive(false);
    FinisCam.SetActive(true);
  }

  public void ToLoseCam()
  {
    StartCoroutine(ToLoseCamCorontine());
  }


  public IEnumerator ToLoseCamCorontine()
  {
    GameFinisCam();
    yield return new WaitForSeconds(4);
    FinisCam.SetActive(false);
    PlayerLoseCam.SetActive(true);
    
  }





}
