using Assets.Code;
using UnityEngine;
using UnityEngine.UI;

public class InterfecePlayer : MonoBehaviour
{
    public Text health;
    public Text expitiens;
    void Update()
    {
        health.text = $"Çהמנמגüו: {PlayerControler.setHealth}";
        expitiens.text = $"Îןûע: {Quest.Expiriens}";
    }
}
