using Abstractions;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UserControlSystem.UI.Model;
using Zenject;

namespace UserControlSystem.UI.Presenter
{
    public class MouseInteractionsPresenter : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SelectableValue _selectedObject;
        [SerializeField] private EventSystem _eventSystem;

        [SerializeField] private Vector3Value _groundClickRMB;
        [SerializeField] private Transform _groundTransform;
        [SerializeField] private AttackableValue _attackableRMB;

        private Plane _groundPlane;


        [Inject]
        private void Init()
        {
            _groundPlane = new Plane(_groundTransform.up, 0);

            var nonBlockedFramesStream = Observable.EveryUpdate()
                .Where(_ => !_eventSystem.IsPointerOverGameObject());

            var leftClicksStream = nonBlockedFramesStream
                .Where(_ => Input.GetMouseButtonDown(0));
            var rightClicksStream = nonBlockedFramesStream
                .Where(_ => Input.GetMouseButtonDown(1));

            var lmbRays = leftClicksStream
                .Select(_ => _camera.ScreenPointToRay(Input.mousePosition));
            var rmbRays = rightClicksStream
                .Select(_ => _camera.ScreenPointToRay(Input.mousePosition));

            var lmbHitsStream = lmbRays
                .Select(ray => Physics.RaycastAll(ray));
            var rmbHitsStream = rmbRays
                .Select(ray => (ray, Physics.RaycastAll(ray)));

            lmbHitsStream.Subscribe(hits =>
            {
                if (IsHit<ISelecatable>(hits, out var selectable))
                    _selectedObject.SetValue(selectable);
            });

            rmbHitsStream.Subscribe(date =>
            {
                var (ray, hits) = date;

                if (IsHit<IAttackable>(hits, out var attackeble))
                    _attackableRMB.SetValue(attackeble);
                else if (_groundPlane.Raycast(ray, out var enter))
                    _groundClickRMB.SetValue(ray.origin + ray.direction * enter);
            });
        }

        private bool IsHit<T>(RaycastHit[] hits, out T result) where T : class
        {
            result = default;

            if (hits.Length == 0)
                return false;

            result = hits.Select(hit => hit.collider.GetComponentInParent<T>())
                .Where(c => c != null).FirstOrDefault();

            return result != default;
        }
    }
}