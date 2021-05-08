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
    
    public int onTrapDamageAmount;
    public Image HealthBar;

    [SerializeField]
    private float Mana;
    public float attackManaAmount;
    public float recoverManaAmount;
    private float manaRecoveryTime = 0;
    private float startManaRecoveryTime = 0.3f;
    public Image ManaBar;

    private Equipment m_Equipment;
    public Equipment Equipment { get { return m_Equipment; } }

    private CombatInventory Weapon;
    
	public float Health { get; set; }
    TextMeshProUGUI HealthTextLabel ;

    public GameManager gameManager;

    public float superPowerManaAmount;
    private bool isSuperPowerMode = false;
    private float superPowerTime = 0;
    private float startSuperPowerTime = 0.3f;
    public GameObject superPowerSprite;

    void SuperPowerMode(){
        if( !isSuperPowerMode ){
            if( Mana > 0 ){
                ActivateSuperPowerMode();
            }
        }
        else{
            DeactivateSuperPowerMode();
        }
    }

    void ActivateSuperPowerMode(){
        isSuperPowerMode = true;
        superPowerSprite.SetActive(true);
        m_MovementController.AllowToWallClimb();
    }
    void DeactivateSuperPowerMode(){
        isSuperPowerMode = false;
        superPowerSprite.SetActive(false);
        m_MovementController.PreventToWallClimb();
    }

    void onSuperPowerMode(){

        if( !isSuperPowerMode )
            return;
        
        if( Mana <= 0 )
            DeactivateSuperPowerMode();

        superPowerTime -= Time.deltaTime;
        if (superPowerTime <= 0)
        {
            superPowerTime = startSuperPowerTime;
            UseMana(-superPowerManaAmount);
        }

    }
    private void MagicAttack(){
        if(Mana <= attackManaAmount){
            Debug.Log("not enough man");
            return;
        }
        if( Weapon.AbilityAttack() )
            UseMana(-attackManaAmount);
    }

    private void UseMana(float value){
        Mana += value;

        Mana = Mathf.Min(100, Mana);
        Mana = Mathf.Max(0, Mana);
        
        if( ManaBar )
            ManaBar.fillAmount = Mana / 100;
    }

	public void TakeDamage (float damage){
        // Debug.Log("Soo We will change Health variabe");
        if(Health <= 0){
            return;
        }
        Health -= damage;
        HealthBar.fillAmount = Health / 100;
        if(Health <= 0){
            Debug.Log("You Died");
            gameManager.RestartLevel();
        }
    }

    void RecoverMana(){

        manaRecoveryTime -= Time.deltaTime;
        if (manaRecoveryTime <= 0)
        {
            manaRecoveryTime = startManaRecoveryTime;
            UseMana(recoverManaAmount);
        }

    }

    void playOnSoundAudio(){
        Debug.Log("Jump SOund");
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
        Health = 100f;

        transform.position = gameManager.GetCheckpoint().GetPosition();

    }

    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Q) ){
            Weapon.ChangeWeapon();
        }

        if( Input.GetKeyDown(KeyCode.R) ){
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if( Input.GetKeyDown(KeyCode.E) ){
            SuperPowerMode();
        }

        if( Input.GetMouseButtonDown(0) ){
            Debug.Log("Weapon ATTACK");
            Weapon.Attack();
        }

        else if( Input.GetMouseButtonDown(1) ){
            Debug.Log("ABILITY ATTACK");
            MagicAttack();
        }
        
        RecoverMana();
        onSuperPowerMode();

    }

    private void initCallback()
    {
        m_MovementController.OnAirJump += delegate { 
            m_StatController.JumpCounter++; 
            playOnSoundAudio();
        };
        m_MovementController.OnResetJumpCounter += delegate (MotorState state) { m_StatController.JumpCounter = 0; };
        m_MovementController.CanAirJumpFunc = delegate { 
            return m_StatController.JumpCounter < (int)m_StatController.JumpCount.Value;
        };
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
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "spike"){
            // Debug.Log("dead");
            TakeDamage(onTrapDamageAmount);
        }
    }
}
