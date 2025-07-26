using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public GameObject ImpactEffect;
    public void Seek(Transform _target)
    {
        target = _target;
    }
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distThisFrame, Space.World);
    }
    void HitTarget()
    {
        // Debug.Log("Hit!");
        GameObject inst = (GameObject)Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(inst, 2f);
        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
