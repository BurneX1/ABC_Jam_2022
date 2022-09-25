using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeController : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public float increaseMultiplier;

    private float GetSpeed()
    {
        return speed = Mathf.Clamp(speed, speed, maxSpeed);
    }
    private float IncreaseSpeedOverTime()
    {
        return speed += Time.deltaTime * increaseMultiplier;
    }

    private void Update()
    {
        MoveProducts();
    }

    private void MoveProducts()
    {
        foreach (Transform child in transform)
            child.transform.position =
                new Vector3(child.transform.position.x,
                child.transform.position.y - GetSpeed() * Time.deltaTime,
                child.transform.position.z);

        IncreaseSpeedOverTime();
    }
}