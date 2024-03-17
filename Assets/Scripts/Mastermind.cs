using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Mastermind : MonoBehaviour
{
    public Sprite Yellow, Blue, Red, Green, White, Black; //Sprite color
    public string[] secretCode = new string[4]; //Store the code of mastermind
    public string[] secretCodeTemp = new string[4]; //Temporary array
    private Dictionary<string, Sprite> dicoSprite = new Dictionary<string, Sprite>();//map string color and sprite
    private string[] codePlayer = new string[4];//Store array for wrong position
    public GameObject HiddenSlot; //Slot for hide the code of mastermind
    void Awake()
    {
        //assign sprite in dictionary
        dicoSprite.Add("yellow", Yellow);
        dicoSprite.Add("blue", Blue);
        dicoSprite.Add("red", Red);
        dicoSprite.Add("green", Green);
        dicoSprite.Add("white", White);
        dicoSprite.Add("black", Black);
    }

    /// <summary>
    /// Random generation of a new color code
    /// </summary>
    /// <returns>array of 4 colors string</returns>
    public Array GetNewSecretCode()
    {
        for (int i = 0; i < 4; i++)
        {
            int rnd = UnityEngine.Random.Range(0, dicoSprite.Count);
            secretCode.SetValue(dicoSprite.ElementAt(rnd).Key, i);
        }

        transform.Find("c1").GetComponent<Image>().sprite = dicoSprite[secretCode.GetValue(0).ToString()];
        transform.Find("c2").GetComponent<Image>().sprite = dicoSprite[secretCode.GetValue(1).ToString()];
        transform.Find("c3").GetComponent<Image>().sprite = dicoSprite[secretCode.GetValue(2).ToString()];
        transform.Find("c4").GetComponent<Image>().sprite = dicoSprite[secretCode.GetValue(3).ToString()];

        return secretCode;
    }

    /// <summary>
    /// Number of well-placed colors
    /// </summary>
    /// <param name="code">Array of 4 colors string</param>
    /// <returns>Int</returns>
    public int GetGoodPosition(string[] code)
    {
        Array.Copy(secretCode, secretCodeTemp, secretCode.Length);

        int good = 0;
        for (int i = 0; i < secretCodeTemp.Length; i++)
        {
            if(code[i]==secretCodeTemp[i])
            {
                good++;
                code[i] = "good";
                secretCodeTemp[i] = "good";
            }
        }
        Array.Copy(code, codePlayer, code.Length);
        return good;
    }

    /// <summary>
    /// Misplaced number of colors
    /// </summary>
    /// <returns>Int</returns>
    public int GetWrongPosition()
    {
        int wrong = 0;
        for (int i = 0; i < codePlayer.Length; i++)
        {
            for (int j = 0; j < secretCodeTemp.Length; j++)
            {
                if (codePlayer[i] == secretCodeTemp[j] && codePlayer[i]!="good" && secretCodeTemp[j]!="good")
                {
                    secretCodeTemp[j] = "wrong";
                    wrong++;
                    break;
                }
            }
        }
        return wrong;
    }
}


