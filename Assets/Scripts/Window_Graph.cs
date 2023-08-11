using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class NewBehaviourScript : MonoBehaviour
{
    private RectTransform graphContainer;
    private RectTransform labelTemplateX;
    private RectTransform labelTemplateY; 
    private List<GameObject> gameObjectList;

    private void Awake()
    {
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
        gameObjectList = new List<GameObject>();
        List<int> valueList = new List<int>() { 5, 4, 3, 6, 1, 3 };
        List<string> nameList = new List<string>() { "1", "2", "3", "4", "5", "6" };
        
        List<int> valueListD20 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
            11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        List<string> nameListD20 = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11",
            "12", "13", "14", "15", "16", "17", "18", "19", "20" };

        ShowGraph(valueListD20, -1, valueList.Count , nameListD20);
        
    }


    private void ShowGraph(List<int> valueList, int maxVisibleValueAmount = -1, int separatorCount = 10, List<string> nameList = null) {
        if (maxVisibleValueAmount <= 0) {
            maxVisibleValueAmount = valueList.Count;
        }
        foreach (GameObject gameObject in gameObjectList) {
            Destroy(gameObject);
        }
        gameObjectList.Clear();
        
        float graphHeight = graphContainer.sizeDelta.y;
        float graphWidth = graphContainer.sizeDelta.x;
        float yMaximum = valueList[0];
        float yMinimum = valueList[0];
        


        for (int i = Mathf.Max(valueList.Count - maxVisibleValueAmount,0); i < valueList.Count; i++) {
            int value = valueList[i];
            if (value > yMaximum) {
                yMaximum = value;
            }
            if (value < yMinimum) {
                yMinimum = value;
            }
        }
        float yDifference = yMaximum - yMinimum;
        if (yDifference <= 0) {
            yDifference = 5f;
        }
        yMaximum = yMaximum + (yDifference * 0.2f);
        yMinimum = yMinimum - (yDifference * 0.2f);

        yMinimum = 0f;

        float xSize = graphWidth / (maxVisibleValueAmount + 1);


        int xIndex = 0;
        for (int i =  Mathf.Max(valueList.Count - maxVisibleValueAmount,0); i < valueList.Count; i++) {
            float xPosition = xSize + xIndex * xSize;
            float yPosition = (valueList[i] / yMaximum) * graphHeight;

            GameObject barGameObject = CreateBar(new Vector2(xPosition, yPosition), xSize * .9f);
            gameObjectList.Add(barGameObject);
           
            RectTransform labelX = Instantiate(labelTemplateX);
            labelX.SetParent(graphContainer, false);
            labelX.gameObject.SetActive(true);
            labelX.anchoredPosition = new Vector2(xPosition, -7f);
            labelX.GetComponent<Text>().text = nameList[i];
            gameObjectList.Add(labelX.gameObject);

            xIndex++;
        }

        for (int i = 0; i <= separatorCount; i++) {
            RectTransform labelY = Instantiate(labelTemplateY);
            labelY.SetParent(graphContainer, false);
            labelY.gameObject.SetActive(true);
            float normalizedValue = i * 1f / separatorCount;
            labelY.anchoredPosition = new Vector2(-14f, normalizedValue * graphHeight);
            labelY.GetComponent<Text>().text = Mathf.RoundToInt(normalizedValue * yMaximum).ToString();
            gameObjectList.Add(labelY.gameObject);
        }
    }

   

    private GameObject CreateBar(Vector2 graphPosition, float barWidth) {
        GameObject gameObject = new GameObject("bar", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(graphPosition.x, 0f);
        rectTransform.sizeDelta = new Vector2(barWidth, graphPosition.y);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.pivot = new Vector2(.5f, 0f);
        return gameObject;
    }
}
