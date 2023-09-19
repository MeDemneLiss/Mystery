using Assets.Code;
using UnityEngine;


public class Spauner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject simvol;
    public GameObject podskazka;
    public Transform spavnerPoint;

    public float startTime;
    private float timeBtw;
    private int kollspavn;
    private void Start()
    {
        timeBtw = startTime;
    }
    void Update()
    {
        if (Quest.idQuest[2] == true)
        {
            simvol.SetActive(false);
            if (timeBtw <= 0 || kollspavn > 5)
            {
                if (kollspavn == 10)
                {
                    kollspavn = 0;
                }
                kollspavn++;
                Instantiate(enemy, spavnerPoint.transform.position, Quaternion.identity);
                timeBtw = startTime;
            }
            else { timeBtw -= Time.deltaTime; }


        }
        if (Quest.Expiriens > 250)
        {
            Quest.idQuest[10] = true;
            podskazka.SetActive(true);
        }
    }
}
