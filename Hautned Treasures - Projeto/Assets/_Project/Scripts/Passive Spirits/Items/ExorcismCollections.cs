using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Exorcism
{
    [CreateAssetMenu(menuName = "Create ExorcismItemsCollection", fileName = "ExorcismItemsCollection", order = 0)]
    public class ExorcismCollections : ScriptableObject
    {
        public List<ExorcismItem> belongings;
        public List<ExorcismItem> elementals;

        public List<ExorcismItem> AllItems()
        {
            List<ExorcismItem> all = new List<ExorcismItem>();
            all.AddRange(belongings);
            all.AddRange(elementals);
            return all;
        }
    }
}