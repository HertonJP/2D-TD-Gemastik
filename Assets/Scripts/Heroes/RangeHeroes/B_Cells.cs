using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Cells : RangeHeroes
{
    [SerializeField] private float bonusAttSpeed;
    [SerializeField] private float bonusAttSpeedDuration;
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
        StartCoroutine(AttackSpeedBonus());
    }

    private IEnumerator AttackSpeedBonus()
    {
        _attackSpeed += bonusAttSpeed;
        yield return new WaitForSeconds(bonusAttSpeedDuration);
        _attackSpeed -= bonusAttSpeed;
    }
}
