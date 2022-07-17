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
    private Vector3 moveDirection;  // 벡터 노말라이즈 해야된다.(대각이동)

    public PlayerAnim playerAnim;   // 애니매이션 클립 모아놓은 것
    public Animation anim;          // 플레이어 애니매이션 자체

    private void Start()
    {
        playerTransform = GetComponent<Transform>();

        // 애니매이션 지정
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

        // 부드럽게 애니매이션 전환
        if (v >= 0.1f)
            anim.CrossFade(playerAnim.runF.name, 0.3f);
        else if (v <= -0.1f)
            anim.CrossFade(playerAnim.runB.name, 0.3f);
        else if (h >= 0.1f)
            anim.CrossFade(playerAnim.runR.name, 0.3f);
        else if (h <= -0.1f)
            anim.CrossFade(playerAnim.runL.name, 0.3f);
        else
            anim.CrossFade(playerAnim.idle.name, 0.3f); // 이렇게 제어하는 코드가 더 별로같은데. currentAnim상태 만들어서 제어요망
    }
}
