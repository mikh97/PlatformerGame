using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour{

    //    public int health;

    void Update()
    {
        if (gameObject.transform.position.y < -20)
        {
            Die();
        }

    }

    void Die () {
        SceneManager.LoadScene("Level1");
//        Debug.Log("Oh you fell fell");
//        yield return new WaitForSeconds(2);
//        Debug.Log("You dead bruh!!");

    }
}
