using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAnim
{
    public AnimationClip idle;
    public AnimationClip runF;
    public AnimationClip runB;
    public AnimationClip runL;
    public AnimationClip runR;

}


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10;
    public float rotateSpeed = 80;

    private float h = 0.0f;
    private float v = 0.0f;
    private float r = 0.0f;

    private Transform playerTransform;
    private Vector3 moveDirection;  // ���� �븻������ �ؾߵȴ�.(�밢�̵�)

    public PlayerAnim playerAnim;   // �ִϸ��̼� Ŭ�� ��Ƴ��� ��
    public Animation anim;          // �÷��̾� �ִϸ��̼� ��ü

    private void Start()
    {
        playerTransform = GetComponent<Transform>();

        // �ִϸ��̼� ����
        anim = GetComponent<Animation>();
        anim.clip = playerAnim.idle;
        anim.Play();
    }

    private void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");

        moveDirection = Vector3.forward * v + Vector3.right * h;
        playerTransform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime, Space.Self);
        playerTransform.Rotate(Vector3.up * r * rotateSpeed * Time.deltaTime, Space.Self);

        // �ε巴�� �ִϸ��̼� ��ȯ
        if (v >= 0.1f)
            anim.CrossFade(playerAnim.runF.name, 0.3f);
        else if (v <= -0.1f)
            anim.CrossFade(playerAnim.runB.name, 0.3f);
        else if (h >= 0.1f)
            anim.CrossFade(playerAnim.runR.name, 0.3f);
        else if (h <= -0.1f)
            anim.CrossFade(playerAnim.runL.name, 0.3f);
        else
            anim.CrossFade(playerAnim.idle.name, 0.3f); // �̷��� �����ϴ� �ڵ尡 �� ���ΰ�����. currentAnim���� ���� ������
    }
}
