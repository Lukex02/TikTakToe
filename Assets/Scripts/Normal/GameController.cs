using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player
{
    public Image panel;
    public Text text;
    public Button button;
}

[System.Serializable]
public class PlayerColor
{
    public Color panelColor;
    public Color textColor;
}

public class GameController : MonoBehaviour
{
    public Text[] buttonlist;
    private string playerSide;
    public GameObject gameOverPanel;
    public Text gameOverText;
    private int moveCount;
    public GameObject restartButton;
    public Player playerX;
    public Player playerO;
    public PlayerColor activePlayerColor;
    public PlayerColor inactivePlayerColor;
    public GameObject startInfo;

    private string computerSide;
    public bool playerMove;
    public float delay;
    private int value;


    void Awake()
    {
        SetGameControllerReferenceOnButtons();
        gameOverPanel.SetActive(false);
        moveCount = 0;
        restartButton.SetActive(false);
        playerMove = true;
    }

    void Update()
    {
        if (playerMove == false)
        {
            delay += delay * Time.deltaTime;
            if (delay >=80)
            {
                
                value = Random.Range(0, 8);
                if (buttonlist[value].GetComponentInParent<Button>().interactable == true)
                {
                    buttonlist[value].text = GetComputerSide();
                    buttonlist[value].GetComponentInParent<Button>().interactable = false;
                    EndTurn();
                }
            }
        }
    }

    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonlist.Length; i++)
        {
            buttonlist[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }


    public void SetStartingSide(string startingSide)
    {
        playerSide = startingSide;
        if (playerSide == "X")
        {
            computerSide = "O";
            SetPlayerColors(playerX, playerO);
        }
        else
        {
            computerSide = "X";
            SetPlayerColors(playerO, playerX);
        }

        StartGame();
    }

    void StartGame()
    {
        SetBoardInteractable(true);
        SetPlayerButtons(false);
        startInfo.SetActive(false);
    }

    public string GetPlayerSide()
    {
        return playerSide;
    }

    public string GetComputerSide()
    {
        return computerSide;
    }

    public void EndTurn()
    {
        moveCount++;

        if (buttonlist[0].text == playerSide && buttonlist[1].text == playerSide && buttonlist[2].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonlist[3].text == playerSide && buttonlist[4].text == playerSide && buttonlist[5].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonlist[6].text == playerSide && buttonlist[7].text == playerSide && buttonlist[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonlist[0].text == playerSide && buttonlist[3].text == playerSide && buttonlist[6].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonlist[1].text == playerSide && buttonlist[4].text == playerSide && buttonlist[7].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonlist[2].text == playerSide && buttonlist[5].text == playerSide && buttonlist[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonlist[0].text == playerSide && buttonlist[4].text == playerSide && buttonlist[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonlist[2].text == playerSide && buttonlist[4].text == playerSide && buttonlist[6].text == playerSide)
        {
            GameOver(playerSide);
        }



        else if (buttonlist[0].text == computerSide && buttonlist[1].text == computerSide && buttonlist[2].text == computerSide)
        {
            GameOver(computerSide);
        }
        else if (buttonlist[3].text == computerSide && buttonlist[4].text == computerSide && buttonlist[5].text == computerSide)
        {
            GameOver(computerSide);
        }
        else if (buttonlist[6].text == computerSide && buttonlist[7].text == computerSide && buttonlist[8].text == computerSide)
        {
            GameOver(computerSide);
        }
        else if (buttonlist[0].text == computerSide && buttonlist[3].text == computerSide && buttonlist[6].text == computerSide)
        {
            GameOver(computerSide);
        }
        else if (buttonlist[1].text == computerSide && buttonlist[4].text == computerSide && buttonlist[7].text == computerSide)
        {
            GameOver(computerSide);
        }
        else if (buttonlist[2].text == computerSide && buttonlist[5].text == computerSide && buttonlist[8].text == computerSide)
        {
            GameOver(computerSide);
        }
        else if (buttonlist[0].text == computerSide && buttonlist[4].text == computerSide && buttonlist[8].text == computerSide)
        {
            GameOver(computerSide);
        }
        else if (buttonlist[2].text == computerSide && buttonlist[4].text == computerSide && buttonlist[6].text == computerSide)
        {
            GameOver(computerSide);
        }


        else if (moveCount >= 9)
        {
            GameOver("draw");
        }
        else
        {
            ChangeSide();
            delay = 10;
        }
    }

    void SetPlayerColors(Player newPlayer, Player oldPlayer)
    {
        newPlayer.panel.color = activePlayerColor.panelColor;
        newPlayer.text.color = activePlayerColor.textColor;
        oldPlayer.panel.color = inactivePlayerColor.panelColor;
        oldPlayer.text.color = inactivePlayerColor.textColor;
    }

    void GameOver(string winingPlayer)
    {
        SetBoardInteractable(false);

        if (winingPlayer == "draw")
        {
            SetGameOverText("Draw!");
            SetPlayersColorsInactive();
        }
        else
        {
            SetGameOverText(winingPlayer + " Loses!");
        }

        restartButton.SetActive(true);

    }

    void ChangeSide()
    {
        playerMove = (playerMove == true) ? false : true;
        if (playerMove == true)
        {
            SetPlayerColors(playerX, playerO);
        }
        else
        {
            SetPlayerColors(playerO, playerX);
        }
    }

    void SetGameOverText(string value)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }

    public void RestartGame()
    {
        moveCount = 0;
        gameOverPanel.SetActive(false);
        for (int i = 0; i < buttonlist.Length; i++)
        {
            buttonlist[i].text = "";
        }

        restartButton.SetActive(false);
        SetPlayerButtons(true);
        SetPlayersColorsInactive();
        startInfo.SetActive(true);
        playerMove = true;
        delay = 10;
    }

    void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < buttonlist.Length; i++)
        {
            buttonlist[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }

    void SetPlayerButtons(bool toggle)
    {
        playerX.button.interactable = toggle;
        playerO.button.interactable = toggle;
    }

    void SetPlayersColorsInactive()
    {
        playerX.panel.color = inactivePlayerColor.panelColor;
        playerX.text.color = inactivePlayerColor.textColor;
        playerO.panel.color = inactivePlayerColor.panelColor;
        playerO.text.color = inactivePlayerColor.textColor;
    }
}
