using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombCount : MonoBehaviour
{
    public Text bombCountText;
    void Update()
    {
        bombCountText.text = "Bombs: " + bombCountText.ToString();
    }
}
