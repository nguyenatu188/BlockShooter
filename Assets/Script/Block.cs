
using GoogleMobileAds.Api;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Block : MonoBehaviour
{
    private InterstitialAd interstitial;

    public TextMeshPro textHP;
    public float blockHP = 99;
    public float fallingSpeed = 3.0f;
    private float timer;
    private int loseCounter;

    public ParticleSystem explosion;

    private GameObject blowUp;
    private AudioSource blowUpSound;

    private void RequestIntersitial()
    {
        #if Unity_ANDROID
            string adUnitId = "Block Shooterca-app-pub-7201261346151205~3649741485";
        #else
            string adUnitId = "unexpected_platform";
        #endif
        this.interstitial = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
    }

    void Start()
    {
        blowUp = GameObject.FindWithTag("explosionSound");
        blowUpSound = blowUp.GetComponent<AudioSource>();
        textHP.text = blockHP.ToString();
        timer = fallingSpeed;
        RequestIntersitial();
        loseCounter = PlayerPrefs.GetInt("loseCounter");
    }


    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.1f);
            timer = fallingSpeed;
        }
        if (blockHP <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            blowUpSound.Play();
            BlockController.instance.blockCount--;
            scoreManager.instance.score++;
            if (BlockController.instance.blockCount <= 0)
            {
                BlockController.instance.ActiveWinPopUp();
            }
        }
    }

    public void OnDamaged(float damage)
    {
        blockHP -= damage;
        textHP.text = blockHP.ToString();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            scoreManager.instance.score = 4 - BlockController.instance.blockCount;
            BlockController.instance.ActiveLostPopUp();
            loseCounter++;
            if (loseCounter > 2)
            {
                loseCounter = 1;
            }
            PlayerPrefs.SetInt("loseCounter", loseCounter);
            if (this.interstitial.IsLoaded() && loseCounter == 2)
            {
                this.interstitial.Show();
            }
        }
    }

    

}
