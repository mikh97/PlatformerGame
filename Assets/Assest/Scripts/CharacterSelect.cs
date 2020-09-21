using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public void ChooseCharacter(int characterIndex)
    {
        PlayerPrefs.SetInt("SelectedCharacter", characterIndex);
        print("The player index you selected is " + characterIndex);

    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Level1");
    }



}
