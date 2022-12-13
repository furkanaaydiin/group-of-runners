using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InGameRanking : MonoBehaviour
{
    public Text[] namesText;
    public string Player, Carol, David, John, Martha, Neo, Peace;

    public void Update()
    {
        namesText[0].text = Player;
        namesText[1].text = Carol;
        namesText[2].text = David;
        namesText[3].text = John;
        namesText[4].text = Martha;
        namesText[5].text = Neo;
        namesText[6].text = Peace;
    }
}
