using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadTitleScene : MonoBehaviour
{
    public void LoadTitle()
    {
        SceneManager.LoadScene("Start Screen 1");
    }
}
