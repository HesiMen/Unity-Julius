using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapActivateLine : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject renderLine;
    [SerializeField] Animator startAnimation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        renderLine.SetActive(true);
        startAnimation.Play("IMGFadeIn");
    }
}
