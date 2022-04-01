using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Poster : MonoBehaviour
{
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public Image LoadImage(string url)
    {
        //TODO: error handling for poster download
        Davinci.get().load(url).into(image).start();
        return image;
    }
}
