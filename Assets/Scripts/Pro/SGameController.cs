using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SPlayer
{
    public Image Spanel;
    public Text Stext;
    public Button Sbutton;
}

[System.Serializable]
public class SPlayerColor
{
    public Color SpanelColor;
    public Color StextColor;
}

public class SGameController : MonoBehaviour
{
    public Text[] Sbuttonlist;
    private string SplayerSide;
    public GameObject SgameOverPanel;
    public Text SgameOverText;
    public int SmoveCount;
    public GameObject SrestartButton;
    public SPlayer SplayerX;
    public SPlayer SplayerO;
    public SPlayerColor SactivePlayerColor;
    public SPlayerColor SinactivePlayerColor;
    public GameObject SstartInfo;

    private string ScomputerSide;
    public bool SplayerMove;
    public float Sdelay = 10;
    private int Svalue;
    private int k;
    public int SMove;



    public List<int> validMoves = new List<int>();


    void Awake()
    {
        SSetGameControllerReferenceOnButtons();
        SgameOverPanel.SetActive(false);
        SmoveCount = 0;
        SrestartButton.SetActive(false);
        SplayerMove = true;
    }





    //BOT Movements
    void Update()
    {
        if (SplayerMove == false)
        {
            Sdelay += Sdelay * Time.deltaTime;
            if (Sdelay >=40)
            {



                //This decides where computer will go
                if (SmoveCount == 1)
                {
                    AddValidMoves();
                    k = Random.Range(0, validMoves.Count);
                    Svalue = validMoves[k];
                    BotMove();
                }

                if (SmoveCount == 3)
                {
                    validMoves.Clear();
                    AddValidMoves();
                    k = Random.Range(0, validMoves.Count);
                    Svalue = validMoves[k];
                    BotMove();
                }

                if (SmoveCount == 5)
                {
                    validMoves.Clear();
                    AddValidMoves();
                    CheckComWinCondition();
                    CheckPlayerWinCondition();
                    k = Random.Range(0, validMoves.Count);
                    Svalue = validMoves[k];
                    BotMove();
                }
                if (SmoveCount == 7)
                {
                    validMoves.Clear();
                    validMoves.Add(0);
                    validMoves.Add(1);
                    validMoves.Add(2);
                    validMoves.Add(3);
                    validMoves.Add(4);
                    validMoves.Add(5);
                    validMoves.Add(6);
                    validMoves.Add(7);
                    validMoves.Add(8);

                    CheckPlayerWinCondition();
                    CheckComWinCondition();
                    k = Random.Range(0, validMoves.Count);
                    Svalue = validMoves[k];


                    BotMove();
                }
                if (Sdelay >= 100)
                {
                    validMoves.Clear();
                    Svalue = Random.Range(0, 8);
                    BotMove();
                }



            }
        }
    }

    void CheckComWinCondition()
    {
        if (Sbuttonlist[1].text == ScomputerSide && Sbuttonlist[2].text == ScomputerSide || Sbuttonlist[3].text == ScomputerSide && Sbuttonlist[6].text == ScomputerSide || Sbuttonlist[4].text == ScomputerSide && Sbuttonlist[8].text == ScomputerSide)
        {
            validMoves.Remove(0);
        }
        if (Sbuttonlist[0].text == ScomputerSide && Sbuttonlist[2].text == ScomputerSide || Sbuttonlist[4].text == ScomputerSide && Sbuttonlist[7].text == ScomputerSide)
        {
            validMoves.Remove(1);
        }

        if (Sbuttonlist[0].text == ScomputerSide && Sbuttonlist[1].text == ScomputerSide || Sbuttonlist[5].text == ScomputerSide && Sbuttonlist[8].text == ScomputerSide || Sbuttonlist[4].text == ScomputerSide && Sbuttonlist[6].text == ScomputerSide)
        {
            validMoves.Remove(2);
        }
        if (Sbuttonlist[0].text == ScomputerSide && Sbuttonlist[6].text == ScomputerSide || Sbuttonlist[4].text == ScomputerSide && Sbuttonlist[5].text == ScomputerSide)
        {
            validMoves.Remove(3);
        }

        if (Sbuttonlist[0].text == ScomputerSide && Sbuttonlist[3].text == ScomputerSide || Sbuttonlist[7].text == ScomputerSide && Sbuttonlist[8].text == ScomputerSide || Sbuttonlist[4].text == ScomputerSide && Sbuttonlist[2].text == ScomputerSide)
        {
            validMoves.Remove(6);
        }
        if (Sbuttonlist[2].text == ScomputerSide && Sbuttonlist[8].text == ScomputerSide || Sbuttonlist[4].text == ScomputerSide && Sbuttonlist[3].text == ScomputerSide)
        {
            validMoves.Remove(5);
        }

        if (Sbuttonlist[2].text == ScomputerSide && Sbuttonlist[5].text == ScomputerSide || Sbuttonlist[7].text == ScomputerSide && Sbuttonlist[6].text == ScomputerSide || Sbuttonlist[4].text == ScomputerSide && Sbuttonlist[0].text == ScomputerSide)
        {
            validMoves.Remove(8);
        }
        if (Sbuttonlist[1].text == ScomputerSide && Sbuttonlist[4].text == ScomputerSide || Sbuttonlist[6].text == ScomputerSide && Sbuttonlist[8].text == ScomputerSide)
        {
            validMoves.Remove(7);
        }

        for (int i = 0; i<4; i++)
        {
            if (Sbuttonlist[i].text == ScomputerSide && Sbuttonlist[8-i].text == ScomputerSide)
            {
                validMoves.Remove(4);
            }
        }
    }

