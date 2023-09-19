using Assets.Code;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    public DialogueNode[] node;
    public int _currentNode;
    public bool ShowDialogue = false;
    public GUIStyle style = new GUIStyle();
    public bool isAtack;
    public Texture box;
    public GUIStyle box2 = new GUIStyle();

    void Start()
       {
        Quest.idQuest[0] = true;
        for (int i = 1;i<25;i++)
        {
            Quest.idQuest[i] = false;
        }
      }
    public void DisplayDialog()
    {
        ShowDialogue = true;
        Time.timeScale = 0f;
    }
    void OnGUI()
    {
        style.fontSize = 30;
        if (ShowDialogue == true)
        {
            GUI.Box(new Rect(Screen.width / 2 - 700, Screen.height - 300, 1900, 250),"", box2);
            GUI.Label(new Rect(Screen.width / 2 - 650, Screen.height - 280, 1500, 90), node[_currentNode].NpcText, style);
            for (int i = 0; i < node[_currentNode].PlayerAnswer.Length; i++)
            {
                if (Quest.idQuest[node[_currentNode].PlayerAnswer[i].NeedQuestId] == true)
                {
                    if (GUI.Button(new Rect(Screen.width / 2 - 650, Screen.height - 200 + 25 * i, 1500, 25), node[_currentNode].PlayerAnswer[i].Text, style))
                    {

                        if (node[_currentNode].PlayerAnswer[i].SpeakEnd)
                        {
                            ShowDialogue = false;
                            Time.timeScale = 1f;
                        }
                        _currentNode = node[_currentNode].PlayerAnswer[i].ToNode;
                        if (node[_currentNode].PlayerAnswer[i].DelAnswer)
                        {
                            node[_currentNode].PlayerAnswer[i].Text = "";
                            node[_currentNode].PlayerAnswer[i].ToNode = _currentNode;
                        }
                        if (node[_currentNode].PlayerAnswer[i].NewNpcText != "")
                        {
                            node[_currentNode].NpcText = node[_currentNode].PlayerAnswer[i].NewNpcText;
                        }
                        if (node[_currentNode].PlayerAnswer[i].ActivateQuestId != 0)
                        {
                            Quest.idQuest[node[_currentNode].PlayerAnswer[i].ActivateQuestId] = true;
                        }
                    }
                }
            }
        }
    }
    [System.Serializable]
    public class DialogueNode
    {
        public string NpcText;
        public Answer[] PlayerAnswer;
    }


    [System.Serializable]
    public class Answer
    {
        public string Text;
        public int ToNode;
        public bool DelAnswer;
        public string NewNpcText;
        public bool SpeakEnd;
        public int NeedQuestId;
        public int ActivateQuestId;
    }
}

