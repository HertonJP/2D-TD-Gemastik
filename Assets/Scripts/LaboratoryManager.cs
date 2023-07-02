using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaboratoryManager : MonoBehaviour
{
    public GameObject CellPanel;
    public GameObject TBCPanel;

    //Cells
    [SerializeField] public GameObject[] CellsPanels;
    
    void Start()
    {
        CellPanel.SetActive(false);
        TBCPanel.SetActive(false);
    }

    public void onClickCellButton()
    {
        if (CellPanel.activeSelf == true)
        {
            CellPanel.SetActive(false);
        }
        else
        {
            CellPanel.SetActive(true);
            TBCPanel.SetActive(false);
            
        }
        for (int i = 0; i < CellsPanels.Length; i++)
        {
            CellsPanels[i].SetActive(false);
        }
    }
    public void onClickTBCButton()
    {
        if (TBCPanel.activeSelf == true)
        {
            TBCPanel.SetActive(false);
        }
        else
        {
            TBCPanel.SetActive(true);
            CellPanel.SetActive(false);
        }
        for (int i = 0; i < CellsPanels.Length; i++)
        {
            CellsPanels[i].SetActive(false);
        }
    }

    public void WBCbutton()
    {
        if (CellsPanels[0].activeSelf == true)
        {
            CellsPanels[0].SetActive(false);
        }
        else
        {
            CellsPanels[0].SetActive(true);
            
        }
    }
        
}
