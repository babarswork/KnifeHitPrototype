using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject restartButton;

    [Header("Knife count Display")]
    [SerializeField]
    private GameObject panelKnifes;
    [SerializeField]
    private GameObject iconKnife;
    [SerializeField]
    private Color usedKnifeIconColor;

    public void ShowRestartBotton()
    {
        restartButton.SetActive(true);
    }

    public void SetInitialDisplayCount(int count)
    {
        for (int i = 0; i < count; i++)
        {
            // going to instantiate certain number of icons inside as children of panel
            Instantiate(iconKnife, panelKnifes.transform);
        }
    }
    // its representing the last icon to be thrown
    private int knifeIconIndexToChange = 0;
    public void DecrementDisplayedKnifeCount()
    {
        panelKnifes.transform.GetChild(knifeIconIndexToChange++).GetComponent<Image>().color = usedKnifeIconColor;
    }
}
