using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public float moveSpeed; // Tốc độ di chuyển của đối tượng
    float xDirection; // Hướng di chuyển theo trục x

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        xDirection = Input.GetAxisRaw("Horizontal"); // Lấy giá trị đầu vào theo phương ngang từ bàn phím

        float moveStep = moveSpeed * xDirection * Time.deltaTime; // Tính toán bước di chuyển dựa trên tốc độ, hướng và thời gian 

        if ((transform.position.x <= -6.61f && xDirection < 0) || (transform.position.x >= 6.61f && xDirection > 0))
            return; // Kiểm tra giới hạn di chuyển và ngăn chặn di chuyển nếu đã đạt giới hạn

        transform.position = transform.position + new Vector3(moveStep, 0, 0); // Áp dụng bước di chuyển vào vị trí hiện tại của đối tượng để di chuyển nó theo trục x
    }
}
