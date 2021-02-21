using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void Beginer()
    {
        SceneManager.LoadScene("Beginner");
    }
    public void Intermediate()
    {
        SceneManager.LoadScene("Intermediate");
    }
    public void Expert()
    {
        SceneManager.LoadScene("Expert");
    }
}
