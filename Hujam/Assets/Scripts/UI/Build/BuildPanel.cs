using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPanel : MonoBehaviour
{
    [SerializeField] private GameObject _buildPanel;
    [SerializeField] private GameObject _buildMenu;
    [SerializeField] private GameObject _hud;
    public void SetBuildPanelDeactive()
    {
        gameObject.SetActive(false);
        _hud.SetActive(true);
        _buildMenu.SetActive(true);

    }
}
