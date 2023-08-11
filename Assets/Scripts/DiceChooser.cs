using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceChooser : MonoBehaviour
{
   
    public static string D4 = "0";
    public static string D6;
    public static string D8;
    public static string D10;
    public static string D12;
    public static string D20;
    public static string D100;
    public static string Dpercent;

   public void ReadD4(string s)
   {
       D4 = s;
   }

    public void ReadD6(string s)
    {
         D6 = s;
    }

    public void ReadD8(string s)
    {
         D8 = s;
    }

    public void ReadD10(string s)
    {
         D10 = s;
    }

    public void ReadD12(string s)
    {
         D12 = s;
    }

    public void ReadD20(string s)
    {
         D20 = s;
    }

    public void ReadD100(string s)
    {
         D100 = s;
    }

    public void ReadDPercent(string s)
    {
         Dpercent = s;
    }
}
