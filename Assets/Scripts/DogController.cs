using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DogController : EntityController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (Selected)
        {
            base.Update();
        }
       
    }
    
    protected override void SaySomething()
    {
        MessageText = $"Hi!, my name is {Name}! Wof wof!";
        ShowPanel(true);
    }
}
