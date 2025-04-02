using System.Xml;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform PlayerPos;
    public TextMeshProUGUI ValueText;

    private float startZ;
    private float score;

   
  

    void Start()
    {
        startZ = PlayerPos.position.z;
    }

    public void IncrementScore()
    {
        score++;
        if (score > 0)
        {
            ValueText.text = score.ToString("0");
        }
    }

   
}
