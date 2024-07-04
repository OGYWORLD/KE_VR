using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UITutorialLobby : MonoBehaviour
{
    public Dropdown dropdown;
    public Button button;
    private int selectedSceneIndex;

    public List<string> sceneNames = new List<string>();

    private void Awake()
    {
        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();

        foreach(string scenename in sceneNames)
        {
            options.Add(new Dropdown.OptionData(scenename));
        }

        dropdown.options = options;
        dropdown.onValueChanged.AddListener(SceneSelectionChange);
        //button.onClick.AddListener(MoveButtonClick);

    }

    public void SceneSelectionChange(int index)
    {
        selectedSceneIndex = index;
    }

    public void MoveButtonClick()
    {
        SceneManager.LoadScene(selectedSceneIndex);
    }
}
