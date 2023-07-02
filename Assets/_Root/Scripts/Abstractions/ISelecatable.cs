using UnityEngine;

namespace Abstractions
{
    public interface ISelecatable : IHealthHolder, IIconHolder
    {
        Transform PivotPoint { get; }
        Outline Outline { get; }
    }
}