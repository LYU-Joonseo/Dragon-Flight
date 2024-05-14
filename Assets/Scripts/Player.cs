using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    
    [SerializeField]
    private GameObject[] weapons;

    private int weaponIdx = 0;

    [SerializeField]
    private Transform ShootTransform;

    [SerializeField]
    private float shootInterval = 0.05f;
    private float lastShotTime = 0f;
    // Update is called once per frame
    void Update(){
        float LRInput = Input.GetAxisRaw("Horizontal");      // 좌 우 이동
        float UDInput = Input.GetAxisRaw("Vertical");         // 위 아래 이동
        Vector3 moveTo = new Vector3(LRInput, UDInput, 0f);
        transform.position += moveTo * moveSpeed * Time.deltaTime;

        //좌우만 움직이게끔 만든 코드
        // Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        // if(Input.GetKey(KeyCode.LeftArrow)){
        //     transform.position -= moveTo;
        // }else if(Input.GetKey(KeyCode.RightArrow)){
        //     transform.position += moveTo;
        // }

        if(MenuManager.instance.isGameMenu == true && GameManager.instance.isGameOver == false){
            Shoot();
        }
    }

    void Shoot(){
        if(Time.time - lastShotTime > shootInterval){
            Instantiate(weapons[weaponIdx], ShootTransform.position, Quaternion.identity);
            lastShotTime = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss"){
//            Debug.Log("Game Over");
            GameManager.instance.SetGameOver(false);
            Destroy(gameObject);
        }else if(other.gameObject.tag == "Coin"){
//            Debug.Log("Coine +1");
            GameManager.instance.IncreaseCoin();
            Destroy(other.gameObject);
        }
    }

    public void Upgrade(){
        weaponIdx++;
        if(weaponIdx >= weapons.Length){
            weaponIdx = weapons.Length - 1;
        }
    }
}
