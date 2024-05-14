using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // 다양한 적들 사용시 쓰는 코드
    [SerializeField]
    private GameObject[] enemies;

    [SerializeField]
    private GameObject boss;

    private float[] arrPositionX = {-2f, -0.7f, 0.7f, 2f};

    [SerializeField]
    private float spawnInterval = 1.5f;
    // Start is called before the first frame update
    // void Start(){
    //     StartEnemyRoutine();
    // }

    public void StartEnemyRoutine(){
        StartCoroutine("EnemyRoutine");
    }

    public void StopEnemyRoutine(){
        StopCoroutine("EnemyRoutine");
    }

    IEnumerator EnemyRoutine(){
        yield return new WaitForSeconds(3f);

        int spawnCnt = 0;
        int enemyIndex = 0;
        float moveSpeed = 5f;
        while(true){
            foreach(float posX in arrPositionX){
                SpawnEnemy(posX, enemyIndex, moveSpeed);
            }

            spawnCnt++;
            if(spawnCnt % 20 == 0){
                enemyIndex += 1;
                moveSpeed += 2;
            }

            if(enemyIndex >= enemies.Length){
                SpawnBoss();
                enemyIndex = 0;
                moveSpeed = 5f;
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy(float posX, int idx, float moveSpeed){
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);

        if(Random.Range(0, 5) == 0){
            idx++;
        }

        if(idx >= enemies.Length){
            idx = enemies.Length - 1;
        }

        GameObject enemyObject = Instantiate(enemies[idx], spawnPos, Quaternion.identity);
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        enemy.SetMoveSpeed(moveSpeed);
    }

    void SpawnBoss(){
        Instantiate(boss, transform.position, Quaternion.identity);
    }
}
