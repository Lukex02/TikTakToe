using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PGridSpace : MonoBehaviour
{
    public Button Pbutton;
    public Text PbuttonText;

    private PGameController PgameController;

    public void PSetSpace()
    {
        PbuttonText.text = PgameController.PGetPlayerSide();
        Pbutton.interactable = false;
        PgameController.PEndTurn();
    }

    public void PSetGameControllerReference(PGameController Pcontroller)
    {
        PgameController = Pcontroller;
    }
}
