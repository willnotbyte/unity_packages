using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipController : MonoBehaviour
{
    public bool hintsEnabled = true;
    public bool canShow = true;
    public bool isShowing = false;
    public int duration = 5;
    public Text tooltipText;
    public GameObject tooltipBox;
    public int coolDownTime = 5;
    
    public void SetText(string data)
    {
        tooltipText.text = data;
    }

    public IEnumerator ShowText()
    {
        tooltipBox.SetActive(true);
        canShow = false;
        isShowing = true;
        //Sound Effect****
        yield return new WaitForSeconds(duration);
        tooltipBox.SetActive(false);
        isShowing = false;
        tooltipText.text = "";
        StartCoroutine(Cooldown());
    }

    public void ForceShutdown()
    {
        tooltipBox.SetActive(false);
        isShowing = false;
        canShow = false;
        tooltipText.text = "";
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(coolDownTime);
        canShow = true;

    }
}
