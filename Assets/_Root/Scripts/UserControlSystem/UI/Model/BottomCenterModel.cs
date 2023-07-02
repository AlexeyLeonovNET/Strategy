using Abstractions;
using System;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using Zenject;
using UniRx;
using UnityEngine;

namespace UserControlSystem.UI.Model
{
    public class BottomCenterModel
    {
        public IObservable<IUnitProducer> UnitProducers { get; private set; }


        [Inject]
        public void Init(IObservable<ISelectable> currentlySelected)
        {
            UnitProducers = currentlySelected
                .Select(selectable => selectable as Component)
                .Select(component => component?.GetComponent<IUnitProducer>());
        }
    }
}