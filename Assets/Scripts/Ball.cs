using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    GameController m_gc;
    private void Start()
    {
        m_gc = FindObjectOfType<GameController>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Va chạm với giá đỡ");
            m_gc.IncrementScore();
            //Hủy bóng nếu đỡ thành công
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("DeathZone"))
        {
            m_gc.SetGameoverState(true);
            //Debug.Log("Va chạm với deathzone thua!");
            Destroy(gameObject);
        }
    }
}
