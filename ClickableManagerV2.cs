using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableManagerV2 : MonoBehaviour
{
    private Vector3 bigScale, smallScale;
    private bool bigorna;
    // Declare a field to store the currently selected object
    public ClickableObject selectedObject = null;


    private void Start()
    {
        bigScale = new Vector3(1f, 1f, 1f);
        smallScale = new Vector3(0.25f, 0.25f, 0.25f);
        bigorna = true;
    }

    private void OnMouseDown()
    {
        transform.localScale = bigorna? smallScale : bigScale;
        bigorna = !bigorna;
    }
    // Method to deselect the currently selected object
   /* public void Deselect()
    {
        if (selectedObject != null)
        {
            selectedObject.MakeSmall();
            selectedObject = null;
        }
    }*/

    // Method to select a new object
  /*  public void Select(ClickableObject newSelection)
    {
        Deselect(); // Deselect the previously selected object
        selectedObject = newSelection;
        if (selectedObject != null)
        {
            selectedObject.MakeBig();
        }
    }*/
}
