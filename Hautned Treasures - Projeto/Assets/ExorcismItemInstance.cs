using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.Exorcism;
using UnityEngine;

public class ExorcismItemInstance : MonoBehaviour
{
   public ItemInstanceType itemType;
   public ExorcismItem item;
}

public enum ItemInstanceType {Undefined, Belonging, Elemental}
