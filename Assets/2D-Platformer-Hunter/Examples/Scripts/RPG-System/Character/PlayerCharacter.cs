using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DYP;
using UnityEngine.UI; // Required when Using UI elements.
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour, IDamagable, IHasInventory, IHasEquipment
{
    private CharacterStatController m_StatController;
    private BasicMovementController2D m_MovementController;
    private AdventurerAnimationController m_AnimationController;

    private Inventory m_Inventory;
    public Inventory Inventory { get { return m_Inventory; } }

    private Equipment m_Equipment;
    public Equipment Equipment { get { return m_Equipment; } }

    private CombatInventory Weapon;
    
	public float Health { get; set; }
    TextMeshProUGUI HealthTextLabel ;
	public void TakeDamage (float damage){
        Debug.Log("Soo We will change Health variabe");
        
        // Time.timeScale = 0;
    }

    private void Awake()
    {
        m_StatController = GetComponent<CharacterStatController>();
        m_MovementController = GetComponent<BasicMovementController2D>();
        m_AnimationController = GetComponent<AdventurerAnimationController>();

        m_Inventory = GetComponent<Inventory>();
        m_Equipment = GetComponent<Equipment>();

        Weapon = GetComponent<CombatInventory>();
        Weapon.Initialize();
    }

    private void Start()
    {
        initCallback();
    }

    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Q) ){
            Weapon.changeWeapon();
        }

        if( Input.GetKeyDown(KeyCode.R) ){
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if( Input.GetMouseButtonDown(0) ){
            Weapon.Attack();
        }

        else if( Input.GetMouseButtonDown(1) ){
            Debug.Log("ABILITY ATTACK");
        }
    }

    private void initCallback()
    {
        m_MovementController.OnAirJump += delegate { m_StatController.JumpCounter++; };
        m_MovementController.OnResetJumpCounter += delegate (MotorState state) { m_StatController.JumpCounter = 0; };
        m_MovementController.CanAirJumpFunc = delegate { return m_StatController.JumpCounter < (int)m_StatController.JumpCount.Value; };
    }

    public void UseItem(BaseItem item)
    {
        m_Inventory.RemoveItem(item, 1);
        // TODO: use item
    }

    public int AddItem(BaseItem item, int count)
    {
        return m_Inventory.AddItem(item, count);
    }
    
    public bool RemoveItem(BaseItem item, int count)
    {
        return m_Inventory.RemoveItem(item, count);
    }

    public bool HasItem(BaseItem item, int count)
    {
        return m_Inventory.HasItem(item, count);
    }

    public bool Equip(EquippableItem equipment)
    {
        // TODO: remove equipment, remove from inventory

        equipment.Equip(m_StatController);

        if (equipment is WeaponItem)
        {
            // TODO: swap skills and animation ...etc
        }

        throw new NotImplementedException();
    }

    public bool Unequip(EquippableItem equipment)
    {
        throw new NotImplementedException();
    }
}
