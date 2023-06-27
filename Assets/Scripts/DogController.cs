using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// INHERITANCE
public class DogController : EntityController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Name = "Dog";
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (Selected)
        {
            base.Update();
        }
       
    }
    
    // POLYMORPHISM
    protected override void SaySomething()
    {
        MessageText = $"Hi!, my name is {Name}! Wof wof!";
        ShowPanel(true);
    }
}
