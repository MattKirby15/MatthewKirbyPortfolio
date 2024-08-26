using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiController : MonoBehaviour
{
    public static UiController instance;

    [SerializeField] GameObject NotEnoughGoldWarning;

    [SerializeField] public TMP_Text GoldText;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
