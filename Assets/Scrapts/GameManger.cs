using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public GameObject Column;
    bool game_started = false;
    public GameObject start_panel;
    void Start()
    {
        Time.timeScale = 0;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && game_started == false)
        {
            Time.timeScale = 1;
            StartCoroutine(CreateColumn());
            game_started = true;
            start_panel.SetActive(false);
        }
    }
    IEnumerator CreateColumn()
    {
        yield return new WaitForSeconds(2);

        GameObject new_column = Instantiate(Column);

        new_column.transform.position = new Vector3(48, Random.Range(-6f, -10f), 0);

        StartCoroutine(CreateColumn());
    }

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
