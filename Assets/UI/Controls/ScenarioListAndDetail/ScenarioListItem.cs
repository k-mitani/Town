using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioListItem : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI itemName;
    [SerializeField] public Image militaryMapIcon;
    [SerializeField] public Image image;

    private ScenarioListAndDetail parent;
    public ScenarioMasterData Scenario { get; set; }

    public void Initialize(ScenarioListAndDetail parent, ScenarioMasterData scenario)
    {
        this.parent = parent;
        Scenario = scenario;
        itemName.text = scenario.Name;
        militaryMapIcon.enabled = scenario.IsMilitaryMap;
        // image.sprite = ...
    }

    public void OnClick()
    {
        parent.OnClickListItem(this);
    }
}
