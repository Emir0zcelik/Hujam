using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private GameObject _buildPanel;
    [SerializeField] private GameObject _buildMenu;

    public void SetBuildPanelActive()
    {
        _buildPanel.SetActive(true);
        _buildMenu.SetActive(false);
        gameObject.SetActive(false);
    }
}
