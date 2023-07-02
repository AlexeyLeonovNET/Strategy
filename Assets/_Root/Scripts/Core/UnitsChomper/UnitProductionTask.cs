using Abstractions;
using UnityEngine;

namespace Core.UnitsChomper
{
    public class UnitProductionTask : IUnitProductionTask
    {
        public string UnitName { get; }
        public float TimeLeft { get; set; }
        public float ProductionTime { get; }
        public Sprite Icon { get; }
        public GameObject UnitPrefab { get; }


        public UnitProductionTask(float time, Sprite icon, GameObject unitPrefab, string unitName)
        {
            UnitName = unitName;
            TimeLeft = time;
            ProductionTime = time;
            Icon = icon;
            UnitPrefab = unitPrefab;
        }
    }
}