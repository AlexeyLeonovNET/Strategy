using Abstractions;
using Abstractions.Commands.CommandInterfaces;
using System.Threading.Tasks;
using UnityEngine;

namespace Core.MainBildings
{
    public class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelecatable, IAttackable
    {
        [SerializeField] private Transform _unitsParent;
        [SerializeField] private Transform _pivotPoint;
        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;

        private float _health = 1000;
        private Outline _outline;

        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;
        public Outline Outline => _outline;
        public Transform PivotPoint => _pivotPoint;
        public Vector3 RallyPoint {  get; set; }


        private void Start()
        {
            _outline = gameObject.AddComponent<Outline>();

            _outline.OutlineMode = Outline.Mode.OutlineAll;
            _outline.OutlineColor = Color.yellow;
            _outline.OutlineWidth = 5f;

            _outline.enabled = false;
        }


        public override async Task ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            Instantiate(command.UnitPrefab,
                new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)),
                Quaternion.identity,
                _unitsParent);
        }


        public void RecieveDamage(int amount)
        {
            if (_health <= 0)
                return;

            _health -= amount;

            if (_health <= 0)
                Destroy(gameObject);
        }
    }
}