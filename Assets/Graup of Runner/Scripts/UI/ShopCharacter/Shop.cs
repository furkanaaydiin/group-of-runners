using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    [System.Serializable]
    class ShopCharacter
    {
        public Sprite Image;
        public int Price;
        public bool isPurchased = false;
    }

    [SerializeField]  List<ShopCharacter> ShopCharacterList;
    [SerializeField]  private Transform ShopScrolWiew;
    [SerializeField] private Animator NoCupAnim;
    [SerializeField] private Text CupeText;
    GameObject ItemTempLate;
    GameObject Icon;
    Button buyBTN;
    public GameObject[] shopCharacter;

    public void Characters() // 23.07.2023
    {
        for (var i = 0; i < shopCharacter.Length; i++)
        {
            shopCharacter[i].transform.GetChild(1).GetChild(0).GetComponent<SkinnedMeshRenderer>().enabled = false;
        }
    }


    private void Start()
   {
       Characters();
       int characterLengt = ShopCharacterList.Count;
       ItemTempLate = ShopScrolWiew.GetChild(0).gameObject;
       for (int i = 0; i < characterLengt; i++)
       {
           Icon = Instantiate(ItemTempLate, ShopScrolWiew);
           Icon.transform.GetChild(0).GetComponent<Image>().sprite = ShopCharacterList[i].Image;
           Icon.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = ShopCharacterList[i].Price.ToString();
           buyBTN = Icon.transform.GetChild(2).GetComponent<Button>();
           buyBTN.interactable = !ShopCharacterList[i].isPurchased;
           buyBTN.AddEventListener(i,OnShopItemsBtnClick);
          
       }
       Destroy(ItemTempLate);
       
       
       SetCupsUI();
   }

   void OnShopItemsBtnClick(int itemIndex)
   {
       if (GameManager.Instance.HasEnoughCup(ShopCharacterList[itemIndex].Price))
       {
           GameManager.Instance.UseCup(ShopCharacterList[itemIndex].Price);
           // alındı alınmadı 
           ShopCharacterList[itemIndex].isPurchased = true;
           //disble the button
           buyBTN =ShopScrolWiew.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
           buyBTN.interactable = false;
           buyBTN.transform.GetChild(0).GetComponent<Text>().fontSize = 25;
           buyBTN.transform.GetChild(0).GetComponent<Text>().text = "PUNCHADED";
          

           SetCupsUI();
       }
       else
       {
           NoCupAnim.SetTrigger("NoCup");
           Debug.Log("para yok");
       }
       
   }

   void SetCupsUI()
   {
       CupeText.text = GameManager.Instance.cup.ToString();
   }
}
