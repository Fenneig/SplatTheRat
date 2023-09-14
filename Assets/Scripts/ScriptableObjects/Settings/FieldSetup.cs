using UnityEngine;

namespace SplatTheRat.ScriptableObjects.Settings
{
    [CreateAssetMenu(fileName = "FieldSetup", menuName = "SO/Settings/Field Setup")]
    public class FieldSetup : ScriptableObject
    {
        [SerializeField, Range(2, 7)] private int _gridLength;
        
        public int GridLength
        {
            get => _gridLength;
            set
            {
                if (value < 2) _gridLength = 2;
                if (value > 7) _gridLength = 7;
                
                _gridLength = value;
            }
        }
    }
}