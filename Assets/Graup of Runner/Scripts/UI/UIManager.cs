using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;
using Graup_of_Runner.Scripts.Characters;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    private static UIManager uiManeger;
    [FormerlySerializedAs("_animatorController")] public PlayerAnimatorController playerAnimatorController;
    private List<RunkingSystem> sortArry = new List<RunkingSystem>();
    private InGameRanking inGameRanking;
    [Header("Ranking")]
    public GameObject[] Character;

   
    [SerializeField] private RectTransform rankingPanel;
    [SerializeField]  private RectTransform shopbutton;
    [Header("ScreenUIObject")] 
    [SerializeField] private GameObject shopPanel;
    public GameObject taptoStartPanel;


    [Header("GameButton")] 
    [SerializeField] private Button restartButtonOn;
    [SerializeField] private Button tapToPlayButtonOn;
    [SerializeField] private Button ShopButtonOn;
    [SerializeField] private Button mainScreenButtonOn;


    private void Awake()
    {
        inGameRanking = FindObjectOfType<InGameRanking>();

        restartButtonOn.onClick.AddListener(RestartGame);
        tapToPlayButtonOn.onClick.AddListener(playerAnimatorController.StartRunAim);
        tapToPlayButtonOn.onClick.AddListener(TapToPlayScreen);
        ShopButtonOn.onClick.AddListener(ShopingPanel);
        mainScreenButtonOn.onClick.AddListener(MainScreenPanel);
    }
    private void Start()
    {
        for (int i = 0; i < Character.Length; i++)
        {
            sortArry.Add(Character[i].GetComponent<RunkingSystem>());
        }
    }

    private void Update()
    {
        CalculateRank();
    }
    
    public void CalculateRank()
    {
        sortArry = sortArry.OrderBy(x => x.distance).ToList();
        
        sortArry[0].rank = 1;
        sortArry[1].rank = 2;
        sortArry[2].rank = 3;
        sortArry[3].rank = 4;
        sortArry[4].rank = 5;
        sortArry[5].rank = 6;
        sortArry[6].rank = 7;
    
        inGameRanking.Player = sortArry[6].name;
        inGameRanking.Carol = sortArry[5].name;
        inGameRanking.David = sortArry[4].name;
        inGameRanking.John = sortArry[3].name;
        inGameRanking.Martha = sortArry[2].name;
        inGameRanking.Neo = sortArry[1].name;
        inGameRanking.Peace = sortArry[0].name;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void TapToPlayScreen()
    {
        rankingPanel.DOAnchorPosX(1f, 2f);
        shopbutton.DOAnchorPosX(656, 1f);

    }

    private void ShopingPanel()
    {
        shopPanel.SetActive(true);
        shopbutton.DOAnchorPosX(656, 1f);
    }

    private void MainScreenPanel()
    {
        shopPanel.SetActive(false);
        shopbutton.DOAnchorPosX(444, 1f);
    }

    public void FinishPanels()
    {
        shopbutton.DOAnchorPosX(444, 1f);
        
    }
}
