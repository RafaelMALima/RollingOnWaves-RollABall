using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public bool enableControls;
    public float forwardNoWind = 0.01f;
    public Vector3 windDirection;
    public float windForce = 0.1f;
    public float turnSpeed = 0.1f;
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject hpUI;
    public float tMinus;
    public bool peacefull;
    private float time;

    private int points = 0;
    public TMP_Text countText;
    public TMP_Text timerText;

    public GameObject gameOverScreen;
    public GameObject pauseScreen;

    private Vector3 closestChickenDir;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        UpdatePointsText();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(transform.forward * forwardNoWind, ForceMode.Impulse);
        rb.AddForce((transform.forward.normalized + windDirection.normalized) * windForce, ForceMode.Impulse);
        if (enableControls)
        {
            rb.AddTorque(new Vector3(0, Input.GetAxis("Horizontal") * turnSpeed, 0));
            if (Input.GetKeyDown(KeyCode.Escape))
                pauseScreen.SetActive(!pauseScreen.activeSelf);
           }
    }

    private void Update()
    {
        if (enableControls)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                pauseScreen.SetActive(!pauseScreen.activeSelf);
        }

        if (!peacefull){
            closestChickenDir = NearestChickenPos();
            CountDown();
        }
        // Debug.Log(closestChickenDir);
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        hpUI.GetComponent<HpBar>().TakeDamage(dmg);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            gameOverScreen.SetActive(true);
        }
    }

    public void CountDown()
    {
        timerText.text = "Tempo Restante:" + tMinus.ToString("0");
        if (tMinus <= 0) {
            Destroy(gameObject);
            gameOverScreen.SetActive(true);
            tMinus = 0;
        }else
            tMinus -= Time.deltaTime;
    }

    public int GetPoints()
    {
        return points;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")){
            points += 1;
            Destroy(other.gameObject);
            UpdatePointsText();
            tMinus += 10;
        }
    }

    void UpdatePointsText()
    {
        countText.text = "Galinhas salvas:" + points.ToString();
    }

    Vector3 NearestChickenPos()
    {
        GameObject[] allObjects = (GameObject[])FindObjectsOfType(typeof(GameObject));
        Vector3 dir = new Vector3(100,0,100);
        foreach (GameObject obj in allObjects)
        {
            if ((obj.transform.name == "chickn(Clone)" || obj.transform.name == "chickn") && (dir.magnitude > Vector3.Distance(obj.transform.position, transform.position)))
                dir = obj.transform.position - transform.position;
        }
        return dir;
    }

    public Vector3 GetClosestChickenDirection()
    {
        return closestChickenDir;
    }

}
