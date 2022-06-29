using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project.Scripts.Exorcism
{
    public class GhostGeneration
    {
        Queue<string> linesAge;
        Queue<string> linesName;
        Queue<string> linesConclusion;
        Queue<string> namesMale;
        Queue<string> namesFemale;
        Queue<string> namesSurnames;
        Queue<string> namesSpecialMale;
        Queue<string> namesSpecialFemale;

        public List<PassiveGhost> GenerateGhosts(int many = 3)
        {
            List<PassiveGhost> randomizedGhosts = new List<PassiveGhost>();

            SetupPossibleLists();

            for (int i = 0; i < many; i++)
            {
                PassiveGhost newGhost = new PassiveGhost();

                int rGenderId = Random.Range(0, 2);
                newGhost.ghostGender = rGenderId == 0 ? "Male" : "Female";

                newGhost.ghostName = RandomizeName(newGhost.ghostGender);

                newGhost.ghostAgeAtDeath = RandomizeAge();
                newGhost.ghostDeathAge = RandomizeDeathAge();

                string introLine1 = linesName.Dequeue();
                introLine1 = introLine1.Replace("<name>", newGhost.ghostName);
                
                string introLine2 = linesAge.Dequeue();
                introLine2 = introLine2.Replace("<age>", newGhost.ghostAgeAtDeath.ToString());
                
                string introLine3 = linesConclusion.Dequeue();

                newGhost.ghostIntroduction = $"{introLine1};\n{introLine2};\n{introLine3}.";

                randomizedGhosts.Add(newGhost);
            }

            return randomizedGhosts;
        }

        private void SetupPossibleLists()
        {
            List<string> tempList;
            
            tempList = new List<string>(RandomizableIntroLines.possibleLinesAge.ToList());
            tempList.ShuffleList();
            linesAge = new Queue<string>(tempList);
            
            tempList = new List<string>(RandomizableIntroLines.possibleLinesName.ToList());
            tempList.ShuffleList();
            linesName = new Queue<string>(tempList);
            
            tempList = new List<string>(RandomizableIntroLines.possibleLinesConclusion.ToList());
            tempList.ShuffleList();
            linesConclusion = new Queue<string>(tempList);

            tempList = new List<string>(RandomizableNames.possibleMaleNames.ToList());
            tempList.ShuffleList();
            namesMale = new Queue<string>(tempList);
            
            tempList = new List<string>(RandomizableNames.possibleFemaleNames.ToList());
            tempList.ShuffleList();
            namesFemale = new Queue<string>(tempList);
            
            tempList = new List<string>(RandomizableNames.possibleSurnames.ToList());
            tempList.ShuffleList();
            namesSurnames = new Queue<string>(tempList);
            
            tempList = new List<string>(RandomizableNames.possibleMaleSpecialNames.ToList());
            tempList.ShuffleList();
            namesSpecialMale = new Queue<string>(tempList);
            
            tempList = new List<string>(RandomizableNames.possibleFemaleSpecialNames.ToList());
            tempList.ShuffleList();
            namesSpecialFemale = new Queue<string>(tempList);
        }

        private string RandomizeName(string gender)
        {
            int rNameRange = Random.Range(0, 100);
            if (gender == "Male")
            {
                if (namesSpecialMale.Count > 0 && rNameRange == 0)
                {
                    return namesSpecialMale.Dequeue();
                }
                else
                {
                    return namesMale.Dequeue() + " " + namesSurnames.Dequeue();
                }
            }
            else
            {
                if (namesSpecialFemale.Count > 0 && rNameRange == 0)
                {
                    return namesSpecialFemale.Dequeue();
                }
                else
                {
                    return namesFemale.Dequeue() + " " + namesSurnames.Dequeue();
                }
            }
        }

        private int RandomizeAge()
        {
            int age = 0;
            int rAgeRange = Random.Range(0, 101);
            if (rAgeRange >= 94)
            {
                age = Random.Range(100, 111);
            }
            else if (rAgeRange >= 84)
            {
                age = Random.Range(10, 19);
            }
            else if (rAgeRange >= 40)
            {
                age = Random.Range(60, 100);
            }
            else
            {
                age = Random.Range(19, 70);
            }

            return age;
        }
        
        private int RandomizeDeathAge()
        {
            int age = 0;
            int rAgeRange = Random.Range(0, 101);
            if (rAgeRange >= 94)
            {
                age = Random.Range(100, 500);
            }
            else if (rAgeRange >= 84)
            {
                age = Random.Range(50, 100);
            }
            else if (rAgeRange >= 40)
            {
                age = Random.Range(10, 50);
            }
            else
            {
                age = Random.Range(1, 10);
            }

            return age;
        }
        
        
    }
}