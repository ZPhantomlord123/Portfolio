using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutMeController : MonoBehaviour
{
    [SerializeField] private GameObject infoTab;
    [SerializeField] private GameObject skillsTab;
    [SerializeField] private GameObject miscTab;
    private void OnEnable()
    {
        ShowInfoTab();
    }

    public void ShowInfoTab()
    {
        infoTab.SetActive(true);
        skillsTab.SetActive(false);
        miscTab.SetActive(false);
    }

    public void ShowSkillsTab()
    {
        infoTab.SetActive(false);
        skillsTab.SetActive(true);
        miscTab.SetActive(false);
    }

    public void ShowMiscTab()
    {
        infoTab.SetActive(false);
        skillsTab.SetActive(false);
        miscTab.SetActive(true);
    }

}
