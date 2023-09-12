using UnityEngine;

namespace SplatTheRat.ScriptableObjects.Settings
{
    [CreateAssetMenu(fileName = "ObjectsScale", menuName = "SO/Settings/Object Scale")]
    public class ObjectsScale : ScriptableObject
    {
        [field: SerializeField] public float Value { get; set; }
    }
}