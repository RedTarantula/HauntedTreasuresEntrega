using System;
using Sirenix.OdinInspector;

namespace _Project.Scripts.Exorcism
{
    [Serializable]
    public class PassiveGhost
    {
        public string ghostName;
        public string ghostGender;
        public int ghostAgeAtDeath; // What age they were when they died
        public int ghostDeathAge; // How long they have been dead for
        
        public ExorcismRequirement ghostExorcism;
        [MultiLineProperty(8)] public string ghostIntroduction;
        [MultiLineProperty(8)] public string HintsBelonging;
        [MultiLineProperty(8)] public string HintsElemental;
        
    }
}