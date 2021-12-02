using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject[] pausedObjects;
    public GameObject[] gameOverObjects;
    public GameObject[] playerUIObjects;

    #region Pause Methods
    public void showPaused()
    {
        foreach (var g in pausedObjects)
        {
            g.SetActive(true);
        }
    }
    
    public void hidePaused()
    {
        foreach (var g in pausedObjects)
        {
            g.SetActive(false);
        }
    }
    #endregion
    #region Game Over Methods
    public void showGameOver()
    {
        foreach (var g in gameOverObjects)
        {
            g.SetActive(true);
        }
    }

    public void hideGameOver()
    {
        foreach (var g in gameOverObjects)
        {
            g.SetActive(false);
        }
    }
    #endregion
    #region UI Methods
    public void showUI()
    {
        foreach (var g in playerUIObjects)
        {
            g.SetActive(true);
        }
    }

    public void hideUI()
    {
        foreach (var g in playerUIObjects)
        {
            g.SetActive(false);
        }
    }
    #endregion
}
