using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScenarioListAndDetail : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private string title;
    [SerializeField] private ScenarioMasterData[] scenarios;
    [Header("List")]
    [SerializeField] private TextMeshProUGUI listName;
    [SerializeField] private Transform list;
    [SerializeField] private ScenarioListItem listItemPrefab;
    [Header("Detail")]
    [SerializeField] private TextMeshProUGUI detailName;
    [SerializeField] private Image detailImage;
    [SerializeField] private TextMeshProUGUI detailDescription;
    [SerializeField] private TextMeshProUGUI detailMapSize;
    [SerializeField] private TextMeshProUGUI detailDifficulty;
    [SerializeField] private RectTransform detailIsMilitaryMap;

    [SerializeField] private UnityEvent<ScenarioMasterData> onClickStartGame;

    private ScenarioMasterData currentSelectedScenario;

    private void Start()
    {
        listName.text = title;
        var isFirst = true;
        foreach (var scenario in scenarios)
        {
            var item = Instantiate(listItemPrefab, list);
            item.Initialize(this, scenario);
            if (isFirst) OnClickListItem(item);
            isFirst = false;
        }

    }

    public void OnClickListItem(ScenarioListItem item)
    {
        var scenario = item.Scenario;
        detailName.text = scenario.Name;
        //detailImage.sprite = ...;
        detailDescription.text = scenario.Description;
        detailMapSize.text = scenario.MapSize;
        detailDifficulty.text = scenario.Difficulty;
        detailIsMilitaryMap.gameObject.SetActive(scenario.IsMilitaryMap);

        currentSelectedScenario = scenario;
    }

    public void OnClickStartGame()
    {
        onClickStartGame?.Invoke(currentSelectedScenario);
    }
}
