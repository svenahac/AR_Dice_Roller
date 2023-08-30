using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MainSceneManager : MonoBehaviour
{

    [SerializeField]
    private GameObject prefabD4;
    [SerializeField]
    private GameObject prefabD6;
    [SerializeField]
    private GameObject prefabD8;
    [SerializeField]
    private GameObject prefabD10;
    [SerializeField]
    private GameObject prefabD12;
    [SerializeField]
    private GameObject prefabD20;

    private ARRaycastManager raycastManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public static List<GameObject> aliveDice = new List<GameObject>();
    public static int[][] rolls;

    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    public void RefreshDice()
    {
        foreach (GameObject die in aliveDice)
        {
            Destroy(die);
        }

        aliveDice = new List<GameObject>();

        for (int die = 0; die < 6; die++)
        {
            for (int i = 0; i < DiceChooserManager.dices[die]; i++)
            {
                Vector2 centerPos = new Vector2(
                    Screen.width / 2 + Random.Range(-250, 250),
                    Screen.height / 2 + Random.Range(-250, 250)
                    );

                if (raycastManager.Raycast(centerPos, hits, TrackableType.PlaneWithinPolygon))
                {
                    foreach (ARRaycastHit hit in hits)
                    {
                        Pose pose = hits[0].pose;
                        instantiateDie(pose, die);
                    }
                }
            }
        }
    }

    private void instantiateDie(Pose pose, int die)
    {
        GameObject obj;

        switch (die)
        {
            case 0:
                obj = Instantiate(prefabD4, pose.position, pose.rotation);
                break;
            case 1:
                obj = Instantiate(prefabD6, pose.position, pose.rotation);
                break;
            case 2:
                obj = Instantiate(prefabD8, pose.position, pose.rotation);
                break;
            case 3:
                obj = Instantiate(prefabD10, pose.position, pose.rotation);
                break;
            case 4:
                obj = Instantiate(prefabD12, pose.position, pose.rotation);
                break;
            case 5:
                obj = Instantiate(prefabD20, pose.position, pose.rotation);
                break;
            default:
                obj = Instantiate(prefabD6, pose.position, pose.rotation);
                break;
        }

        aliveDice.Add(obj);
    }

    public void RollDice()
    {
        rolls = new int[6][];
        rolls[0] = new int[4];
        rolls[1] = new int[6];
        rolls[2] = new int[8];
        rolls[3] = new int[10];
        rolls[4] = new int[12];
        rolls[5] = new int[20];

        foreach (GameObject die in aliveDice) 
        {
            RollDie(die);
        }
    }

    private void RollDie(GameObject die)
    {
        die.GetComponent<Rigidbody>().isKinematic = false;
        die.GetComponent<Rigidbody>().AddForce(Vector3.up * 150);

        die.GetComponent<Rigidbody>().AddTorque(
            Random.Range(0, 5),
            Random.Range(0, 5),
            Random.Range(0, 5)
            );

        StartCoroutine(ReadRollResult(die));
    }

    private IEnumerator ReadRollResult(GameObject die)
    {
        yield return new WaitForFixedUpdate();

        while (die.GetComponent<Rigidbody>().angularVelocity.sqrMagnitude > 0.05)
        {
            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds(2);

        if (die.name.StartsWith("d4")) rolls[0][CheckRollD4(die) - 1]++;
        else if (die.name.StartsWith("d6")) rolls[1][CheckRollD6(die) - 1]++;
        else if (die.name.StartsWith("d8")) rolls[2][CheckRollD8(die) - 1]++;
        else if (die.name.StartsWith("d10")) rolls[3][CheckRollD10(die) - 1]++;
        else if (die.name.StartsWith("d12")) rolls[4][CheckRollD12(die) - 1]++;
        else if (die.name.StartsWith("d20")) rolls[5][CheckRollD20(die) - 1]++;

        WriteRollResults();
    }

    private void WriteRollResults()
    {
        GameObject.Find("D4Stats").GetComponent<TextMeshProUGUI>().text = "D4:";
        int sumD4 = 0;
        for (int i = 1; i <= 4; i++) 
        {
            if (rolls[0][i - 1] == 0) continue;
            if (rolls[0][i - 1] == 1) GameObject.Find("D4Stats").GetComponent<TextMeshProUGUI>().text += " + " + i;
            else GameObject.Find("D4Stats").GetComponent<TextMeshProUGUI>().text += " + " + rolls[0][i - 1] + "x" + i;
            sumD4 += rolls[0][i - 1] * i;
        }
        GameObject.Find("D4Stats").GetComponent<TextMeshProUGUI>().text += " = " + sumD4;

        GameObject.Find("D6Stats").GetComponent<TextMeshProUGUI>().text = "D6:";
        int sumD6 = 0;
        for (int i = 1; i <= 6; i++)
        {
            if (rolls[1][i - 1] == 0) continue;
            if (rolls[1][i - 1] == 1) GameObject.Find("D6Stats").GetComponent<TextMeshProUGUI>().text += " + " + i;
            else GameObject.Find("D6Stats").GetComponent<TextMeshProUGUI>().text += " + " + rolls[1][i - 1] + "x" + i;
            sumD6 += rolls[1][i - 1] * i;
        }
        GameObject.Find("D6Stats").GetComponent<TextMeshProUGUI>().text += " = " + sumD6;

        GameObject.Find("D8Stats").GetComponent<TextMeshProUGUI>().text = "D8:";
        int sumD8 = 0;
        for (int i = 1; i <= 8; i++)
        {
            if (rolls[2][i - 1] == 0) continue;
            if (rolls[2][i - 1] == 1) GameObject.Find("D8Stats").GetComponent<TextMeshProUGUI>().text += " + " + i;
            else GameObject.Find("D8Stats").GetComponent<TextMeshProUGUI>().text += " + " + rolls[2][i - 1] + "x" + i;
            sumD8 += rolls[2][i - 1] * i;
        }
        GameObject.Find("D8Stats").GetComponent<TextMeshProUGUI>().text += " = " + sumD8;

        GameObject.Find("D10Stats").GetComponent<TextMeshProUGUI>().text = "D10:";
        int sumD10 = 0;
        for (int i = 1; i <= 10; i++)
        {
            if (rolls[3][i - 1] == 0) continue;
            if (rolls[3][i - 1] == 1) GameObject.Find("D10Stats").GetComponent<TextMeshProUGUI>().text += " + " + i;
            else GameObject.Find("D10Stats").GetComponent<TextMeshProUGUI>().text += " + " + rolls[3][i - 1] + "x" + i;
            sumD10 += rolls[3][i - 1] * i;
        }
        GameObject.Find("D10Stats").GetComponent<TextMeshProUGUI>().text += " = " + sumD10;

        GameObject.Find("D12Stats").GetComponent<TextMeshProUGUI>().text = "D12:";
        int sumD12 = 0;
        for (int i = 1; i <= 12; i++)
        {
            if (rolls[4][i - 1] == 0) continue;
            if (rolls[4][i - 1] == 1) GameObject.Find("D12Stats").GetComponent<TextMeshProUGUI>().text += "  + " + i;
            else GameObject.Find("D12Stats").GetComponent<TextMeshProUGUI>().text += " + " + rolls[4][i - 1] + "x" + i;
            sumD12 += rolls[4][i - 1] * i;
        }
        GameObject.Find("D12Stats").GetComponent<TextMeshProUGUI>().text += " = " + sumD12;

        GameObject.Find("D20Stats").GetComponent<TextMeshProUGUI>().text = "D20:";
        int sumD20 = 0;
        for (int i = 1; i <= 20; i++)
        {
            if (rolls[5][i - 1] == 0) continue;
            if (rolls[5][i - 1] == 1) GameObject.Find("D20Stats").GetComponent<TextMeshProUGUI>().text += " + " + i;
            else GameObject.Find("D20Stats").GetComponent<TextMeshProUGUI>().text += " + " + rolls[5][i - 1] + "x" + i;
            sumD20 += rolls[5][i - 1] * i;
        }
        GameObject.Find("D20Stats").GetComponent<TextMeshProUGUI>().text += " = " + sumD20;

        int totalSum = sumD4 + sumD6 + sumD8 + sumD10 + sumD12 + sumD20;
        GameObject.Find("TotalStats").GetComponent<TextMeshProUGUI>().text = "Total: " + totalSum;
    }

    public int CheckRollD4(GameObject die)
    {
        Vector3 vec = die.GetComponent<Rigidbody>().transform.right;
        int rollValue = 0;

        float y = vec.y;

        if (y >= -5 && y <= 5) rollValue = 1;
        else if (y >= -55 && y <= -45) rollValue = 2;
        else if (y >= 45 && y <= 55) rollValue = 3;
        else if (y >= -105 && y <= -95) rollValue = 4;

        return rollValue;
    }

    public int CheckRollD6(GameObject die)
    {
        int rollValue = 0;

        float x = Mathf.Round(Vector3.Dot(die.GetComponent<Rigidbody>().transform.right.normalized, Vector3.up));
        float y = Mathf.Round(Vector3.Dot(die.GetComponent<Rigidbody>().transform.up.normalized, Vector3.up));
        float z = Mathf.Round(Vector3.Dot(die.GetComponent<Rigidbody>().transform.forward.normalized, Vector3.up));

        switch (x)
        {
            case 1:
                rollValue = 2;
                break;
            case -1:
                rollValue = 5;
                break;
        }

        switch (y)
        {
            case 1:
                rollValue = 3;
                break;
            case -1:
                rollValue = 4;
                break;
        }

        switch (z)
        {
            case 1:
                rollValue = 1;
                break;
            case -1:
                rollValue = 6;
                break;
        }

        return rollValue;
    }

    public int CheckRollD8(GameObject die)
    {
        int rollValue = 0;

        Vector3 vec = die.GetComponent<Rigidbody>().transform.right;
        Vector3 vec1 = die.GetComponent<Rigidbody>().transform.up;
        Vector3 vec2 = die.GetComponent<Rigidbody>().transform.forward;

        float y = Mathf.Round(vec.y * 100);
        float y1 = Mathf.Round(vec1.y * 100);
        float y2 = Mathf.Round(vec2.y * 100);

        if (y >= 55 && y <= 60)
        {
            if (y1 >= 55 && y1 <= 60)
            {
                if (y2 >= 55 && y2 <= 60)
                {
                    rollValue = 8;
                }
                else if (y2 <= -55 && y2 >= -60)
                {
                    rollValue = 3;
                }
            }
            else if (y1 <= -55 && y1 >= -60)
            {
                if (y2 >= 55 && y2 <= 60)
                {
                    rollValue = 5;
                }
                else if (y2 <= -55 && y2 >= -60)
                {
                    rollValue = 2;
                }
            }
        }
        else if (y <= -55 && y >= -60)
        {
            if (y1 >= 55 && y1 <= 60)
            {
                if (y2 >= 55 && y2 <= 60)
                {
                    rollValue = 1;
                }
                else if (y2 <= -55 && y2 >= -60)
                {
                    rollValue = 6;
                }
            }
            else if (y1 <= -55 && y1 >= -60)
            {
                if (y2 >= 55 && y2 <= 60)
                {
                    rollValue = 4;
                }
                else if (y2 <= -55 && y2 >= -60)
                {
                    rollValue = 7;
                }
            }
        }

        return rollValue;
    }

    public int CheckRollD10(GameObject die)
    {
        int rollValue = 0;

        Vector3 vec = die.GetComponent<Rigidbody>().transform.right;
        Vector3 vec1 = die.GetComponent<Rigidbody>().transform.up;

        float y = Mathf.Round(vec.y * 100);
        float y1 = Mathf.Round(vec1.y * 100);

        if (y >= 47 && y <= 50)
        {
            if (y1 > 0) rollValue = 2;
            else rollValue = 3;
        }
        else if (y >= 76 && y <= 79)
        {
            if (y1 > 0) rollValue = 5;
            else rollValue = 8;
        }
        else if (y >= -79 && y <= -76)
        {
            if (y1 > 0) rollValue = 1;
            else rollValue = 4;
        }
        else if (y >= -50 && y <= -46)
        {
            if (y1 > 0) rollValue = 6;
            else rollValue = 7;
        }
        else if (y >= 0 && y <= 3)
        {
            if (y1 > 0) rollValue = 9;
            else rollValue = 10;
        }

        return rollValue;
    }

    public int CheckRollD12(GameObject die)
    {
        int rollValue = 0;

        Vector3 vec = die.GetComponent<Rigidbody>().transform.right;
        Vector3 vec1 = die.GetComponent<Rigidbody>().transform.up;
        Vector3 vec2 = die.GetComponent<Rigidbody>().transform.forward;

        float y = Mathf.Round(vec.y * 100);
        float y1 = Mathf.Round(vec1.y * 100);
        float y2 = Mathf.Round(vec2.y * 100);

        if (y > -2 && y <= 2)
        {
            if (y1 >= 83 && y1 <= 87)
            {
                if (y2 > 0) rollValue = 9;
                else rollValue = 5;
            }
            else if (y1 >= -86 && y1 <= -83)
            {
                if (y2 > 0) rollValue = 8;
                else rollValue = 4;
            }
        }
        else if (y >= 50 && y <= 55)
        {
            if (y2 > 0) rollValue = 7;
            else rollValue = 1;
        }
        else if (y >= -55 && y <= -50)
        {
            if (y2 > 0) rollValue = 12;
            else rollValue = 6;
        }
        else if (y >= 83 && y <= 87)
        {
            if (y1 > 0) rollValue = 3;
            else rollValue = 2;
        }
        else if (y >= -87 && y <= -83)
        {
            if (y1 > 0) rollValue = 11;
            else rollValue = 10;
        }

        return rollValue;
    }

    public int CheckRollD20(GameObject die)
    {
        int rollValue = 0;

        Vector3 vec = die.GetComponent<Rigidbody>().transform.right;
        Vector3 vec1 = die.GetComponent<Rigidbody>().transform.up;
        Vector3 vec2 = die.GetComponent<Rigidbody>().transform.forward;
        
        float y = Mathf.Round(vec.y * 100);
        float y1 = Mathf.Round(vec1.y * 100);
        float y2 = Mathf.Round(vec2.y * 100);

        if (y >= -5 && y <= 5)
        {
            if (y1 > 0)
            {
                if (y2 > 0) rollValue = 1;
                else rollValue = 2;
            }
            else
            {
                if (y2 > 0) rollValue = 20;
                else rollValue = 19;
            }
        }
        else if (y >= -100 && y < -90)
        {
            if (y2 > 0) rollValue = 4;
            else rollValue = 9;
        }
        else if (y >= -40 && y < -30)
        {
            if (y1 > 0) rollValue = 5;
            else rollValue = 13;
        }
        else if (y >= -70 && y < -45)
        {
            if (y1 > 0)
            {
                if (y2 > 0) rollValue = 18;
                else rollValue = 6;
            }
            else
            {
                if (y2 > 0) rollValue = 14;
                else rollValue = 11;
            }
        }
        else if (y > 60 && y <= 70)
        {
            if (y1 > 0) rollValue = 7;
            else rollValue = 8;
        }
        else if (y > 90 && y <= 100)
        {
            if (y2 > 0) rollValue = 10;
            else rollValue = 17;
        }
        else if (y > 10 && y <= 40)
        {
            if (y1 > 0) rollValue = 15;
            else rollValue = 16;
        }
        else if (y > 50 && y <= 60)
        {
            if (y1 > 0) rollValue = 12;
            else rollValue = 3;
        }

        return rollValue;
    }

}
