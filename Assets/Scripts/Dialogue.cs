using Assets.SimpleLocalization.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Text textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            { 
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        //Localize();
        //LocalizationManager.OnLocalizationChanged += Localize;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            //Localize();
            //LocalizationManager.OnLocalizationChanged += Localize;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        { 
        gameObject.SetActive(false);
        }
    }

    //public void OnDestroy()
    //{
    //    LocalizationManager.OnLocalizationChanged -= Localize;
    //}

    //private void Localize()
    //{
    //    if (lines != null)
    //    {
    //        textComponent.text = LocalizationManager.Localize(lines[index]);
    //    }
    //}
}
