using UnityEngine;
using UnityEngine.UI;

public class ShowHideUI : MonoBehaviour
{
    [SerializeField] Image controls;
    [SerializeField] Image credits;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HideControls();
            HideCredits();
        }
    }
    public void ShowControls()
    {
        controls.gameObject.SetActive(true);
    }
    public void HideControls()
    {
        controls.gameObject.SetActive(false);
    }
    public void ShowCredits()
    {
        credits.gameObject.SetActive(true);
    }
    public void HideCredits()
    {
        credits.gameObject.SetActive(false);
    }
    public void CloseTheGame()
    {
        Application.Quit();
    }



}
