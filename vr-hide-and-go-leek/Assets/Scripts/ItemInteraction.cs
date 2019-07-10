using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItems : MonoBehaviour
{
   public string Name;

   public Sprite Image;

   public string InteractText = "Tap once to interact with the item";

   public virtual void OnInteract () {

   }
}


