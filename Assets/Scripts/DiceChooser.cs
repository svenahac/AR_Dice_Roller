using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiceChooser : MonoBehaviour
{
  
    public static string D4 = "0";
    public static string D6 = "0";
    public static string D8 = "0";
    public static string D10 = "0";
    public static string D12 = "0";
    public static string D20 = "0";
     


     public void incrementD4()
     {
         int d4 = int.Parse(D4);
         d4++;
         D4 = d4.ToString();
     }

     public void decrementD4()
     {
         int d4 = int.Parse(D4);
         if(d4 > 0){
            d4--;
            D4 = d4.ToString();
         }
     }

     public void incrementD6()
     {
         int d6 = int.Parse(D6);
         d6++;
         D6 = d6.ToString();
     }

     public void decrementD6()
     {
         int d6 = int.Parse(D6);
         if(d6 > 0){
            d6--;
            D6 = d6.ToString();
         }
     }

     public void incrementD8()
     {
         int d8 = int.Parse(D8);
         d8++;
         D8 = d8.ToString();
     }

     public void decrementD8()
     {
         int d8 = int.Parse(D8);
         if(d8 > 0){
            d8--;
            D8 = d8.ToString();
         }
     }

     public void incrementD10()
     {
         int d10 = int.Parse(D10);
         d10++;
         D10 = d10.ToString();
     }

     public void decrementD10()
     {
         int d10 = int.Parse(D10);
         if(d10 > 0){
            d10--;
            D10 = d10.ToString();
         }
     }

     public void incrementD12()
     {
         int d12 = int.Parse(D12);
         d12++;
         D12 = d12.ToString();
     }

     public void decrementD12()
     {
         int d12 = int.Parse(D12);
         if(d12 > 0){
            d12--;
            D12 = d12.ToString();
         }
     }

     public void incrementD20()
     {
         int d20 = int.Parse(D20);
         d20++;
         D20 = d20.ToString();
     }

     public void decrementD20()
     {
         int d20 = int.Parse(D20);
         if(d20 > 0){
            d20--;
            D20 = d20.ToString();
         }
     }
     void Start(){
        SetDicePlaceholders();
     }

     void Update(){
         
        SetDicePlaceholders();
     }

     public void SetDicePlaceholders(){
        GameObject.Find("D4Amount").GetComponent<TextMeshProUGUI>().text = D4;
        GameObject.Find("D6Amount").GetComponent<TextMeshProUGUI>().text = D6;
        GameObject.Find("D8Amount").GetComponent<TextMeshProUGUI>().text = D8;
        GameObject.Find("D10Amount").GetComponent<TextMeshProUGUI>().text = D10;
        GameObject.Find("D12Amount").GetComponent<TextMeshProUGUI>().text = D12;
        GameObject.Find("D20Amount").GetComponent<TextMeshProUGUI>().text = D20;
     }
     
}
