using Cinemachine;
using System.Collections;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public enum CameraType
    {
        AwakeCamera,
        DefaultCamera,
        ProjectCamera,
        AboutCamera,
        CreditCamera,
        WorkCamera,
    }

    [SerializeField] private CameraType activeCameraType; // For debugging

    public CinemachineVirtualCamera awakeCamera;
    public CinemachineVirtualCamera defaultCamera;
    public CinemachineVirtualCamera projectCamera;
    public CinemachineVirtualCamera aboutCamera;
    public CinemachineVirtualCamera creditCamera;
    public CinemachineVirtualCamera workCamera;

    private bool init = false;

    private void OnValidate()
    {
        ActivateCamera(activeCameraType);
    }

    private void Start()
    {
        StartCoroutine(InitialCamera());
    }

    IEnumerator InitialCamera()
    {
        ActivateCamera(CameraType.AwakeCamera);
        yield return new WaitForSeconds(1f);
        ActivateCamera(CameraType.DefaultCamera);
        AudioManager.instance.PlaySoundEffect(SoundEffect.StartRing);
        AudioManager.instance.PlayBackgroundMusic();
        init = true;
    }

    public void ActivateAwakeCamera() => ActivateCamera(CameraType.AwakeCamera);
    public void ActivateDefaultCamera()
    {
        if (init) { AudioManager.instance.PlaySoundEffect(SoundEffect.UIClick); }
        ActivateCamera(CameraType.DefaultCamera);
    } 
    public void ActivateProjectCamera() => ActivateCamera(CameraType.ProjectCamera);
    public void ActivateAboutCamera() => ActivateCamera(CameraType.AboutCamera);
    public void ActivateCreditCamera() => ActivateCamera(CameraType.CreditCamera);
    public void ActivateWorkCamera() => ActivateCamera(CameraType.WorkCamera);

    public void ActivateCamera(CameraType cameraType)
    {
        SetAllCamerasPriority(0);

        switch (cameraType)
        {
            case CameraType.AwakeCamera: 
                awakeCamera.Priority = 10;
                break;
            case CameraType.DefaultCamera: 
                defaultCamera.Priority = 10;
                DisableCurrentContents();
                break;
            case CameraType.ProjectCamera: 
                projectCamera.Priority = 10;
                StartCoroutine(ActivateGameobjectAfterDelay(UIController.Instance.projectScreenContents.gameObject, 1.5f));
                break;
            case CameraType.AboutCamera: 
                aboutCamera.Priority = 10;
                StartCoroutine(ActivateGameobjectAfterDelay(UIController.Instance.aboutMeContents.gameObject, 1.8f));
                break;
            case CameraType.CreditCamera: 
                creditCamera.Priority = 10;
                StartCoroutine(ActivateGameobjectAfterDelay(UIController.Instance.creditsContents.gameObject, 0.5f));
                break;
            case CameraType.WorkCamera:
                workCamera.Priority = 10;
                StartCoroutine(ActivateGameobjectAfterDelay(UIController.Instance.workExperienceContents.gameObject, 0.5f));
                break;
        }

        // Update active camera type for debugging
        activeCameraType = cameraType;
    }

    private void SetAllCamerasPriority(int priority)
    {
        awakeCamera.Priority = priority;
        defaultCamera.Priority = priority;
        projectCamera.Priority = priority;
        aboutCamera.Priority = priority;
        creditCamera.Priority = priority;
        workCamera.Priority = priority;
    }

    private void DisableCurrentContents()
    {
        UIController.Instance.projectScreenContents?.gameObject.SetActive(false);
        UIController.Instance.aboutMeContents?.gameObject.SetActive(false);
        UIController.Instance.creditsContents?.gameObject.SetActive(false); 
        UIController.Instance.workExperienceContents?.gameObject.SetActive(false);
    }

    IEnumerator ActivateGameobjectAfterDelay(GameObject content, float delay)
    {
        yield return new WaitForSeconds(delay);
        content.SetActive(true);
    }
}
