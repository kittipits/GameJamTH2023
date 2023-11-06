using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueScroll : MonoBehaviour
{
    [SerializeField] private Sprite[] imageFolder;
    [SerializeField] private Button skipButton;
    [SerializeField] private Button nextButton;
    public Image image { get; private set; }
    public int index = 0;

private void Start()
    {

    }

    void Update()
    {
        image = gameObject.GetComponent<Image>();
        image.sprite = imageFolder[index];

        if (index >= imageFolder.Length - 1 && skipButton != null)
        {
            skipButton.onClick.Invoke();
        }
        else
        {
            return;
        }
    }
}
