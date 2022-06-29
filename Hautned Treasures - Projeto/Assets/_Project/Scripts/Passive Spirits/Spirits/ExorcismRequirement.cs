using System;

namespace _Project.Scripts.Exorcism
{
    [Serializable]
    public struct ExorcismRequirement
    {
        public ExorcismItem requiredBelonging;
        public ExorcismItem requiredElemental;

        public bool belongingReceived;
        public bool elementalReceived;
    }
}