    void AddValidMoves()
    {
        if (SMove == 0)
        {
            validMoves.Add(5);
            validMoves.Add(7);


        }
        if (SMove == 1)
        {
            validMoves.Add(3);
            validMoves.Add(5);
            validMoves.Add(6);
            validMoves.Add(8);


        }
        if (SMove == 2)
        {
            validMoves.Add(3);
            validMoves.Add(7);


        }
        if (SMove == 3)
        {
            validMoves.Add(1);
            validMoves.Add(2);
            validMoves.Add(7);
            validMoves.Add(8);

        }
        if (SMove == 4)
        {
            validMoves.Add(0);
            validMoves.Add(1);
            validMoves.Add(2);
            validMoves.Add(3);
            validMoves.Add(4);
            validMoves.Add(5);
            validMoves.Add(6);
            validMoves.Add(7);
            validMoves.Add(8);
        }
        if (SMove == 5)
        {
            validMoves.Add(0);
            validMoves.Add(1);
            validMoves.Add(6);
            validMoves.Add(7);


        }
        if (SMove == 6)
        {
            validMoves.Add(1);
            validMoves.Add(5);


        }
        if (SMove == 7)
        {
            validMoves.Add(0);
            validMoves.Add(2);
            validMoves.Add(3);
            validMoves.Add(5);


        }
        if (SMove == 8)
        {
            validMoves.Add(1);
            validMoves.Add(3);

        }
    }

    void CheckPlayerWinCondition()
    {
        if (Sbuttonlist[1].text == SplayerSide && Sbuttonlist[2].text == SplayerSide || Sbuttonlist[3].text == SplayerSide && Sbuttonlist[6].text == SplayerSide || Sbuttonlist[4].text == SplayerSide && Sbuttonlist[8].text == SplayerSide)
        {
            validMoves.Remove(0);
        }
        if (Sbuttonlist[0].text == SplayerSide && Sbuttonlist[2].text == SplayerSide || Sbuttonlist[4].text == SplayerSide && Sbuttonlist[7].text == SplayerSide)
        {
            validMoves.Remove(1);
        }

        if (Sbuttonlist[0].text == SplayerSide && Sbuttonlist[1].text == SplayerSide || Sbuttonlist[5].text == SplayerSide && Sbuttonlist[8].text == SplayerSide || Sbuttonlist[4].text == SplayerSide && Sbuttonlist[6].text == SplayerSide)
        {
            validMoves.Remove(2);
        }
        if (Sbuttonlist[0].text == SplayerSide && Sbuttonlist[6].text == SplayerSide || Sbuttonlist[4].text == SplayerSide && Sbuttonlist[5].text == SplayerSide)
        {
            validMoves.Remove(3);
        }

        if (Sbuttonlist[0].text == SplayerSide && Sbuttonlist[3].text == SplayerSide || Sbuttonlist[7].text == SplayerSide && Sbuttonlist[8].text == SplayerSide || Sbuttonlist[4].text == SplayerSide && Sbuttonlist[2].text == SplayerSide)
        {
            validMoves.Remove(6);
        }
        if (Sbuttonlist[2].text == SplayerSide && Sbuttonlist[8].text == SplayerSide || Sbuttonlist[4].text == SplayerSide && Sbuttonlist[3].text == SplayerSide)
        {
            validMoves.Remove(5);
        }

        if (Sbuttonlist[2].text == SplayerSide && Sbuttonlist[5].text == SplayerSide || Sbuttonlist[7].text == SplayerSide && Sbuttonlist[6].text == SplayerSide || Sbuttonlist[4].text == SplayerSide && Sbuttonlist[0].text == SplayerSide)
        {
            validMoves.Remove(8);
        }
        if (Sbuttonlist[1].text == SplayerSide && Sbuttonlist[4].text == SplayerSide || Sbuttonlist[6].text == SplayerSide && Sbuttonlist[8].text == SplayerSide)
        {
            validMoves.Remove(7);
        }
    }

