using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBar : MonoBehaviour
{
    private ScrollRect _ScrollRect;

    public AudioSource scrollAudio;

    [SerializeField] private ScrollButton _leftButton;
    [SerializeField] private ScrollButton _rightButton;

    [SerializeField] private float scrollSpeed=0.01f;

    void Start()
    {
        _ScrollRect = GetComponent<ScrollRect>();
    }

   
    void Update()
    {
        if(_leftButton!=null)
        {
            if (_leftButton.isDown)
            {
                scrollAudio.Play();
                ScrollLeft();
            }
        }

        if (_rightButton != null)
        {
            if (_rightButton.isDown)
            {
                scrollAudio.Play();
                ScrollRight();
            }
        }

    }

    private void ScrollLeft()
    {
        if (_ScrollRect != null)
        {
            if (_ScrollRect.horizontalNormalizedPosition >= 0f)
            {
                _ScrollRect.horizontalNormalizedPosition -= scrollSpeed;
            }
        }
    }


    private void ScrollRight()
    {
        if (_ScrollRect != null)
        {
            if (_ScrollRect.horizontalNormalizedPosition <= 1f)
            {
                _ScrollRect.horizontalNormalizedPosition += scrollSpeed;
            }
        }
    }


}
