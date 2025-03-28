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

    

    // Update is called once per frame
    void Update()
    {
        score = startZ - PlayerPos.position.z;

        if (score > 0)
        {
           
            ValueText.text = score.ToString("0");
        }
    }
}
