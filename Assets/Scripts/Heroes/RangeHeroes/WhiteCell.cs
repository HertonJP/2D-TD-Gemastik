using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCell : RangeHeroes
{
    [SerializeField] private int bonusAtt;
    // Start is called before the first frame update
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
        _projectilesPrefab.GetComponent<DealCritDamage>().critDamage = bonusAtt;
        _projectilesPrefab.GetComponent<DealCritDamage>().isCrit = true;
    }
}
