using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Entity
{
    protected override void Start() {
        base.Start();
        _health.maxValue = 100;
    }
    public override void Die() {
        Destroy(gameObject);
        SceneManager.LoadScene("DeathScreen");



}
