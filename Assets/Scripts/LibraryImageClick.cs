using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class LibraryImageClick : MonoBehaviour, IPointerClickHandler
{
    public int imageIndex;

    public void OnPointerClick(PointerEventData eventData)
    {
        int previousSelection = MainManager.Instance.auxImageSelection;

        if (previousSelection != -1)
        {
            var previousImage = MainManager.Instance.GetLibraryImage(previousSelection);

            var temp = previousImage.color;
            temp.a = 1f;
            previousImage.color = temp;
        }

        var newImage = MainManager.Instance.GetLibraryImage(imageIndex);

        var temp2 = newImage.color;
        temp2.a = 0.5f;
        newImage.color = temp2;

        MainManager.Instance.auxImageSelection = imageIndex;
    }

}

