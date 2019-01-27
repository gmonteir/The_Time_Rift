using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorChange : MonoBehaviour
{
    // Start is called before the first frame update
    public static BackgroundColorChange instance;
    public Color color1;
    public Color color2;
    private SpriteRenderer background;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        background = GetComponent<SpriteRenderer>();
        background.color = color1;
    }

    public void World1Color()
    {
        background.color = color1;
    }

    public void World2Color()
    {
        background.color = color2;
    }
}
