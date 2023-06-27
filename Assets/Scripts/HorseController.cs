using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class HorseController : EntityController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Name = "Horse";
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
        MessageText = $"My name is {Name}! Weee!";
        ShowPanel(true);
    }
}
