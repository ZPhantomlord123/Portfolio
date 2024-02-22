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
        infoTab.SetActive(true);
        skillsTab.SetActive(false);
        miscTab.SetActive(false); 
    }

    public void ShowInfoTab()
    {
        AudioManager.instance.PlaySoundEffect(SoundEffect.UIClick);
        infoTab.SetActive(true);
        skillsTab.SetActive(false);
        miscTab.SetActive(false);
    }

    public void ShowSkillsTab()
    {
        AudioManager.instance.PlaySoundEffect(SoundEffect.UIClick);
        infoTab.SetActive(false);
        skillsTab.SetActive(true);
        miscTab.SetActive(false);
    }

    public void ShowMiscTab()
    {
        AudioManager.instance.PlaySoundEffect(SoundEffect.UIClick);
        infoTab.SetActive(false);
        skillsTab.SetActive(false);
        miscTab.SetActive(true);
    }

}
