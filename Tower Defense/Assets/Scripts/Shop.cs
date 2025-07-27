using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard Turret Purchased");
        buildManager.setTurretToBuild(buildManager.standardTurretPrefab);

    }
    public void PurchaseMissileLauncher()
    {
        Debug.Log("Missile Turret Purchased");   
        buildManager.setTurretToBuild(buildManager.MissileTurretPrefab);
    }
}
