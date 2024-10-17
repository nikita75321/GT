using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private AnimationCurve curveY;
    [SerializeField] private float time = 0;
    [SerializeField] private float totalTime = 2;
    private bool bulletFly = false;
    private GameObject cloneBullet;

    private void Update()
    {
        if (bulletFly)
        {
            time += Time.deltaTime;
            cloneBullet.transform.position = new Vector3(cloneBullet.transform.position.x, 
                                                        curveY.Evaluate(time)*2,
                                                        cloneBullet.transform.position.z);

            cloneBullet.transform.Translate(Vector3.forward * Time.deltaTime * 10);

            if (time >= totalTime)
            {
                bulletFly = false;
                time = 0;
            }
        }


        if (Input.GetKeyDown(KeyCode.F) && !bulletFly)
        {
            cloneBullet = Instantiate(bullet, transform);
            bulletFly = true;
        }
    }
}
