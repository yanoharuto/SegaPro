using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter: CarryObject
{
    [SerializeField] [Header("�˒�")] private float AttackRange;
    [SerializeField] [Header("�U�����[�V����")] private AnimationClip AttackAnimClip;
    [SerializeField] [Header("����U�����[�V����")] private AnimationClip SPAttackAnimClip;
    [SerializeField] [Header("�ҋ@���[�V����")] private AnimationClip IdleAnimClip;
    [SerializeField] [Header("��e�����[�V����")] private AnimationClip DamegedAnimClip;
    [SerializeField] [Header("�h��ς����[�V����")] private AnimationClip ResistAnimClip;
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
