using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] Image RightBar;
    [SerializeField] Image LeftBar;

    // Update is called once per frame
    public void ShowResult(float leftmass, float rightmass)
    {
        float sum = leftmass + rightmass;

        float l_ratio = leftmass / sum;
        float r_ratio = rightmass / sum;

        if (leftmass > rightmass)
        {
            LeftBar.fillAmount = l_ratio - r_ratio;
            RightBar.fillAmount = 0;
        }
        else if (rightmass > leftmass)
        {
            RightBar.fillAmount = r_ratio - l_ratio;
            LeftBar.fillAmount = 0;
        }
        else
        {
            LeftBar.fillAmount = 0;
            RightBar.fillAmount = 0;
        }

    }
}
