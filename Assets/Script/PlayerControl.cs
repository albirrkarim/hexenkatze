using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    /* Initialize */
    /* Tinggi lompat */
    public Vector2 jumpForce = new Vector2(0, 350);

    /* Music */
    public AudioSource JumpSound;
    public AudioSource SwordPlusSound;
    public AudioSource SwordMinSound;
    public AudioSource DogSound;
    public AudioSource FishSound;
    public AudioSource CatFoodSound;
    public AudioSource BoneSound;
    public AudioSource FireSound;

    /* Button */
    public Button btnUp,btnLeft,btnRight;

    /* UI Text untuk notifikasi flash */
    public Text NotifText;

    /* Data si player*/
    int life         = 5;
    int attackPower  = 0;
    bool isStun      = false;
    bool isJump      = false;
    bool isWalkLeft  = false;
    bool isWalkRight = false;

    /* Game Object untuk nyawa player */

    public GameObject[] arrLifeBar;
    public GameObject[] arrAttackBar;


    /* Untuk Ganti Animasi player*/
    public int animCounter = 0;

    Animator animator;
    Vector3 scale;

    /*Background */
    public GameObject[] Background;

    /* Cherry */
    public GameObject CherryLeft;
    public GameObject CherryRight;

    bool canFire            = true;
    bool isFire             = false;
    bool isReverseMovement  = false;

    /* Like a Set Timeout function in javascript */
    IEnumerator WaitForStunToEnd(bool isClearingText=false)
    {
        yield return new WaitForSeconds(1f);
        isStun = false;
        if(isClearingText){
            NotifText.text = "";
        }
    }

    IEnumerator WaitForCanFire()
    {
        yield return new WaitForSeconds(0.2f);
        canFire = true;
    }

    IEnumerator normalizeMovement()
    {
        yield return new WaitForSeconds(5f);
        isReverseMovement = false;
        NotifText.text="";
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (PlayerPrefs.HasKey("isResume"))
        {
            attackPower = PlayerPrefs.GetInt("attackPower");
            life = PlayerPrefs.GetInt("playerLife");
            PlayerPrefs.DeleteKey("isResume");
        }
        whatAttack();
        whatLife();

        if(!PlayerPrefs.HasKey("whatLevel")){
			PlayerPrefs.SetInt("whatLevel",1);
		}
        
        int level=PlayerPrefs.GetInt("whatLevel");
        int i;

        for(i=0;i<3;i++){
            if(level==i+1){
                Background[i].gameObject.SetActive(true);
            }else{
                Background[i].gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStun)
        {
            if (Input.GetKeyDown("space") || Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || isJump)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.9f);
                GetComponent<Rigidbody2D>().AddForce(jumpForce);
            
                playMusic("jump");
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)|| isWalkLeft)
            {
                transform.position += new Vector3(-4, 0, 0) * Time.deltaTime * 2;

                GetComponent<SpriteRenderer>().flipX = false;

                scale = transform.localScale;
                
                if(scale.x < 0 ){
                    scale.x *= -1;
                }
                transform.localScale = scale;
                
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)||isWalkRight)
            {
                transform.position += new Vector3(4, 0, 0) * Time.deltaTime * 2;
                GetComponent<SpriteRenderer>().flipX = true;
            
                scale = transform.localScale;
                
                if(scale.x > 0 ){
                    scale.x *= -1;
                }
                transform.localScale = scale;
            }

            if (Input.GetKey(KeyCode.E)||isFire)
            {
                scale = transform.localScale;
                if(canFire){
                    if(scale.x<0){
                        /* Player hadap kiri*/
                        Instantiate(CherryLeft);
                    }else{
                        Instantiate(CherryRight);
                    }
                    canFire=false;
                    FireSound.Play();
                    StartCoroutine(WaitForCanFire());
                }
            }

            if (life <= 0)
            {
                SceneManager.LoadScene("PlayerScore");
            }

            if (attackPower >= 7)
            {
                SceneManager.LoadScene("Win");
            }
    
            Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            if (screenPosition.y > Screen.height || screenPosition.y < 0)
            {
                isStun = true;
                NotifText.text = "Can't fly higher";
                StartCoroutine(WaitForStunToEnd(true));
            }
        }
    }

    /* Event Handler Button (onPress / onUnPress) */
    void onPress(Button btn){
        scale = btn.transform.localScale;
        scale -= new Vector3(0.1f, 0.1f, 0.1f);
        btn.transform.localScale = scale;
    }

    void onUnPress(Button btn){
        scale = btn.transform.localScale;
        scale += new Vector3(0.1f, 0.1f, 0.1f);
        btn.transform.localScale = scale;
    }

    public void aksiFirePress(){
        isFire=true;
    }

    public void aksiFireUnPress(){
        isFire=false;
    }
    
    public void aksiUpPress(){
        isJump=true;
        onPress(btnUp);
    }

    public void aksiUpUnPress(){
       isJump=false;
       onUnPress(btnUp); 
    }

    public void aksiLeftPress(){
        if(isReverseMovement){
            isWalkRight=true;
        }else{
            isWalkLeft=true;  
        }
        onPress(btnLeft);
    }

    public void aksiLeftUnPress(){
        if(isReverseMovement){
            isWalkRight=false;
        }else{
            isWalkLeft=false;
        }
        onUnPress(btnLeft);
    }

    public void aksiRightPress(){
        if(isReverseMovement){
            isWalkLeft=true;
        }else{
            isWalkRight=true;   
        }
        onPress(btnRight);
    }

    public void aksiRightUnPress(){
        if(isReverseMovement){
            isWalkLeft=false;
        }else{
            isWalkRight=false;
        }
        onUnPress(btnRight);
    }

    /* Event Handler Collider Listener */
    void OnCollisionEnter2D(Collision2D coll)
    {
        /* Mulai nabrak */
        if (coll.gameObject.tag == "boneTag")
        {
            playMusic("boneTag");
            isStun = true;
            
            if(PlayerPrefs.GetInt("whatLevel") == 3){
                isReverseMovement=true;
                NotifText.text = "Paralized ...";
                StartCoroutine(normalizeMovement());
                StartCoroutine(WaitForStunToEnd(false));
            }else{
                NotifText.text = "Stunned ...";
                StartCoroutine(WaitForStunToEnd(true));
            }
        }
        if (coll.gameObject.tag == "fishTag")
        {
            tambahLife();
            playMusic("fishTag");
        }
        if (coll.gameObject.tag == "catFoodTag")
        {
            tambahLife();
            playMusic("catFoodTag");
        }
        if (coll.gameObject.tag == "swordMinTag")
        {
            kurangiAttack();
            playMusic("swordMinTag");
        }
        if (coll.gameObject.tag == "swordPlusTag")
        {
            attackPower ++;
            PlayerPrefs.SetInt("attackPower", attackPower);
            whatAttack();
            playMusic("swordPlusTag");
        }
        if (coll.gameObject.tag == "dogTag")
        {
            kurangiLife();
            playMusic("dogTag");
        }
    }

    /* Fungsi Tambahan */
    void playMusic(string mode)
    {   
        if (!PlayerPrefs.HasKey("isUseMusic") || PlayerPrefs.GetInt("isUseMusic") == 1)
        {
            if (mode == "jump")
            {
                JumpSound.Play();
            }
            else if (mode == "boneTag")
            {
                BoneSound.Play();
            }
            else if (mode == "fishTag")
            {
                FishSound.Play();
            }
            else if (mode == "catFoodTag")
            {
                CatFoodSound.Play();
            }
            else if (mode == "swordMinTag")
            {
                SwordMinSound.Play();
            }
            else if (mode == "swordPlusTag")
            {
                SwordPlusSound.Play();
            }
            else if (mode == "dogTag")
            {
                DogSound.Play();
            }
        }
    }


    void tambahLife()
    {
        life++;
        if (life > 5)
        {
            life = 5;
        }
        PlayerPrefs.SetInt("playerLife",life);
        whatLife();
    }

    void kurangiLife()
    {
        life--;
        if (life < 0)
        {
            life = 0;
        }
        PlayerPrefs.SetInt("playerLife",life);
        whatLife();
    }

    void kurangiAttack(){
        attackPower --;
        if(attackPower<0){
            attackPower=0;
        }
        PlayerPrefs.SetInt("attackPower", attackPower);
        whatAttack();
    }

    void whatAttack()
    {
        for (int i = 0; i < 7; i++){   
            if(i<attackPower){
                arrAttackBar[i].SetActive(true);
            }else{
                arrAttackBar[i].SetActive(false);
            }
        }
    }

    void whatLife()
    {
        for (int i = 0; i < 5; i++){
            if(i<life){
                arrLifeBar[i].SetActive(true);
            }else{
                arrLifeBar[i].SetActive(false);
            }
        }
    }
}
