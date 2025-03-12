using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PPlayer
{
    public Image Ppanel;
    public Text Ptext;
    public Button Pbutton;
}

[System.Serializable]
public class PPlayerColor
{
    public Color PpanelColor;
    public Color PtextColor;
}

public class PGameController : MonoBehaviour
{
    public Text[] Pbuttonlist;
    private string PplayerSide;
    public GameObject PgameOverPanel;
    public Text PgameOverText;
    private int PmoveCount;
    public GameObject PrestartButton;
    public PPlayer PplayerX;
    public PPlayer PplayerO;
    public PPlayerColor PactivePlayerColor;
    public PPlayerColor PinactivePlayerColor;
    public GameObject PstartInfo;


    void Awake()
    {
        PSetGameControllerReferenceOnButtons();
        PgameOverPanel.SetActive(false);
        PmoveCount = 0;
        PrestartButton.SetActive(false);
    }


    void PSetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < Pbuttonlist.Length; i++)
        {
            Pbuttonlist[i].GetComponentInParent<PGridSpace>().PSetGameControllerReference(this);
        }
    }


    public void PSetStartingSide(string PstartingSide)
    {
        PplayerSide = PstartingSide;
        if (PplayerSide == "X")
        {
            PSetPlayerColors(PplayerX, PplayerO);
        }
        else
        {
            PSetPlayerColors(PplayerO, PplayerX);
        }

        PStartGame();
    }

    void PStartGame()
    {
        PSetBoardInteractable(true);
        PSetPlayerButtons(false);
        PstartInfo.SetActive(false);
    }

    public string PGetPlayerSide()
    {
        return PplayerSide;
    }


    public void PEndTurn()
    {
        PmoveCount++;

        if (Pbuttonlist[0].text == PplayerSide && Pbuttonlist[1].text == PplayerSide && Pbuttonlist[2].text == PplayerSide)
        {
            PGameOver(PplayerSide);
        }
        else if (Pbuttonlist[3].text == PplayerSide && Pbuttonlist[4].text == PplayerSide && Pbuttonlist[5].text == PplayerSide)
        {
            PGameOver(PplayerSide);
        }
        else if (Pbuttonlist[6].text == PplayerSide && Pbuttonlist[7].text == PplayerSide && Pbuttonlist[8].text == PplayerSide)
        {
            PGameOver(PplayerSide);
        }
        else if (Pbuttonlist[0].text == PplayerSide && Pbuttonlist[3].text == PplayerSide && Pbuttonlist[6].text == PplayerSide)
        {
            PGameOver(PplayerSide);
        }
        else if (Pbuttonlist[1].text == PplayerSide && Pbuttonlist[4].text == PplayerSide && Pbuttonlist[7].text == PplayerSide)
        {
            PGameOver(PplayerSide);
        }
        else if (Pbuttonlist[2].text == PplayerSide && Pbuttonlist[5].text == PplayerSide && Pbuttonlist[8].text == PplayerSide)
        {
            PGameOver(PplayerSide);
        }
        else if (Pbuttonlist[0].text == PplayerSide && Pbuttonlist[4].text == PplayerSide && Pbuttonlist[8].text == PplayerSide)
        {
            PGameOver(PplayerSide);
        }
        else if (Pbuttonlist[2].text == PplayerSide && Pbuttonlist[4].text == PplayerSide && Pbuttonlist[6].text == PplayerSide)
        {
            PGameOver(PplayerSide);
        }


        else if (PmoveCount >= 9)
        {
            PGameOver("draw");
        }
        else
        {
            PChangeSide();
        }
    }

    void PSetPlayerColors(PPlayer PnewPlayer, PPlayer PoldPlayer)
    {
        PnewPlayer.Ppanel.color = PactivePlayerColor.PpanelColor;
        PnewPlayer.Ptext.color = PactivePlayerColor.PtextColor;
        PoldPlayer.Ppanel.color = PinactivePlayerColor.PpanelColor;
        PoldPlayer.Ptext.color = PinactivePlayerColor.PtextColor;
    }

    void PGameOver(string PwiningPlayer)
    {
        PSetBoardInteractable(false);

        if (PwiningPlayer == "draw")
        {
            PSetGameOverText("Draw!");
            PSetPlayersColorsInactive();
        }
        else
        {
            PSetGameOverText(PwiningPlayer + " Loses!");
        }

        PrestartButton.SetActive(true);

    }

    void PChangeSide()
    {
        PplayerSide = (PplayerSide == "X") ? "O" : "X";
        if (PplayerSide == "X")
        {
            PSetPlayerColors(PplayerX, PplayerO);
        }
        else
        {
            PSetPlayerColors(PplayerO, PplayerX);
        }
    }

    void PSetGameOverText(string Pvalue)
    {
        PgameOverPanel.SetActive(true);
        PgameOverText.text = Pvalue;
    }

    public void PRestartGame()
    {
        PmoveCount = 0;
        PgameOverPanel.SetActive(false);
        for (int i = 0; i < Pbuttonlist.Length; i++)
        {
            Pbuttonlist[i].text = "";
        }

        PrestartButton.SetActive(false);
        PSetPlayerButtons(true);
        PSetPlayersColorsInactive();
        PstartInfo.SetActive(true);
    }

    void PSetBoardInteractable(bool Ptoggle)
    {
        for (int i = 0; i < Pbuttonlist.Length; i++)
        {
            Pbuttonlist[i].GetComponentInParent<Button>().interactable = Ptoggle;
        }
    }

    void PSetPlayerButtons(bool Ptoggle)
    {
        PplayerX.Pbutton.interactable = Ptoggle;
        PplayerO.Pbutton.interactable = Ptoggle;
    }

    void PSetPlayersColorsInactive()
    {
        PplayerX.Ppanel.color = PinactivePlayerColor.PpanelColor;
        PplayerX.Ptext.color = PinactivePlayerColor.PtextColor;
        PplayerO.Ppanel.color = PinactivePlayerColor.PpanelColor;
        PplayerO.Ptext.color = PinactivePlayerColor.PtextColor;
    }
}
