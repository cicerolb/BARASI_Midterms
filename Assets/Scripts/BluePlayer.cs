using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayer : MonoBehaviour
{
    [SerializeField] float initialVelocity;
    [SerializeField] float _Angle;
    [SerializeField] LineRenderer line;
    [SerializeField] float step;
    [SerializeField] Transform firePosition;
    [SerializeField] GameObject firePositionPrefab;
    [SerializeField] GameObject currentPrefabInstance;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float angle = _Angle * Mathf.Deg2Rad;
        DrawPath(initialVelocity, angle, step);


        if (Input.GetKeyDown(KeyCode.RightShift))
        {

            if (currentPrefabInstance != null)
            {
                Destroy(currentPrefabInstance);
            }

            currentPrefabInstance = Instantiate(firePositionPrefab, firePosition.position, Quaternion.identity);
            StopAllCoroutines();
            StartCoroutine(Coroutine_Movement(initialVelocity, angle));
        }
        AimAdjust();
    }

    private void DrawPath(float v0, float angle, float step)
    {
        step = Mathf.Max(0.01f, step);
        float totalTime = 10;
        line.positionCount = (int)(totalTime / step) + 2;
        int count = 0;
        for (float i = 0; i < totalTime; i += step)
        {
            float x = v0 * i * -Mathf.Cos(angle);
            float y = v0 * i * Mathf.Sin(angle) - 0.5f * -Physics.gravity.y * Mathf.Pow(i, 2);
            line.SetPosition(count, firePosition.position + new Vector3(x, y, 0));
            count++;
        }
        float xFinal = v0 * totalTime * Mathf.Cos(angle);
        float yFinal = v0 * totalTime * Mathf.Sin(angle) - (1f / 2f) * -Physics.gravity.y * Mathf.Pow(totalTime, 2);
        line.SetPosition(count, firePosition.position + new Vector3(xFinal, yFinal, 0));
    }

    IEnumerator Coroutine_Movement(float v0, float angle)
    {
        float t = 0;
        while (t < 100)
        {
            float x = v0 * t * -Mathf.Cos(angle);
            float y = v0 * t * Mathf.Sin(angle) - (1f / 2f) * -Physics.gravity.y * Mathf.Pow(t, 2);
            transform.position = currentPrefabInstance.transform.position + new Vector3(x, y, 0);
            t += Time.deltaTime;
            yield return null;
        }
    }

    void AimAdjust()
    {

        if (Input.GetKey(KeyCode.Period))
        {
            initialVelocity += 1 * 6 * Time.deltaTime;
        }

        if (initialVelocity > 20)
        {
            initialVelocity = 1;
        }

        if (Input.GetKey(KeyCode.Slash))
        {
            _Angle += 1 * 20 * Time.deltaTime;
        }

        if (_Angle > 88)
        {
            _Angle = 1;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collidable"))
        {
            StopAllCoroutines();
        }
    }

}
