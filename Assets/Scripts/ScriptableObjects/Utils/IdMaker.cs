using UnityEngine;

namespace SplatTheRat.ScriptableObjects.Utils
{
    [CreateAssetMenu(fileName = "Id maker", menuName = "SO/Utils/Id maker")]
    public class IdMaker : ScriptableObject
    {
        private int _id = 0;

        private void Awake()
        {
            _id = 0;
        }

        public int GetId => _id++;
    }
}