using System.Collections;
using System.Collections.Generic;
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
        throw new System.NotImplementedException();
    }
}
