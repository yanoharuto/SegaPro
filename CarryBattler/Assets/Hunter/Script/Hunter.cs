using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter: CarryObject
{
    [SerializeField] [Header("射程")] private float AttackRange;
    [SerializeField] [Header("攻撃モーション")] private AnimationClip AttackAnimClip;
    [SerializeField] [Header("特殊攻撃モーション")] private AnimationClip SPAttackAnimClip;
    [SerializeField] [Header("待機モーション")] private AnimationClip IdleAnimClip;
    [SerializeField] [Header("被弾時モーション")] private AnimationClip DamegedAnimClip;
    [SerializeField] [Header("揺れ耐えモーション")] private AnimationClip ResistAnimClip;
    private List<Animator> Animations = new List<Animator>();

    private void PlayAnimation(string _AnimName)
    {
        foreach (Animator anim in Animations)
        {
            anim.Play(_AnimName);
        }
    }
    
    
    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++) 
        {
            Animations.Add(this.transform.GetChild(i).GetComponent<Animator>());
        }
    }
    private void Update()
    {
    }
    protected void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.GetComponent<ObjectBase>().ShowTagName() == ObjectEnum.ObjectKind.Ground)
        {
            OnTheGround(gameObject);
        }
        if (gameObject.GetComponent<ObjectBase>().ShowTagName() == ObjectEnum.ObjectKind.Enemy)
        {

           
            PlayAnimation(DamegedAnimClip.name);
        }
    }
}
