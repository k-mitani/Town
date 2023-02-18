using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MasterData/Scenario")]
public class ScenarioMasterData : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public string ImagePath { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public string MapSize { get; private set; }
    [field: SerializeField] public string Difficulty { get; private set; }
    [field: SerializeField] public bool IsMilitaryMap { get; private set; }
}
