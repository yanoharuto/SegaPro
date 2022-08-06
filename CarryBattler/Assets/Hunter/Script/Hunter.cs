using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter: CarryObject
{
    
    [SerializeField] [Header("�G��transform")] private Transform EnemyT;
    [SerializeField] [Header("�˒�")][Range(0.0f,1000.0f)] private float AttackRange;
    [SerializeField] [Header("�˒�")] [Range(0.0f, 1000.0f)] private float SPAttackRange;
    [SerializeField] [Header("�U�����[�V����")] private AnimationClip AttackAnimClip;
    [SerializeField] [Header("����U�����[�V����")] private AnimationClip SPAttackAnimClip;
    [SerializeField] [Header("�ҋ@���[�V����")] private AnimationClip IdleAnimClip;
    [SerializeField] [Header("��e�����[�V����")] private AnimationClip DamegedAnimClip;
    [SerializeField] [Header("�h��ς����[�V����")] private AnimationClip ResistAnimClip;
    private List<Animator> Animations = new List<Animator>();//�̂Ƃ�����̃A�j���[�V�����R���g���[���[
    private void PlayAnimation(string _AnimName)
    {
        foreach (Animator anim in Animations)
        {
            anim.Play(_AnimName);
        }
    }
    private bool IsPlayIdleAnim()
    {
        //�A�j���[�V�����R���g���[���[�̐擪�̃��C���[��idle��Ԃ��m�F����
        AnimatorStateInfo AnimClip= Animations[0].GetCurrentAnimatorStateInfo(0);
        if (AnimClip.IsName(IdleAnimClip.name))
        {
            return true;
        }
        return false;
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
        Vector3 EneT = EnemyT.position;
        EneT.y = transform.position.y;
        transform.LookAt(EneT);
        //�x���g�R���x�A�̐k���ɑς���
        if (CIF.ShowBCState()==BeltConveyorEnum.BeltConveyorState.Left||
            CIF.ShowBCState()==BeltConveyorEnum.BeltConveyorState.Right)
        {
            PlayAnimation(ResistAnimClip.name);
        }
        //�U�����[�V����
        else if(CIF.ShowBCState()==BeltConveyorEnum.BeltConveyorState.Stop)
        {
            Vector3 EneBetween = EnemyT.position - transform.position;
            if (Mathf.Abs(EneBetween.x) < SPAttackRange && Mathf.Abs(EneBetween.y) < SPAttackRange)
            {
                if (IsPlayIdleAnim())
                {
                    transform.LookAt(EnemyT.position);
                    PlayAnimation(SPAttackAnimClip.name);
                }

            }
            else if (Mathf.Abs(EneBetween.x) < AttackRange && Mathf.Abs(EneBetween.y) < AttackRange)
            {
                if (IsPlayIdleAnim())
                {
                    transform.LookAt(EnemyT.position);
                    PlayAnimation(AttackAnimClip.name);
                }
            }
        }
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
