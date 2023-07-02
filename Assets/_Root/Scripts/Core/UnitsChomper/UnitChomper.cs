using Abstractions;
using Core.CommandExecutors;
using UnityEngine;

namespace Core.UnitsChomper
{
    public class UnitChomper : MonoBehaviour, ISelecatable, IAttackable, IUnit, IAutomaticAttacker
    {
        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Transform _pivotPoint;
        [SerializeField] private Animator _animator;
        [SerializeField] private StopCommandExecutor _stopCommand;
        [SerializeField] private int _damage = 25;
        [SerializeField] private float _visiomRadius = 8f;

        private float _health = 1000;
        private Outline _outline;

        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;
        public Outline Outline => _outline;
        public Transform PivotPoint => _pivotPoint;
        public int Damage => _damage;
        public float VisionRadius => _visiomRadius;


        private void Start()
        {
            _outline = gameObject.AddComponent<Outline>();

            _outline.OutlineMode = Outline.Mode.OutlineAll;
            _outline.OutlineColor = Color.green;
            _outline.OutlineWidth = 5f;

            _outline.enabled = false;
        }


        public void RecieveDamage(int amount)
        {
            if (_health <= 0)
                return;

            _health -= amount;

            if (_health <= 0)
            {
                _animator.SetTrigger("PlayDead");
                Invoke(nameof(UnitDeath), 1f);
            }
        }

        private async void UnitDeath()
        {
            await _stopCommand.ExecuteSpecificCommand(new StopCommand());
            Destroy(gameObject);
        }
    }
}