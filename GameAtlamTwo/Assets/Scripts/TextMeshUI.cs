using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextMeshUI : MonoBehaviour
{
    public static TextMeshUI txtmsh;
    [SerializeField] TextMeshProUGUI ZombieEnemyText;
    public int ZombieEnemyCount;
    void Start()
    {
        txtmsh = this;
    }

    private void Update()
    {
        ZombieEnemyCount = GameObject.FindGameObjectsWithTag("Zombie").Length;
        ZombieEnemyText.text = " " + ZombieEnemyCount.ToString();
    }

}
