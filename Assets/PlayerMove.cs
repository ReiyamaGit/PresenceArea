using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// プレイヤーの移動関係のスクリプト
/// </summary>
public class PlayerMove : MonoBehaviour {

    //public member
    [SerializeField]
    private float m_moveSpeed = 3.0f;           //移動スピード

    [SerializeField]
    private float m_camSpeed = 30.0f;           //回転スピード


    //private member
    private Animator m_animator;

	// Use this for initialization
	void Start () {

        m_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        //横入力
        if(Input.GetAxis("Horizontal") != 0)
        {
            //回転した先は何度になるかを求める → 求めた角度まで自分の定めたスピードで回転する
            Quaternion dir = Quaternion.LookRotation(transform.right * Input.GetAxis("Horizontal"));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, dir, m_camSpeed * Time.deltaTime); 
        }

        //たて入力
        if(Input.GetAxis("Vertical") != 0)
        {
            //移動
            transform.Translate(transform.forward * Input.GetAxis("Vertical") * m_moveSpeed,Space.World);
            
        }

        m_animator.SetFloat("speed", Input.GetAxis("Vertical"));
        Debug.Log(Input.GetAxis("Vertical"));



    }
}
