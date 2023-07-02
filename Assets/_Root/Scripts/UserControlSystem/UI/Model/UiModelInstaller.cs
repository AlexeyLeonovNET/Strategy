using Abstractions.Commands.CommandInterfaces;
using UnityEngine;
using UserControlSystem.UI.Model.CommandCreators;
using Utils.AssetsInjector;
using Zenject;

namespace UserControlSystem.UI.Model
{
    public class UiModelInstaller : MonoInstaller
    {
        [SerializeField] private AssetsContext _legacyContext;
        [SerializeField] private Vector3Value _vector3Value;
        [SerializeField] private AttackableValue _attackable;
        [SerializeField] private SelectableValue _selectabl;


        public override void InstallBindings()
        {
            Container.Bind<AssetsContext>().FromInstance(_legacyContext);
            Container.Bind<Vector3Value>().FromInstance(_vector3Value);
            Container.Bind<AttackableValue>().FromInstance(_attackable);
            Container.Bind<SelectableValue>().FromInstance(_selectabl);

            Container.Bind<CommandCreatorBase<IProduceUnitCommand>>()
                .To<ProduceUnitCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<ISetRallyPointCommand>>()
                .To<SetRallyPointCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IAttackCommand>>()
                .To<AttackCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IMoveCommand>>()
                .To<MoveCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IPatrolCommand>>()
                .To<PatrolCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IStopCommand>>()
                .To<StopCommandCreator>().AsTransient();

            Container.Bind<CommandButtonsModel>().AsTransient();

            Container.Bind<float>().WithId("ChomperBase").FromInstance(5f);
            Container.Bind<string>().WithId("ChomperBase").FromInstance("ChomperBase");
        }
    }
}