    void BotMove()
    {
        if (Sbuttonlist[Svalue].GetComponentInParent<Button>().interactable == true)
        {                                   
            Sbuttonlist[Svalue].text = SGetComputerSide();
            Sbuttonlist[Svalue].GetComponentInParent<Button>().interactable = false;
            SEndTurn();
        }
    }





    void SSetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < Sbuttonlist.Length; i++)
        {
            Sbuttonlist[i].GetComponentInParent<SGridSpace>().SSetGameControllerReference(this);
        }
    }


    public void SSetStartingSide(string SstartingSide)
    {
        SplayerSide = SstartingSide;
        if (SplayerSide == "X")
        {
            ScomputerSide = "O";
            SSetPlayerColors(SplayerX, SplayerO);
        }
        else
        {
            ScomputerSide = "X";
            SSetPlayerColors(SplayerO, SplayerX);
        }

        SStartGame();
    }

    void SStartGame()
    {
        SSetBoardInteractable(true);
        SSetPlayerButtons(false);
        SstartInfo.SetActive(false);
    }

    public string SGetPlayerSide()
    {
        return SplayerSide;
    }

    public string SGetComputerSide()
    {
        return ScomputerSide;
    }

    public void SEndTurn()
    {
        SmoveCount++;

        if (Sbuttonlist[0].text == SplayerSide && Sbuttonlist[1].text == SplayerSide && Sbuttonlist[2].text == SplayerSide)
        {
            SGameOver(SplayerSide);
        }
        else if (Sbuttonlist[3].text == SplayerSide && Sbuttonlist[4].text == SplayerSide && Sbuttonlist[5].text == SplayerSide)
        {
            SGameOver(SplayerSide);
        }
        else if (Sbuttonlist[6].text == SplayerSide && Sbuttonlist[7].text == SplayerSide && Sbuttonlist[8].text == SplayerSide)
        {
            SGameOver(SplayerSide);
        }
        else if (Sbuttonlist[0].text == SplayerSide && Sbuttonlist[3].text == SplayerSide && Sbuttonlist[6].text == SplayerSide)
        {
            SGameOver(SplayerSide);
        }
        else if (Sbuttonlist[1].text == SplayerSide && Sbuttonlist[4].text == SplayerSide && Sbuttonlist[7].text == SplayerSide)
        {
            SGameOver(SplayerSide);
        }
        else if (Sbuttonlist[2].text == SplayerSide && Sbuttonlist[5].text == SplayerSide && Sbuttonlist[8].text == SplayerSide)
        {
            SGameOver(SplayerSide);
        }
        else if (Sbuttonlist[0].text == SplayerSide && Sbuttonlist[4].text == SplayerSide && Sbuttonlist[8].text == SplayerSide)
        {
            SGameOver(SplayerSide);
        }
        else if (Sbuttonlist[2].text == SplayerSide && Sbuttonlist[4].text == SplayerSide && Sbuttonlist[6].text == SplayerSide)
        {
            SGameOver(SplayerSide);
        }



        else if (Sbuttonlist[0].text == ScomputerSide && Sbuttonlist[1].text == ScomputerSide && Sbuttonlist[2].text == ScomputerSide)
        {
            SGameOver(ScomputerSide);
        }
        else if (Sbuttonlist[3].text == ScomputerSide && Sbuttonlist[4].text == ScomputerSide && Sbuttonlist[5].text == ScomputerSide)
        {
            SGameOver(ScomputerSide);
        }
        else if (Sbuttonlist[6].text == ScomputerSide && Sbuttonlist[7].text == ScomputerSide && Sbuttonlist[8].text == ScomputerSide)
        {
            SGameOver(ScomputerSide);
        }
        else if (Sbuttonlist[0].text == ScomputerSide && Sbuttonlist[3].text == ScomputerSide && Sbuttonlist[6].text == ScomputerSide)
        {
            SGameOver(ScomputerSide);
        }
        else if (Sbuttonlist[1].text == ScomputerSide && Sbuttonlist[4].text == ScomputerSide && Sbuttonlist[7].text == ScomputerSide)
        {
            SGameOver(ScomputerSide);
        }
        else if (Sbuttonlist[2].text == ScomputerSide && Sbuttonlist[5].text == ScomputerSide && Sbuttonlist[8].text == ScomputerSide)
        {
            SGameOver(ScomputerSide);
        }
        else if (Sbuttonlist[0].text == ScomputerSide && Sbuttonlist[4].text == ScomputerSide && Sbuttonlist[8].text == ScomputerSide)
        {
            SGameOver(ScomputerSide);
        }
        else if (Sbuttonlist[2].text == ScomputerSide && Sbuttonlist[4].text == ScomputerSide && Sbuttonlist[6].text == ScomputerSide)
        {
            SGameOver(ScomputerSide);
        }




        else if (SmoveCount >= 9)
        {
            SGameOver("draw");
        }
        else
        {
            SChangeSide();
            Sdelay = 10;
        }
    }

    void SSetPlayerColors(SPlayer SnewPlayer, SPlayer SoldPlayer)
    {
        SnewPlayer.Spanel.color = SactivePlayerColor.SpanelColor;
        SnewPlayer.Stext.color = SactivePlayerColor.StextColor;
        SoldPlayer.Spanel.color = SinactivePlayerColor.SpanelColor;
        SoldPlayer.Stext.color = SinactivePlayerColor.StextColor;
    }

    void SGameOver(string SwiningPlayer)
    {
        SSetBoardInteractable(false);

        if (SwiningPlayer == "draw")
        {
            SSetGameOverText("Draw!");
            SSetPlayersColorsInactive();
        }
        else
        {
            SSetGameOverText(SwiningPlayer + " Loses!");
        }

        SrestartButton.SetActive(true);
        validMoves.Clear();

    }

    void SChangeSide()
    {
        SplayerMove = (SplayerMove == true) ? false : true;
        if (SplayerMove == true)
        {
            SSetPlayerColors(SplayerX, SplayerO);
        }
        else
        {
            SSetPlayerColors(SplayerO, SplayerX);
        }
    }

    void SSetGameOverText(string Svalue)
    {
        SgameOverPanel.SetActive(true);
        SgameOverText.text = Svalue;
    }

    public void SRestartGame()
    {
        SmoveCount = 0;
        SgameOverPanel.SetActive(false);
        for (int i = 0; i < Sbuttonlist.Length; i++)
        {
            Sbuttonlist[i].text = "";
        }

        SrestartButton.SetActive(false);
        SSetPlayerButtons(true);
        SSetPlayersColorsInactive();
        SstartInfo.SetActive(true);
        SplayerMove = true;
        Sdelay = 10;
        validMoves.Clear();
    }

    void SSetBoardInteractable(bool Stoggle)
    {
        for (int i = 0; i < Sbuttonlist.Length; i++)
        {
            Sbuttonlist[i].GetComponentInParent<Button>().interactable = Stoggle;
        }
    }

    void SSetPlayerButtons(bool Stoggle)
    {
        SplayerX.Sbutton.interactable = Stoggle;
        SplayerO.Sbutton.interactable = Stoggle;
    }

    void SSetPlayersColorsInactive()
    {
        SplayerX.Spanel.color = SinactivePlayerColor.SpanelColor;
        SplayerX.Stext.color = SinactivePlayerColor.StextColor;
        SplayerO.Spanel.color = SinactivePlayerColor.SpanelColor;
        SplayerO.Stext.color = SinactivePlayerColor.StextColor;
    }
}
