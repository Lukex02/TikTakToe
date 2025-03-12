using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SGridSpace : MonoBehaviour
{
    public Button Sbutton;
    public Text SbuttonText;
    public int SplayerMove;

    private SGameController SgameController;

    public void SSetSpace()
    {
        if (SgameController.SplayerMove == true)
        {
            SbuttonText.text = SgameController.SGetPlayerSide();
            Sbutton.interactable = false;
            SgameController.SEndTurn();
            SgameController.SMove = SplayerMove;
        }
    }

    public void SSetGameControllerReference(SGameController Scontroller)
    {
        SgameController = Scontroller;
    }
}
