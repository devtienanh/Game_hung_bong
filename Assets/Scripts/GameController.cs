using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ball; 
    public float spawnTime; // Thời gian giữa các lần sinh ra quả bóng

    private float m_spawnTime; // Thời gian còn lại cho lần sinh ra tiếp theo
    private int m_score; // Điểm 
    private bool m_isGameover;

    private UIManager m_ui; 

    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        m_ui = FindObjectOfType<UIManager>(); // Tìm và lưu tham chiếu đến thành phần UIManager
        m_ui.SetScoreText("Score: " + m_score); // Cập nhật điểm trong giao diện người dùng
    }

    // Update is called once per frame
    void Update()
    {
        m_spawnTime -= Time.deltaTime; // Giảm thời gian còn lại cho lần sinh ra tiếp theo dựa trên thời gian trôi qua

        if (m_isGameover)
        {
            m_spawnTime = 0; // Ngừng sinh ra bóng
            m_ui.ShowGameoverPanel(true); // Hiển thị bảng kết thúc trò chơi trong giao diện người dùng
            return;
        }

        if (m_spawnTime <= 0)
        {
            Spawnball(); // Sinh ra một quả bóng mới
            m_spawnTime = spawnTime; // Đặt lại thời gian còn lại cho lần sinh ra tiếp theo
        }
    }

    public void Spawnball()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-8, 8), 6); // Tạo vị trí sinh ra bóng ngẫu nhiên 

        if (ball)
        {
            Instantiate(ball, spawnPos, Quaternion.identity); // Tạo một quả bóng mới tại vị trí sinh ra
        }
    }

    public void Replay()
    {
        m_score = 0; // Đặt lại điểm số về 0
        m_isGameover = false; 
        m_ui.SetScoreText("Score: " + m_score); // Cập nhật điểm 
        m_ui.ShowGameoverPanel(false); // Ẩn panel gameover trong giao diện người dùng
    }

    public int SetScore(int value)
    {
        return m_score; // Trả về điểm hiện tại
    }

    public void IncrementScore()
    {
        m_score++; // Tăng điểm lên 1
        m_ui.SetScoreText("Score: " + m_score); // Cập nhật điểm trong giao diện người dùng
    }

    public bool IsGameover()
    {
        return m_isGameover; 
    }

    public void SetGameoverState(bool state)
    {
        m_isGameover = state; 
    }
}
