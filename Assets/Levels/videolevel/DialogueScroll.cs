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
    [SerializeField] private Button button; 
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Image image = gameObject.GetComponent<Image>();
        image.sprite = imageFolder[index];

        if (Input.GetMouseButtonDown(0)) 
        {
            if (index < imageFolder.Length - 1)
            {
                image.gameObject.SetActive(false);
                index++;
                image.gameObject.SetActive(true);
            }
            else if (index >= imageFolder.Length - 1 && button != null)
            { 
                button.onClick.Invoke();
            }
            else
            {
                return;
            }
        }
    }
}
