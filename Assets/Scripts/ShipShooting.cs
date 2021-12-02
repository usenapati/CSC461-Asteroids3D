using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class ShipShooting : MonoBehaviour
{
    [Header("Ship Settings")]
    [SerializeField] private ShipMovement ship;

    [Header("Hardpoint Settings")]
    [SerializeField]
    private Transform[] hardPoints;
    [SerializeField]
    private LayerMask shootableMask;
    [SerializeField]
    private float hardpointRange = 100f;
    //private bool targetInRange = false;

    [Header("Laser Settings")]
    [SerializeField]
    private LineRenderer[] lasers;
    [SerializeField]
    private List<ParticleSystem> laserHitParticles;
    [SerializeField]
    private float laserDamage = 2f;
    [SerializeField]
    private float timeBetweenDamage = 0.25f;
    private float currentTimeBetweenDamage;
    [SerializeField]
    private float laserHeatThreshold = 2f;
    [SerializeField]
    private float laserHeatRate = 0.25f;
    [SerializeField]
    private float laserCoolRate = 0.5f;
    public float currentLaserHeat = 0f;
    private bool overHeated = false;

    private bool firing;

    private CinemachineVirtualCamera cam;

    public enum FireMode { Laser, Blaster };
    public FireMode fireMode;

    [Header("Blaster Settings")]
    [SerializeField]
    private GameObject blasterBolt;
    [SerializeField]
    private float blastRate;
    bool canBlast;
    float blastTimer;

    private void Awake()
    {
        ship = GetComponent<ShipMovement>();
        if (ship.isThirdPerson)
        {
            cam = ship.shipThirdPersonCam;
        }
        else
        {
            cam = ship.shipFirstPersonCam;
        }
    }

    private void FixedUpdate()
    {
        if (fireMode == FireMode.Laser)
        {
            HandleLaserFiring();
        }
        if (fireMode == FireMode.Blaster)
        {
            HandleBlasterFiring();
        }
    }

    private void HandleBlasterFiring() 
    {
        if (firing && canBlast) {
            FireBlaster();
            blastTimer = 0f;
            canBlast = false;
        }
        else
        {
            blastTimer += Time.fixedDeltaTime;
            if (blastTimer > (1f / blastRate)) {
                canBlast = true;
            }
        }
    }

    private void FireBlaster()
    {
        foreach (Transform t in hardPoints) {
            Instantiate(blasterBolt, t.position, t.rotation);
        }
    }

    private void HandleLaserFiring()
    {
        if (firing && !overHeated)
        {
            FireLaser();
        }
        else
        {
            foreach(var laser in lasers)
            {
                laser.gameObject.SetActive(false);
            }

            CoolLaser();
        }
    }

    void ApplyDamage(Asteroid asteroid)
    {
        currentTimeBetweenDamage += Time.deltaTime;
        if (currentTimeBetweenDamage > timeBetweenDamage)
        {
            currentTimeBetweenDamage = 0f;
            asteroid.TakeDamage(laserDamage);
            Debug.Log("Applying damage to: " + asteroid.gameObject.name);
        }
        
    }

    void FireLaser()
    {
        RaycastHit hitInfo;

        if (TargetInfo.IsTargetInRange(cam.transform.position, cam.transform.forward, out hitInfo, hardpointRange, shootableMask))
        {
            if (hitInfo.collider.GetComponentInParent<Asteroid>())
            {
                ApplyDamage(hitInfo.collider.GetComponentInParent<Asteroid>());
            }
            
            foreach(ParticleSystem p in laserHitParticles) { 
                Instantiate(p, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            }

            foreach(var laser in lasers)
            {
                Vector3 localHitPosition = laser.transform.InverseTransformPoint(hitInfo.point);
                laser.gameObject.SetActive(true);
                laser.SetPosition(1, localHitPosition);
            }
        }
        else
        {
            foreach (var laser in lasers)
            {
                laser.gameObject.SetActive(true);
                laser.SetPosition(1, new Vector3(0, 0, hardpointRange));
            }
        }

        HeatLaser();
    }

    void HeatLaser()
    {
        if (firing && currentLaserHeat < laserHeatThreshold)
        {
            currentLaserHeat += laserHeatRate;

            if (currentLaserHeat >= laserHeatThreshold)
            {
                overHeated = true;
                firing = false;
            }
        }
    }

    void CoolLaser()
    {
        if (overHeated)
        {
            if (currentLaserHeat / laserHeatThreshold <= 0.5f)
            {
                overHeated = false;
            }
        }

        if (currentLaserHeat > 0f)
        {
            currentLaserHeat -= laserCoolRate;
        }
    }

    #region Input
    public void OnFire(InputAction.CallbackContext context)
    {
        firing = context.performed;
    }
    #endregion
}
