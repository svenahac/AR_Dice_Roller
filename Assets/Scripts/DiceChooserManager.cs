using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiceChooserManager : MonoBehaviour
{

    public static int[] dices = new int[6];

    public static int d4 = 0;
    public static int d6 = 0;
    public static int d8 = 0;
    public static int d10 = 0;
    public static int d12 = 0;
    public static int d20 = 0;

    public void incrementD4()
    {
         d4++;
    }

    public void decrementD4()
    {
        if (d4 > 0)
        {
            d4--;  
        }
    }

    public void incrementD6()
    {
        d6++;
    }

    public void decrementD6()
    {
        if (d6 > 0)
        {
            d6--;
        }
    }

    public void incrementD8()
    {
        d8++;
    }

    public void decrementD8()
    {
        if (d8 > 0)
        {
            d8--;
        }
    }

    public void incrementD10()
    {
        d10++;
    }

    public void decrementD10()
    {
        if (d10 > 0)
        {
            d10--;
        }
    }

    public void incrementD12()
    {
        d12++;
    }

    public void decrementD12()
    {
        if (d12 > 0)
        {
            d12--;
        }
    }

    public void incrementD20()
    {
        d20++;
    }

    public void decrementD20()
    {
        if (d20 > 0)
        {
           d20--;
        }
    }

    public void Start()
    {
        GameObject.Find("D4Amount").GetComponent<TextMeshProUGUI>().text = dices[0].ToString();
        GameObject.Find("D6Amount").GetComponent<TextMeshProUGUI>().text = dices[1].ToString();
        GameObject.Find("D8Amount").GetComponent<TextMeshProUGUI>().text = dices[2].ToString();
        GameObject.Find("D10Amount").GetComponent<TextMeshProUGUI>().text = dices[3].ToString();
        GameObject.Find("D12Amount").GetComponent<TextMeshProUGUI>().text = dices[4].ToString();
        GameObject.Find("D20Amount").GetComponent<TextMeshProUGUI>().text = dices[5].ToString();
    }

    public void Update()
    {
        GameObject.Find("D4Amount").GetComponent<TextMeshProUGUI>().text = d4.ToString();
        GameObject.Find("D6Amount").GetComponent<TextMeshProUGUI>().text = d6.ToString();
        GameObject.Find("D8Amount").GetComponent<TextMeshProUGUI>().text = d8.ToString();
        GameObject.Find("D10Amount").GetComponent<TextMeshProUGUI>().text = d10.ToString();
        GameObject.Find("D12Amount").GetComponent<TextMeshProUGUI>().text = d12.ToString();
        GameObject.Find("D20Amount").GetComponent<TextMeshProUGUI>().text = d20.ToString();
    }

}
