using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturalKiller : RangeHeroes
{
    [SerializeField] private float stunDuration;
    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    protected override void Ulti()
    {
        base.Ulti();
        _projectilesPrefab.GetComponent<SingleStun>().stunDuration = stunDuration;
    }
}
