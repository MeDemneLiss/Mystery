using Assets.Code;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour
{
    public GameObject oldDoor;
    public GameObject newDoor;
    public GameObject finish;
    // Update is called once per frame
    void Update()
    {
        if (Quest.Expiriens > 1200)
        {
            oldDoor.SetActive(false);
            newDoor.SetActive(true);
            finish.SetActive(true);

        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
            {
            if (Quest.Expiriens > 1200)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            }

    }
}
