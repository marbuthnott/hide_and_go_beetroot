using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HighscoreTable : MonoBehaviour
{

    private Transform entryContainer;
    private Transform entryTemplate;

    private void Awake() {
        Debug.Log("hello");
        entryContainer = transform.Find("HighscoreEntryContainer");
        entryTemplate = entryContainer.Find("HighscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);


        float templateHeight = 0.5f;
        for (int i = 0; i < 10; i++) {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0.32f, (-templateHeight * i) - 1);
            entryTransform.gameObject.SetActive(true);
            Debug.Log("iterating");
        }     
    }
}