using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance { get; private set; } // Singleton instance

    public ProjectScreenController projectScreenContents;
    public CreditsController creditsContents;
    public AboutMeController aboutMeContents;
    public WorkExperienceController workExperienceContents;

    private void Awake()
    {
        // Check if an instance already exists
        if (Instance != null && Instance != this)
        {
            // If true, destroy this instance
            Destroy(gameObject);
        }
        else
        {
            // Else, set this as the singleton instance
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Keep the instance alive across scene loads
        }
        Application.targetFrameRate = 60;
    }

    // Add your UI management methods here
    public void UpdateScoreDisplay(int newScore)
    {
        // Update the UI elements related to the score
    }

    public void ShowGameOverScreen()
    {
        // Activate the Game Over UI elements
    }

    // More UI-related methods can be added as needed
}
