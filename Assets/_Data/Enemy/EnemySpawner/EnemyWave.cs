using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : SaiBehaviour
{
    [SerializeField] protected EnemySpawnerCtrl ctrl;
    // Toc do spawn quai
    [SerializeField] protected float timer = 0;
    [SerializeField] protected int wavePointIndex = 0;
    [SerializeField] protected float spawnSpeed = 1f;
    [SerializeField] protected int maxSpawn = 10;
    [SerializeField] protected List<WavePoint> wavePoints = new();
    [SerializeField] protected List<EnemyCtrl> spawnedEnemies = new();
    

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.Spawning), this.spawnSpeed);
    }

    protected virtual void FixedUpdate()
    {
        this.RemoveDeadOne();
        this.Spawning();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawnerCtrl();
        this.LoadWavePoint();
    }

    protected virtual void LoadEnemySpawnerCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = GetComponent<EnemySpawnerCtrl>();
        Debug.Log(transform.name + ": LoadEnemySpawnerCtrl", gameObject);
    }
    protected virtual WavePoint GetWavePoint()
    {
        this.wavePointIndex++;
        if (this.wavePointIndex >= this.wavePoints.Count) this.wavePointIndex = 0;
        return this.wavePoints[this.wavePointIndex];
    }
    protected virtual void LoadWavePoint()
    {
        if (this.wavePoints.Count > 0) return;
        WavePoint[] points = this.ctrl.GetComponentsInChildren<WavePoint>();
        this.wavePoints = new List<WavePoint>(points);
        Debug.Log(transform.name + ": LoadWavePoint", gameObject);
    }

    protected virtual void Spawning()
    {
        Invoke(nameof(this.Spawning), this.spawnSpeed);

        if (this.spawnedEnemies.Count >= this.maxSpawn) return;
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.spawnSpeed) return;
        this.timer = 0;

        WavePoint wavePoint = GetWavePoint();
        EnemyCtrl prefab = this.ctrl.Prefabs.GetRandom();
        EnemyCtrl newEnemy = this.ctrl.Spawner.Spawn(prefab, wavePoint.transform.position);
        newEnemy.gameObject.SetActive(true);
        this.spawnedEnemies.Add(newEnemy);
    }

    // Xoa khoi danh sach spawnedEnemies 
    protected virtual void RemoveDeadOne()
    {
        foreach (EnemyCtrl enemyCtrl in this.spawnedEnemies)
        {
            if (enemyCtrl.EnemyDamageReceiver.IsDead())
            {
                this.spawnedEnemies.Remove(enemyCtrl);
                return;
            }
        }
    }
}
