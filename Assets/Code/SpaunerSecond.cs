using Assets.Code;
using UnityEngine;

public class SpaunerSecond : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject simvol;
    public Transform spavnerPoint;

    public float startTime;
    private float timeBtw;
    private int kollspavn;
    static int f = 4;
    private void Start()
    {
        timeBtw = startTime;
    }
    void Update()
    {
        if (Quest.idQuest[15] == true)
        {
            simvol.SetActive(false);
            if (timeBtw <= 0)
            {
                if (kollspavn > 20) return;
                if (kollspavn < f)
                {
                    Instantiate(enemy, spavnerPoint.transform.position, Quaternion.identity);

                }
                if (kollspavn == f)
                {
                    Instantiate(enemy2, spavnerPoint.transform.position, Quaternion.identity);
                    f += 4;
                }
                kollspavn++;
                timeBtw = startTime;
            }

            else timeBtw -= Time.deltaTime; 


        }
    }
}
