using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour
{
    public DialogueScroll scroll;

    public void Click()
    {
        scroll.image.gameObject.SetActive(false);
        scroll.index++;
        scroll.image.gameObject.SetActive(true);
    }
}
