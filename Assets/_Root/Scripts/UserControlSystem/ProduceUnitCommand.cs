using Abstractions.Commands.CommandInterfaces;
using UnityEngine;
using Utils.AssetsInjector;
using Zenject;

namespace UserControlSystem
{
    public class ProduceUnitCommand : IProduceUnitCommand
    {
        [InjectAsset("ChomperBase")] private GameObject _unitPrefab;
        public GameObject UnitPrefab => _unitPrefab;

        [Inject(Id = "ChomperBase")] public string UnitName { get; }
        [Inject(Id = "ChomperBase")] public Sprite Icon { get; }
        [Inject(Id = "ChomperBase")] public float ProductionTime { get; }
    }
}